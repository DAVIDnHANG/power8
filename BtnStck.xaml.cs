﻿using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;

namespace Power8
{
    /// <summary>
    /// Interaction logic for BtnStck.xaml
    /// </summary>
    public partial class BtnStck
    {
        private static BtnStck _instance;
        public static BtnStck Instance
        {
            get { return _instance ?? (_instance = new BtnStck()); }
            private set { _instance = value; }
        }

        private readonly MenuItemClickCommand _cmd = new MenuItemClickCommand();

        #region Load, Unload, Show, Hide
        public BtnStck()
        {
            InitializeComponent();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !MainWindow.ClosedW;
            if (e.Cancel)
                Hide();
            else
                Instance = null;
        }

        private void WindowDeactivated(object sender, EventArgs e)
        {
            Hide();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.MakeGlassWpfWindow();
            MinHeight = Height;
            MaxHeight = MinHeight;
            MinWidth = Width;
            MaxWidth = MinWidth;
        }
        #endregion

        #region Buttons handlers
        private void ButtonHibernateClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.SetSuspendState(System.Windows.Forms.PowerState.Hibernate, true, false);
        }

        private void ButtonSleepClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.SetSuspendState(System.Windows.Forms.PowerState.Suspend, true, false);
        }

        private void ButtonShutdownClick(object sender, RoutedEventArgs e)
        {
            LaunchShForced("-s");
        }

        private void ButtonRestartClick(object sender, RoutedEventArgs e)
        {
            LaunchShForced("-r");
        }

        private void ButtonLogOffClick(object sender, RoutedEventArgs e)
        {
            LaunchShForced("-l");
        }

        private void ButtonLockClick(object sender, RoutedEventArgs e)
        {
            StartConsoleHidden(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
        }

        private void ButtonScreensaveClick(object sender, RoutedEventArgs e)
        {
            API.SendMessage(API.GetDesktopWindow(), API.WM_SYSCOMMAND, API.SC_SCREENSAVE, 0);
        }
        #endregion

        #region Helpers
        private static void LaunchShForced(string arg)
        {
            StartConsoleHidden("shutdown.exe", arg + " -f -t 0");
        }

        private static void StartConsoleHidden(string exe, string args)
        {
            var si = new ProcessStartInfo(exe, args) {CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden};
            Process.Start(si);
        }
        #endregion

        #region Bindable props
        public ObservableCollection<PowerItem> Items
        {
            get { return PowerItemTree.ItemsRoot; }
        } 

        public MenuItemClickCommand ClickCommand
        {
            get { return _cmd; }
        }
        #endregion

        private void AllItemsMenuRoot_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            ((ContextMenu) Resources["fsMenuItemsContextMenu"]).DataContext = ExtractRelatedPowerItem(e);
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            ExtractRelatedPowerItem(sender).Invoke();
        }

        private void RunAs_Click(object sender, RoutedEventArgs e)
        {
            ExtractRelatedPowerItem(sender).InvokeVerb(API.SEIVerbs.SEV_RunAsAdmin);
        }

        private static PowerItem ExtractRelatedPowerItem(object o)
        {
            var menuItem = o as MenuItem;
            if (menuItem != null)
                return (PowerItem) (menuItem).DataContext;
            if (o is ContextMenuEventArgs)
                return (PowerItem) (((MenuItem)
                         o.GetType()
                             .GetProperty("TargetElement",
                                          BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty)
                             .GetValue(o, null)).DataContext);
            return null;
        }

        private void ShowProperties_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pi = ExtractRelatedPowerItem(sender);
                var info = new API.ShellExecuteInfo
                                {
                                    fMask =
                                        API.SEIFlags.SEE_MASK_INVOKEIDLIST | API.SEIFlags.SEE_MASK_NOCLOSEPROCESS |
                                        API.SEIFlags.SEE_MASK_FLAG_NO_UI | API.SEIFlags.SEE_MASK_NOASYNC,
                                    hwnd = this.GetHandle(),
                                    lpVerb = API.SEIVerbs.SEV_Properties,
                                    lpFile = PowerItemTree.GetResolvedArgument(pi, false),
                                    nShow = API.SWCommands.SW_HIDE
                                };
                var executer = new Util.ShellExecuteHelper(info);
                if (!executer.ShellExecuteOnSTAThread())
                    throw new ExternalException(string.Format(
                        Properties.Resources.ShellExecExErrorFormatString, executer.ErrorCode));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    public class MenuItemClickCommand : ICommand
    {
        public void Execute(object parameter)
        {
            var powerItem = parameter as PowerItem;           //this vvv goes to context menu...
            if (powerItem != null && powerItem.Parent != null /*&& (!powerItem.IsFolder || (Keyboard.Modifiers.HasFlag(ModifierKeys.Control)))*/)
            {
                powerItem.Invoke();
                BtnStck.Instance.Hide();
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}