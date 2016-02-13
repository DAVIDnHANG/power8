# <font color='red'>WARNING! This project has been migrated to <a href='https://github.com/AgentMC/power8/wiki/Changelog'>GitHub</a> </font> #
## Version 1.5.5 Beta (v.1.5.5.838): 01.12.2014 ##
...continue fixing (around 76% of automatically reported crashes is fixed).

  1. `[changed]` Removed duplicated using in `NetManager`;
  1. `[changed]` Corrected internal file rename handling a bit;
  1. `[fixed-GA]` Fixed argument exception occurring when `FileStream` is trying to wrap around non-overlapped drive handle;
  1. `[fixed-GA]` Catch `ComException` in `MfuList.GetJumpList()` better;
  1. `[fixed-GA]` Probably fixed `InvalidOperationException` "This visual is not connected to presentation source";
  1. `[fixed-GA]` Fixing `IndexOutOfRangeException` in `CommandToFilenameAndArgs()`;
  1. `[fixed-GA]` Catching exceptions (`ArgumentNullException`) when upgrading previous settings;
  1. `[fixed-GA]` Handling `ArgumentException` in `FriendlyName` getter;
  1. `[fixed-GA]` Catch `UnauthorizedAccessException` as one more reason to not to be able to create a process watchdog;
  1. `[fixed-GA]` Fixed `ArgumentException` in processing of file rename operation.

## Version 1.5.4 Beta (v.1.5.4.817): 09.10.2014 ##
This is again bug fixing release (around 60% of automatically reported bugs is fixed), plus couple of important things happened.

  1. `[new]` Windows 10 support, initial version;
  1. `[changed]` Enhanced Windows libraries parsing, should solve certain `ArgumentException`s;
  1. `[fixed]` Fixed Power8 preventing removable drives to be safe-removed. Works for all technically removable drives types. Took 2 years but finally it's done;
  1. `[fixed-GA]` Handle `COMException`s and `ManagementException`s occurring on startup of event watcher;
  1. `[fixed-GA]` Handle `COMException`s and `ManagementException`s occurring in `NetManager`;
  1. `[fixed-GA]` Handle `IOException` occurring in `DriveManager` when network drive is not available any more;
  1. `[fixed-GA]` Handle `IOException` in `ResolveLink` when the lnk file is not found;
  1. `[fixed-GA]` Fixed rare `InvalidOperationException` occurred when event on `WatchDog` arrives after the watchdog is stopped actually;
  1. `[fixed-GA]` Fixed `InvalidOperationException` in `MfuList.UpdateStartMfuSync():348`;
  1. `[fixed-GA]` Added lightweight synchronization between `SearcStartMenuSyncFast` and filesystems watchers actions. Solves rare `InvalidOperationException`.

## Version 1.5.3 Beta (v.1.5.3.796): 11.07.2014 ##
...After all the preparations the bugs destruction actually begins! According to Google Analytics, 75% to 95% of errors you may encounter is fixed in this release. Next the work will be continued on hardening the application and making it even more stable. Items marked as "`fixed-GA`" were reported automatically through Google Analytics and automated exception reporting subsystem!

  1. `[changed]` Speed up exit of Power8.;
  1. `[fixed]` Rare impossibility to exit when another application is being installed in the system;
  1. `[fixed]` `SecurityException` when there's no default "Application Error" log in the system;
  1. `[fixed-GA]` Various `COMException`s occurring when Power8 is exiting;
  1. `[fixed-GA]` `Win32Exception` occurring when Power8 tries to restart. The application won't crash anymore but additional tracing is now in place to fix the root of problem as well;
  1. `[fixed-GA]` `ArgumentNullException` occurring in `Power8.PowerItemTree.ScanFolderSync` when a Windows library is detected with itemnot preprocedd by system yet;
  1. `[fixed-GA]` `ArgumentNullException` occurring in `DataGrid.ScrollIntoView` when pressing Up or Down keys in search results view when no results are found;
  1. `[fixed-GA]` `InvalidOperationException` occurring in `MfuList` sometimes. At least I hope it's fixed because it wasn't clear how the issue happens;
  1. `[fixed-GA]` `PathTooLongException` occurring in `Power8.PowerItemTree.FileRenamed` under undetermined circumstances;
  1. `[fixed-GA]` `ApplicationException` occurring in Drive Manager when a .Net `FileSystemWatcher`-incompatible drive exists in the system;
  1. `[fixed-GA]` `ArgumentException` occurring in various places under `Power8.PowerItemTree.ScanFolderSync` and related probably to drives with .Net-incompatible filesystem attached to PC. The application won't crash anymore but additional tracing is now in place to fix the root of problem as well.

## Version 1.5.2 Beta<sup>Quick-Fix</sup> (v.1.5.2.777): 08.07.2014 ##

  1. `[changed]` Updated localizations: HU, KO, CS;
  1. `[fixed]` Fixed concurrent IO preventing proper new style exceptions events reporting.

## Version 1.5.1 Beta (v.1.5.1.766): 07.07.2014 ##

  1. `[new]` Exceptions on start of application are handled differently, allowing user to prevent endless restarting loop;
  1. `[new]` Other instances of Power8 are killed on startup of new one;
  1. `[new]` Added UI checkbox for "Don't free libraries" hack;
  1. `[changed]` Analytics: Extended exceptions logging for crashes;
  1. `[changed]` Analytics: Report current UI language;
  1. `[fixed]` Empty system variables names handling;
  1. `[fixed]` Absolute path used for Rundll32 in Lock command;
  1. `[fixed]` Possibly fixing `FormatException` in `MfuList`.


## Version 1.5.0 RTM (v.1.5.0.744): 08.06.2014 ##

  1. `[new]` Korean localization;
  1. `[new]` Setting for stretching image on Main button in different ways;
  1. `[new]` Setting to disable auto-corner feature (when setting is on, Main window aka Button-stack is always shown near Main button when Alt+Z is pressed);
  1. `[new]` Settings to enable/disable confirmation and forcing of Power actions (shutdown, restart...);
  1. `[new]` Setting to display Start Menu in more compact way;
  1. `[new]` Now also unhandled exceptions are sent to Google Analytics;
  1. `[new]` Added information to About dialog on the originating country of Power8;
  1. `[removed]` Ukrainian translation. We need someone with UK Windows MUI running it on daily basis. Otherwise quality of translation will suffer;
  1. `[changed]` Returned Russian translation to the MSI. The integrity of layout is more important than filthy souls of some Russian people;
  1. `[fixed]` New items weren't put under Start Menu when they're originated from the User's start menu under Win8;

## Version 1.4.6 Beta (v.1.4.6.692): 28.03.2014 ##

  1. `[new]` Romanian and Ukrainian translation;
  1. `[new]` Ctrl+Tab sends the selected item's path to the search bar when it or Recent list is in focus;
  1. `[new]` Support for launching `ModernUI` apps when link is available (e.g. `PhotoApp` in Start Menu);
  1. `[removed]` Russian translation from MSI. It will only be available through 7Zip archive;
  1. `[changed]` Fine-tuned the Recent list display so that it doesn't use localized names for links from Start Menu as `FriendlyName` hints in case they contain additional arguments. This e.g. caused MMC.exe to be named "SQL server configuration tool" and CMD.exe to be named "Visual studio command line tool";
  1. `[fixed]` Opposite side of system `ReBar` moving out of view under W7<sup>classic</sup> in case Configure Start Button is on;
  1. `[fixed]` Fixed launching RAD Studio 2009 - XE3 from Power8. Fix may also influence other problems end-user might experience with other software;
  1. `[fixed]` `Power8` exiting without any other actions after "Download and Update" button in case the update can be discovered but cannot be downloaded;
  1. `[fixed]` Some logging code (doesn't affect end-users);
  1. `[fixed]` Exception preventing reporting Analytics events on 1st launch.


## Version 1.4.5 Beta (v.1.4.5.666): 03.02.2014 ##

  1. `[new]` Serbian, Croatian and Czech localization;
  1. `[new]` Hack against doubling icons in Control Panel menu-button under Windows 8.1, see DuplicatedIconsHack for details;
  1. `[new]` Key X is now used to expand/collapse current search group;
  1. `[new]` Power8 now watches environment variables changes and propagates them to child processes on launch;
  1. `[new]` Instead of deprecated Downloads page, Power8 uses Google analytics to track downloads and launches;
  1. `[changed]` Most operations are moved to thread pool. This doesn't make them faster but Power8's should impact system load less;
  1. `[changed]` Icon extraction is making even less influence on the application performance;
  1. `[changed]` Update Notification dialog: progress bar is shown only when download started;
  1. `[fixed]` Search returning unexpectedly big amount of results;
  1. `[fixed]` Format of logging;
  1. `[fixed]` `IndexOutOfRangeException` occurring when pressing P in search results and item selected is not from Recent applications list;
  1. `[fixed]` `InvalidOperationException` after Alt+Z being pressed before launch-time initialization is finished;
  1. `[fixed]` `InvalidOperationException` when the process is launched on Enter key faster than search finishes;
  1. `[fixed]` Update Notification dialog was not auto-sizable, and layout of buttons was broken;
  1. `[fixed]` Main button's context menu and tooltip layout on Windows7 with Aero disabled (they were partially hidden by toolbar; this doesn't fix that the button itself is hidden by Start button on W7<sup>classic</sup> by default).

## Version 1.4.4 Beta (v.1.4.4.628): 12.09.2013 ##

  1. `[new]` Arabic localization;
  1. `[changed]` Enhanced error handling. Now we get more information in case somethin goes wrong;

## Version 1.4.3 Beta (v.1.4.3.619): 14.07.2013 ##

  1. `[new]` Windows 8.1 Preview support including, but not limited to:
    * hiding of MS start button when P8 works;
    * P8's main button has minimum size now equal to 15 px (width of `ShowDesktop` button on W8);
    * incorrect taskbar buttons positioning on exit;
  1. `[new]` Option to exchange the Start Menu with Search bar when taskbar is horizontal at the bottom of the screen. Benefit is that you have to less draw mouse from Power8 main button to Start Menu;
  1. `[new]` Simplified Chinese localization;
  1. `[changed]` Updated translations for all except de, es, fr, zh-TW;
  1. `[fixed]` Invalid focus after double Alt+Z;
  1. `[fixed]` Display of certain localized CPL items under non-Unicode environment (proper version of `LoadString()` used);
  1. `[unconfirmed fix]` [Issue19](https://code.google.com/p/power8/issues/detail?id=19): no feedback from issue reporter, but I hope the bug is fixed now. `NullReferenceException` when Admin Tools folder cannot be inferred from Start Menu;

## Version 1.4.2 Beta (v.1.4.2.599): 01.05.2013 ##

  1. `[new]` Complete key handling for recent list (P to (un-)pin an item, Right / Left arrow opens jump list; Recent list must be focused for these keys to operate). Now really all features of Power8 can be accessed without using of mouse;
  1. `[changed]` Enhanced performance of file system event watching (moved FS watching to deferred processing in dedicated thread);
  1. `[changed]` Replaced Main button logo again. No re-use of MS logo now;
  1. `[fixed]` Random exceptions in Recent list when you select items with mouse;
  1. `[fixed]` Random issue occuring when you try to launch an application via Recent list, and another app is launched instead;
  1. `[fixed]` Exception in `MfuList` in case object added to custom list earlier was deleted from system;
  1. `[fixed]` Exception in `MfuList` in case link object added to custom list earlier was corrupted (reported by Maxim Orlov);
  1. `[fixed]` Exception on `WindowsXP` on shutdown of Power8 (processes event watcher COM object was created in wrong thread);
  1. `[fixed]` Exception in `DriveManager` if network share becomes unavailable under certain (domain related) circumstances (reported by Brian Taylor);
  1. `[fixed]` Warning sign not disappearing after "Check for updates" was unchecked;
  1. `[fixed]` Exclusions list (settings window) might be too high after a lot of items are added to exclusions;
  1. `[fixed]` Issue occurring when a link under Start Menu folder is being changed, and an item in Recent list exists that takes the name of a link as Friendly Name to display, AND in case this change might influence the item's representation - this information wasn't stored to the link object, and thus required Power8 to restart to apply required representation changes;

## Version 1.4.1 Beta (v.1.4.1.569): 14.03.2013 ##

  1. `[new]` New settings hack implemented to provide fix to users of Windows7 x86 where some unexpected component exists which prevents Power8 from working in a normal way (see Windows7ExceptionHack);
  1. `[changed]` Colors on Power8 button were changed to be not like Microsoft logo which is a TM;
  1. `[changed]` Updated and synchronized localizations for  ES, FI, HU, IT, SV, PT, NL;
  1. `[changed]` Switch User button will be hidden on OS that don't support it natively (i.e. Windows 8 "home");
  1. `[changed]` Corrected layout of button stack a bit. Now all items in grid have the same height and text is centered vertically;
  1. `[fixed]` Fixed rare exception after frequently used object is removed from system;
  1. `[fixed]` Fixed WMI event watcher not being freed on P8 shutdown;
  1. `[fixed]` Fixed Invalid Operation Exception that occurred in rare cases when system was recovering after sleep;

## Version 1.4 Beta (v.1.4.0.555): 19.12.2012 ##

  1. `[new]` Drag&Drop in User-configurable MFU list. Drag any file, link or folder onto Power8 button and it will appear on Custom launch List;
  1. `[new]` "Switch User" command;
  1. `[new]` Flexible updater:
    * no more annoying message boxes on system startup;
    * updater tries to reach server three times with different wait periods until gives up;
    * when updater gives up - it shows warn sign on Power8 button just like for invalid settings, and adds corresponding text to the tooltip;
    * last but not the least: updater switched to the scheduling from timer, so now if you turn on your PC after 12 hours of sleeping, updater will try to check for updates immediately, and not in some hours as before.
  1. `[new]` Option to switch between Control panel and "All control panel items" to show when you click "Control panel" button in Power8 window;
  1. `[changed]` Donation information stripped away from About dialog, a corresponding menu item added (hideable via settings);
  1. `[changed]` Updated ES localization up to 1.3;

## Version 1.3 Beta (v.1.3.0.524): 26.11.2012 ##

  1. `[new]` Hungarian translation;
  1. `[new]` French translation;
  1. `[new]` 2 new modes for launch list (changeable via settings dialog):
    * power8-data-based (applications / links only);
    * user-configurable (applications / links / files / folders / Control Panel elements; order by CTRL+Up/Down);
  1. `[changed]` Now Power8 supports Windows display font scaling - 125%, 150%, etc.;
  1. `[fixed]` Windows 8: taskbar state is now restored when Power8 exits;
  1. `[fixed]` Control Panel display crashed because of Connexant Audio on Compaq C700;
  1. `[fixed]` Deadlock occurring when drive is added to the system (e.g. flash drive);
  1. `[fixed]` Invalid context menu placement in top-left corner when taskbar window is hidden;
  1. `[fixed]` Typo in Ru-translation (in settings dialog);
  1. `[fixed]` Search marker (text "Searching...") appearing sometimes when you open main window;
  1. `[fixed]` Icon extraction for files with Cyrillic chars in path on OS with 1251 default ANSI codepage;


## Version 1.2 Hotfix 1 Beta (v.1.2.1.0): 31.10.2012 ##

  1. `[new]` Portuguese translation (fits both European and Brazilian);
  1. `[new]` Turkish translation;
  1. `[new]` Chinese (Taiwan) translation;
  1. `[changed]` Updated Spanish localization;
  1. `[fixed]` Error preventing Power8 from starting up on systems with outdated network connections, i.e. the network drives that utilizes connection that cannot be restored, or with drives completely encrypted by `TrueCrypt`.


## Version 1.2 Beta (v.1.2.0.0): 22.10.2012 ##

  1. `[new]` Finnish translation;
  1. `[new]` Project donation info;
  1. `[new]` Settings window updated:
    * Settings for menu-buttons visibility (label is system name);
    * Ability to switch auto-sorting on;
    * Configurable name for "All programs" item;
    * Editable search providers;
    * Ability to auto-restart application when fatal error occurs;
  1. `[changed]` Saving more resources resolving links;
  1. `[changed]` Enhanced UI a bit;
  1. `[changed]` Limited Jump-List items count to 25;
  1. `[fixed]` Update notification window _may_ not display version strings;
  1. `[fixed]` 7/8: Data grid icons and text are blurred though sizes of blocks are ok;
  1. `[fixed]` 7<sup>classic</sup>: button is unreachable (almost) => resolved as config setting;
  1. `[fixed]` issue preventing Power8 from showing the start menu when corrupted link exist;
  1. `[fixed]` the selectedItem may not have been changed until user presses enter (UI faster than data layer).



## Version 1.1 Beta (v.1.1.0.0): 08.10.2012 ##

  1. `[new]` Spanish localization;
  1. `[new]` Automatic notification if Autostart or Autoupdate features are turned off;
  1. `[new]` Settings window with:
    * All checkboxes from Start button context menu;
    * Ability to set Start button size, layout and picture (not supported on XP);
    * Ability to switch off the monitoring of removable drives and thus be able to safe-eject them;
    * Ability to switch off the auto-notifier described above;
  1. `[changed]` Small speedup for search;
  1. `[changed]` Considerable speedup for displaying window for the 1st time;
  1. `[changed]` MFU list now will show even less duplicates than before;
  1. `[changed]` Visual Studio launcher is filtered out from MFU list;
  1. `[fixed]` Issue when user cannot search Control panel item by camels (e.g. "paf" searched now results in "Programs and Features");
  1. `[fixed]` Invalid context menu position over main button (problem when it becomes hidden below the taskbar);
  1. `[fixed]` Random error "E\_SHAREVIOLATION" when trying to open the button stack;


## Version 1.0 Hotfix 2 (v.1.0.2.0): 05.09.2012 ##

  1. `[new]` Dutch localization;
  1. `[new]` Italian localization;
  1. `[changed]` Now we won't add entries to P8's own Jump List if the parent process of the launched one is started not by our user;
  1. `[changed]` From now on, Welcome arrow will be hidden as only user moves the mouse over the main button;
  1. `[changed]` Now all localizations are inside single file;
  1. `[fixed]` Fixed bug when trying to open folder for deleted item when it was previously put to Jump Lists:
    * now we filter out these files also from P8's Jumo Lists;
    * the exception is handled in the menu item click handler as well;
  1. `[fixed]` Couple of bugs in Pin/Unpin button:
    * `ArgumentOutOfRange` exception when unpinning old items that would normally be filtered out as obsolete;
    * Now we handle exception if the (un)pinned item is not available at the moment of (un)pinning;
    * Now the pin icon will be shown for MFU children only, preventing user from trying to pin the unpinnable stuff;
  1. `[fixed]` Under extremely rare conditions, when an FS event for the folder comes at the same time with whatever way called Items evaluation for the same folder, two threads may reside at `AddSubItem()` at the same time. And if 1st thread's Send() will be executed in parallel with 2nd thread's `FirstOrDefault` -> here is `InvalidOperationException` thrown. Fixed now.


## Version 1.0 Hotfix 1 (v.1.0.1.0): 04.08.2012 ##

  1. `[new]` German localization;
  1. `[fixed]` If you leave Power8 running for weekend and we will issue a new version this time, only one Update Notification window will appear (previously: 4-5);
  1. `[fixed]` Exception in file system events handling when Power8 may unexpectedly crash when you work with network files or run an installer;
  1. `[fixed]` XP: certain windows were not re-shown when expected;
  1. `[fixed]` CTRL+Click on Main button will now always show Run dialog;
  1. `[fixed]` 1 line in RU localization;
  1. `[fixed]` W7: Power8 might crash when you just started it and switch from classic theme to Aero and vice-versa;
  1. `[fixed]` W7: no black background when switch from classic theme to Aero and vice-versa;

## Release 1.0 (v.1.0.0.0): 21.07.2012 ##

  1. `[new]` About window;
  1. `[new]` Icon and logo;
  1. `[fixed]` Now Power8 is able to start up and work even if Workstation service is shut down;


## RC 1 (v.0.6.0.0): 14.07.2012 ##

  1. `[new]` Added pinning in MFU list;
  1. `[new]` Now search results are automatically expanded for groups that contain less than 20 items (performance considerations);
  1. `[new]` Added Russian and Swedish localization (Se loc -> thanks Åke Engelbrektson);
  1. `[changed]` When pressing Esc in empty search bar - it will close button stack (if search bar is not empty - it will clear text);
  1. `[changed]` Issue "Internal search should return results "`TestApp.exe`" and "`Test App.exe`" for "ta" query";
  1. `[changed]` Minor speed enhancements in core;
  1. `[changed]` Partially imported patch to Api usages. Should increase stability in specific cases. Thanks goes to SSTREGG;
  1. `[changed]` Show welcome arrow only after button stack is instantiated;
  1. `[changed]` Run dialog doesn't block Explorer anymore;
  1. `[changed]` Enhanced default grid layout on XP and 7;
  1. `[fixed]` Exception when file is not found for MFU element;
  1. `[fixed]` Race condition that led to that folder items may display simple icons instead of customized ones;
  1. `[fixed]` Possible `InvalidOperationException` that might be side cause for the problem above;


## Beta 1 Hotfix 1 (v.0.5.1.0): 06.07.2012 ##

  1. `[changed]` Speedup in displaying of icons;
  1. `[fixed]` Exception when a program was launched in a system with semicolon in command line;
  1. `[fixed]` Exception when a program was launched in a system with no command line and WMI reported it without quotes;
  1. `[fixed]` Potential exception that may be result of race condition;


## Beta 1 (v.0.5.0.0): 04.07.2012 ##

  1. `[new]` Added support for Windows MFU list (main start menu list contents);
  1. `[new]` Added support for Windows Jump lists (main start menu list element). Along with Windows system API Power8 uses internal implementation, so Jump Lists works even on XP;
  1. `[new]` Welcome arrow appears on 1st launch to help user begin working with Power8;
  1. `[new]` Added option to block metro screen corner rectangles;
  1. `[new]` Cursor over main button now indicates that load is completed;
  1. `[changed]` Enhanced error handling. If error happens now, 90% that it will be shown to user, and then written to log;
  1. `[changed]` Hack-fixed initial layout of grid columns on .Net 4.0. Search something to get proper layout;
  1. `[changed]` Main button redrawn to display with Windows colors;
  1. `[fixed]` Doubling of links in All Programs in rare cases;
  1. `[fixed]` Visual state for pressed buttons;
  1. `[fixed]` Focus when `ButtonStack` is shown;
  1. `[fixed]` `ButtonStack` won't be instantiated twice now;
  1. `[fixed]` Invalid declaration and call for `ShGetSpecialFolderPath()`;


## Alpha 4 (v.0.4.0.0): 11.06.2012 ##

  1. `[new]` Added search functionality. 3 new ways to search, see details in [FeatureDetails](FeatureDetails.md) page;
  1. `[new]` When Aero is off / on XP / on High Contrast theme - now we look bit better (no more boring black);
  1. `[changed]` Icons in menu items under Windows 8 Release preview now placed properly;
  1. `[fixed]` Log Off command now works as expected;
  1. `[fixed]` Problems with "Show more" network item (visible if you have 11+ PCs on network);


## Alpha 3 Release 2 (v.0.3.5.0): 27.05.2012 ##

  1. `[new]` Added support for removable and ram drives. P8 will add new drives in list when they're available and remove them when they're disconnected;
  1. `[new]` MSI installer created. From now on you can install/update Power8 using MSI or still use 7z archive format;
  1. `[new]` Auto-update implemented. Update dialog added. For future versions, MSI auto-update is available;
  1. `[changed]` Enhanced menus internal structure:
    * less memory consumption (theoretically :) ),
    * fixes disappearing icons for Administrative tools, Network connections, etc.,
    * allows to make "Start menu" text readable even on dark backgrounds;
  1. `[changed]` Polished the look. Styles contain tons of enhancements;
  1. `[changed]` Added drive labels to Computer sub-items;
  1. `[changed]` "Open container" and "Show Properties" can be called for all file system items Power8 can resolve/detect;
  1. `[fixed]` "Open" and "Open all users folder" doesn't work for Start menu root;
  1. `[fixed]` "Open all users folder" should be enabled for Start menu only;
  1. `[fixed]` Exception that occurred when user manually checked "Check for updates" Off and then back On.


## Alpha 3 Hotfix 2 (v.0.3.2.0): 21.05.2012 ##

  1. `[new]` Settings are preserved and upgraded from previous version;
  1. `[changed]` Enhanced and speed-up icons extraction:
    * fixes slow expanding C:\Windows\Fonts,
    * fixes 1 core loaded 100% on x86 systems in some cases;
  1. `[changed]` Enhanced detection of is "Auto Start" on or off;
  1. `[fixed]` Startup failing on systems with specific Control Panel elements, specifically C-Media CPL (C-Media products, ASUS Xonar, and many others);
  1. `[fixed]` Display of Separators in menus (Control Panel, Network items);
  1. `[fixed]` Libraries fixes:
    * now detecting ".library-ms" case-insensitive,
    * won't parse malformed XML and not crash (W8 x86 Pictures problem),
    * skip "shell:" commands inside library - means library has not yet been processed by the system;
  1. `[fixed]` Startup synchronization issue: Power8 wouldn't check for updates on startup even if it is set in configuration. Uncheck and check back again was required to make it work.


## Alpha 3 Hotfix 1 (v.0.3.1.0): 15.05.2012 ##

  1. `[changed]` A message will be shown to user if unhandled exception occurs;
  1. `[fixed]` Startup failing on systems with Floppy drives;


## Alpha 3 (v.0.3.0.0): 14.05.2012 ##

  1. `[new]` Significant speedup in displaying menus, including start menu;
  1. `[new]` Sorting for menu items;
  1. `[new]` Added Run... button, also "Run" dialog is displayed when CTRL+Click on main Power8 button;
  1. `[new]` Added Computer menu-button (see Feature Details), having fixed, ram or network drives as it's children;
  1. `[new]` Added Administrative Tools menu-button, duplicating corresponding Start menu location;
  1. `[new]` Added Libraries menu-button;
  1. `[new]` Added Control Panel menu-button
    * on 7/8 it shows main CPL view, and subitem "All CPL items" shows all items view;
    * only All CPL Items view is available on XP;
  1. `[new]` Added Network menu-button, with children:
    * Current workgroup/domain link;
    * Network connections
    * List of computers around;
  1. `[changed]` Now Start Menu window is shown in the screen corner closest to mouse pointer;
  1. `[changed]` Now "Startup" and "startup" are joined in Start Menu because this is the way Windows does;
  1. `[fixed]` Incorrect window positioning when "Hide taskbar" checkbox is on;
  1. `[fixed]` Prohibited startup on Vista since it's not supported;
  1. `[fixed]` Crash when Check-for-updates is on and no network is available;
  1. `[fixed]` Crashes related to simultaneous multiple file operations, like when installers generate Start menu links;
  1. `[fixed]` Now the message is shown when error occurs on item click or context menu item select;


## Alpha 2 (v.0.2.0.0): 08.04.2012 ##

  1. `[new]` Auto-update checker working (checks for new version once a 12 hours);
  1. `[new]` Added context menu for "All Programs" and all it's child items:
    * Run / Run as Administrator;
    * Open folder / Open link target's folder;
    * Show properties / Show link target's properties.
  1. `[new]` Made Power8 work on Windows XP;
  1. `[new]` Added a window that will assist user in case explorer.exe is closed;
  1. `[new]` Power8 can be activated by Alt+Z hot key (original idea was Win+Z, but Win8 prevents Win+`*` hotkeys from being registered);
  1. `[changed]` Labels on menu items are resolved more correct now using system-provided resources;
  1. `[changed]` Buttons and menus restyled.


## Alpha 1 (v.0.1.0.0): 24.03.2012 ##

(all below is `[new]`)
  1. Launches :) and positions itself in the Taskbar opposite to Show Desktop button;
  1. Styled similar to Show Desktop button (as in Developer Preview);
  1. Power and session features:
    * Shutdown;
    * Sleep;
    * Hibernate;
    * Restart;
    * Log off;
    * Lock screen (start screensaver);
    * Lock Windows;
  1. Displays expanding "All Programs" menu as it was back in old good XP time:
    * With real icons;
    * Click to launch item;
  1. On main button right-click:
    * Allows to toggle auto-start;
    * Allows to exit.