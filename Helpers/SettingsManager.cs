﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows;
using Power8.Properties;
using Power8.Views;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.MessageBox;

namespace Power8.Helpers
{
    public class SettingsManager
    {
        private SettingsManager(){}

        private static  SettingsManager _inst;
        private static readonly object Sync = new object();
        public static SettingsManager Instance
        {
            get
            {
                lock (Sync)
                {
                    return _inst ?? (_inst = new SettingsManager());
                }
            }
        } //needed to be passedd as Data Context

        public static readonly EventWaitHandle BgrThreadLock = new EventWaitHandle(false, EventResetMode.ManualReset);
        private static bool _blockMetro, _update;
        private static Thread _blockMetroThread, _updateThread;


        public static void Init()
        {
            if (Instance.CheckForUpdatesEnabled)
                UpdateCheckThreadInit();
            if (Instance.BlockMetroEnabled && Util.OsIs.EightOrMore)
                BlockMetroThreadInit(); 
        }
        
        public static void UpdateCheckThreadInit()
        {
            Util.BgrThreadInit(ref _updateThread, UpdateCheckThread, "Update thread");
        }

        private static void UpdateCheckThread()
        {
            BgrThreadLock.WaitOne();

            int cycles = 0;
            var client = new WebClient();
            _update = true;
            while (_update && !MainWindow.ClosedW)
            {
                if (cycles == 0)
                {
                    try
                    {//parsing
                        var info =
                            new System.IO.StringReader(
                                client.DownloadString(NoLoc.Stg_Power8URI + NoLoc.Stg_AssemblyInfoURI));
                        string line, verLine = null, uri7Z = null, uriMsi = null;
                        while ((line = info.ReadLine()) != null)
                        {
                            if (line.StartsWith("[assembly: AssemblyVersion("))
                                verLine = line.Substring(28).TrimEnd(new[] { ']', ')', '"' });
                            else if (line.StartsWith(@"//7zuri="))
                                uri7Z = line.Substring(8);
                            else if (line.StartsWith(@"//msuri="))
                                uriMsi = line.Substring(8);
                        }
                        if (verLine != null)
                        {//updating?
                            if (new Version(verLine) > new Version(Application.ProductVersion) && Settings.Default.IgnoreVer != verLine)
                            {//updating!
                                if (uri7Z == null || uriMsi == null) //old approach
                                {
                                    switch (MessageBox.Show(Resources.CR_UNUpdateAvailableLong + string.Format(
                                                Resources.Str_UpdateAvailableFormat, Application.ProductVersion, verLine),
                                            NoLoc.Stg_AppShortName + Resources.Str_UpdateAvailable,
                                            MessageBoxButton.YesNoCancel, MessageBoxImage.Information))
                                    {
                                        case MessageBoxResult.Cancel:
                                            Settings.Default.IgnoreVer = verLine;
                                            Settings.Default.Save();
                                            break;
                                        case MessageBoxResult.Yes:
                                            Process.Start(NoLoc.Stg_Power8URI);
                                            break;
                                    }
                                }
                                else
                                {
                                    Util.Send(() =>
                                              Util.InstanciateClass(
                                                  t: typeof(UpdateNotifier),
                                                  ctor: () => new UpdateNotifier(
                                                                  Application.ProductVersion, verLine,
                                                                  uri7Z,
                                                                  uriMsi)));
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Resources.Err_CantCheckUpdates + ex.Message,
                                        NoLoc.Stg_AppShortName, MessageBoxButton.OK,
                                        MessageBoxImage.Exclamation);
                    }
                }
                Thread.Sleep(1000);
                cycles++;
                cycles %= 43200;
            }
        }

        public static void BlockMetroThreadInit()
        {
            Util.BgrThreadInit(ref _blockMetroThread, BlockMetroThread, "Block Metro thread");
        }

        private static void BlockMetroThread()
        {
            BgrThreadLock.WaitOne();

            //search for all metro windows (9 on RP)
            var handles = new Dictionary<IntPtr, API.RECT>();
            IntPtr last = IntPtr.Zero, desk = API.GetDesktopWindow();
            do
            {
                var current = API.FindWindowEx(desk, last, API.WndIds.METRO_EDGE_WND, null);
                if (current != IntPtr.Zero && !handles.ContainsKey(current))
                {
                    API.RECT r;
                    API.GetWindowRect(current, out r);
                    handles.Add(current, r);
                    last = current;
                }
                else
                {
                    last = IntPtr.Zero;
                }
            } while (last != IntPtr.Zero);

            _blockMetro = true;
            BgrThreadLock.Reset();//Main Window must not be closed between Reset() and Set()
            while (_blockMetro && !MainWindow.ClosedW) //MAIN CYCLE
            {
                foreach (var wnd in handles)
                    API.MoveWindow(wnd.Key, wnd.Value.Left, wnd.Value.Top, 0, 0, false);
                Thread.Sleep(1000);
            }

            //deinit - restore all window rects
            foreach (var wnd in handles)
                API.MoveWindow(wnd.Key, wnd.Value.Left, wnd.Value.Top,
                               wnd.Value.Right - wnd.Value.Left,
                               wnd.Value.Bottom - wnd.Value.Top, true);
            BgrThreadLock.Set();
        }



        public bool AutoStartEnabled
        {
            get
            {
                var k = Microsoft.Win32.Registry.CurrentUser;
                k = k.OpenSubKey(NoLoc.Stg_RegKeyRun, false);
                return k != null &&
                       string.Equals((string)k.GetValue(NoLoc.Stg_AppShortName),
                                     Application.ExecutablePath,
                                     StringComparison.InvariantCultureIgnoreCase);
            }
            set
            {
                if (value == AutoStartEnabled)
                    return;
                var k = Microsoft.Win32.Registry.CurrentUser;
                k = k.OpenSubKey(NoLoc.Stg_RegKeyRun, true);
                if (k == null)
                    return;
                if (value)
                    k.SetValue(NoLoc.Stg_AppShortName, Application.ExecutablePath);
                else
                    k.DeleteValue(NoLoc.Stg_AppShortName);
                WarnMayHaveChanged(this, null);
            }
        }

        public bool BlockMetroEnabled
        {
            get { return Settings.Default.BlockMetro; }
            set
            {
                if (value == BlockMetroEnabled)
                    return;
                Settings.Default.BlockMetro = value;
                Settings.Default.Save();
                if (value)
                    BlockMetroThreadInit();
                else
                    _blockMetro = false;
            }
        }

        public bool CheckForUpdatesEnabled
        {
            get { return Settings.Default.CheckForUpdates; }
            set
            {
                if (value == CheckForUpdatesEnabled)
                    return;
                Settings.Default.CheckForUpdates = value;
                Settings.Default.Save();
                WarnMayHaveChanged(this, null);
                if (value)
                    UpdateCheckThreadInit();
                else
                    _update = false;
            }
        }
        
        public bool SquareStartButton
        {
            get { return Settings.Default.SquareButton; }
            set
            {
                if(value == SquareStartButton)
                    return;
                Settings.Default.SquareButton = value;
                Settings.Default.Save();
            }
        }

        public bool WatchRemovableDrives
        {
            get { return Settings.Default.WatchRemovables; }
            set
            {
                if (value == WatchRemovableDrives)
                    return;
                Settings.Default.WatchRemovables = value;
                Settings.Default.Save();
                WatchRemovablesChanged(this, null);
            }
        }
        
        public bool ReportBadSettings
        {
            get { return Settings.Default.WarnBadConfig; }
            set
            {
                if (value == ReportBadSettings)
                    return;
                Settings.Default.WarnBadConfig = value;
                Settings.Default.Save();
                WarnMayHaveChanged(this, null);
            }
        }

        public bool ShowWarn
        {
            get { return ReportBadSettings && (!AutoStartEnabled || !CheckForUpdatesEnabled); }
        }


        public static event EventHandler WatchRemovablesChanged;
        public static event EventHandler WarnMayHaveChanged;

    }
}
