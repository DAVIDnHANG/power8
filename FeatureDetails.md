# <font color='red'>WARNING! This project has been migrated to <a href='https://github.com/AgentMC/power8/wiki/FeatureDetails'>GitHub</a> </font> #
# Specific features of Power8 described in details #

## Check-for-update ##

This feature checks for new version. When you check the corresponding menu item in context menu of Power8 button, the check begins the same moment. The check also starts when Power8 is launched if this setting was set previously.

After that, the check occurs every 12 hours.

Each check downloads 2.26 KB file named `"AssemblyInfo.cs"` from the project source code and uses it to identify the version.

At the moment, when version is found, there are 2 possibilities. If update files are available, the update dialog will show up.

![http://power8.googlecode.com/svn/wiki/Power8New04.png](http://power8.googlecode.com/svn/wiki/Power8New04.png)

In this window, "Download and Update" means Power8 will download the current MSI package (download progress will be shown in progress bar), launch it and exit. At the moment it is not a silent install, you'll have to go through all the steps, though previous version will be removed automatically by installer. In future this may be changed, and silent install will be applied.

Also, when choosing this option, the path to currently run Power8 copy will be passed to installer. This means, if you have 2 instances of P8 on PC, location1 is where P8 is installed, and you unpacked P8 to location2, and launched unpacked version, and the unpacked version triggers the update - the installed version will be removed, and P8 will suggest to install into location2. It is possible to change the default location, of course.

"Download MSI" and "Download 7z" will put corresponding update packages to where you define, and navigate the system to this location.

When any of update files is not available, the simplified message will be displayed<br />![https://power8.googlecode.com/svn/wiki/Power8_401_5_UpdateMsg.png](https://power8.googlecode.com/svn/wiki/Power8_401_5_UpdateMsg.png)

This behavior is a subject to change in future.

## Alt+Z hotkey ##

Power8 uses Alt+Z hotkey to show Start Window, like Windows itself reacts on "Windows" key.

The idea originally was to use "Win+Z" hotkey, but starting Windows8, Win+**combinations are prohibited.**

When you press Alt+Z, Power8 determines the location of the Mouse cursor and shows the window in the closest desktop corner possible.

Pressing Alt+Z again will close the window.

Starting from 1.5 the behavior of the feature may change depending on configuration. See [below](https://code.google.com/p/power8/w/edit.do#1.5:_New_settings_on_General_tab).

## Menu buttons ##

![https://power8.googlecode.com/svn/wiki/Power8_401_6_MenuBtns.png](https://power8.googlecode.com/svn/wiki/Power8_401_6_MenuBtns.png)

All 5 menu buttons have submenus that contain items.

For Computer and Libraries (Documents on XP) the items are read and expanded only on demand (when you hover the parent menu item with mouse).

Computer, Libraries and Administrative tools are updated automatically when a file system change occurs and this or parent item was already extracted/shown to the user.

Network and Control panel items aren't refreshed. Restart Power8 when you installed new control panel element or changed network location if needed.

All menu items have a context menu that will allow you to Open item, show it's Properties and so on.

## Computers List ##

![https://power8.googlecode.com/svn/wiki/Power8_401_7_CompList.png](https://power8.googlecode.com/svn/wiki/Power8_401_7_CompList.png)

When there are more than 10 computers over network available (like if you're in Enterprize-size domain), only 1st ten entries will be shown. All others are accessible via "Computers List" window, that is shown when you click "Show more..." menu item.

This window allows you to quickly search for required computer and open it by double-clicking the entry. Note that when computer is unreachable, "My Documents" window may be opened, or an error message may be shown.

It is planned that there will be a specific configurable context menu with items such as "Start Remote Desktop here" and similar. Fell free to post suggestions for the out-of-box preconfigured items.

## Search ##

![https://power8.googlecode.com/svn/wiki/Power8_401_8_Search.png](https://power8.googlecode.com/svn/wiki/Power8_401_8_Search.png)

There are 3 ways to search using Power8.

### Internal search ###
This is the search over everything known to Power8 itself:
  * Start menu;
  * Items displayed in Computer or Documents menu-butons;
  * Control panel elements;
  * Network neighborhood;
  * MFU list (recently launched applications);
  * (also, Jump lists search will be probably implemented later).

Minimum search length for this search is 2 characters, so "no" will already bring you Notepad up. Query string is being looked for in elements' path, description or target path if current element is a Link.
This search is immediate. Found elements are grouped according to item under which they were found. Example of the internal search is on screenshot above.

Starting from 1.0-1.1 the Internal search works in 2 modes in parallel:
  * raw search - as described above, "no" will bring you the "notepad";
  * camel search - much more complicated way to search your computer. It searches specific strings constructed from certain characters from the item's title, description and so on. It's simpler to show some examples:
    * "paf" will bring you "Programs and Features";
    * "pvz" will bring you "Plants vs. Zombies";
    * "nfs" will bring you... yes, the `NeedForSpeed` or something in it's folder.

### Windows Search ###
This search type uses Windows Search engine and can be launched along with internal search. However, to run it, you must have Windows Search enabled on your PC. It is done on W7/W8 by default, but can be switched off. In this case there will be no search results using this search.

Windows Search is used to search system-known FILE elements, with your query as both:
  * Full-text search (Caption/Header/Title **and** content of documents);
  * Wildcard search over files' names.
Note that unlike Internal Search, your query is checked with file **names** only while using Windows Search (to make it faster).

Minimum search length of query text is 3 characters, however since it is full-text search, you may prefer using somewhat longer queries for it. Compared with W7 Search window, Power8's queries to Windows Search service provide more results than in W7 Start Menu and less results than in Search system window. This search is deferred: when you type a query, it will start only when no key is pressed during 2/3 of second.

By default, Power8 will display only top 50 unique (on the file path level) results of top 100 returned by Windows search. When checking uniqueness, internally returned results are also taken into account.

You can also limit the search results to specific file extension. The format of such query is "extension|query text". When Power8 detects a separator ("|") in a query, only Windows Search occurs, you'll receive no Internal Search results.

The rule about 3 search text chars is still valid for Limited Windows Search, thus the search won't occur for query "mp3|wh".

### Internet search ###
This is completely different search type. No results will be produced in P8 window, instead you use it like a shortcut to your favorite search engines.

The format of query is "key query" (with space inside), where key is 1 character (case sensitive, "a" not equal to "A") from the table below, and query is your search string. Starting from 1.2 you can change these search providers using corresponding tab in Settings dialog (see below). By default, the following list is provided:
|b|Bing|
|:|:---|
|d|Baidu|
|g|Google.com (https)|
|w|Wikipedia (english)|
|y|Yandex.com|
|в|Wikipedia (русский)|
|г|Google.ru (https)|
|я|Яndex.ru|

This search is not even deferred - it's manual. When you press enter, the default system browser will be launched to show you the results of the search query using the site chosen.

## Recent Applications (MFU List) ##

Each time main P8 window (aka "Button-Stack") is opened, Power8 reads system-managed lists of recently launched applications and displays it. P8 uses cache inside, so this does not impact the performance.

Elements of MFU list pass through a number of filters, including ones defined by Microsoft, internal P8 filters, stripping away network files, and links approximization. Last one is process where from 2 different links pointing to same EXE and this EXE itself we construct one resulting element. However this is not precise process since some applications (like MS Office) use launchers/guids to launch instead of simple EXE targets. It will be enhanced in future.

When displayed, all items are sorted by launch count (keep in mind, Windows resets this value from time to time) and then by launch date, keeping most popular/most recent at the top. For items that has launch count of 0 (e.g. when launched not by Windows, or after Windows had reset the counter), only latest 20 are shown to make list display faster.

Names of elements are returned using complex algorythm:
  * first, we try to find corresponding element in All Programs list;
  * if this fails, we extract file information and display file Description of Product Name;
  * finally, if none of above is available, file name or link title is shown.

The elements in MFU list can be pinned, which means they'll always appear at the top of the MFU list. Elements can be pinned even if they're shown in Internal Search results. However this relates and will suceed only to MFU elements, and not other ones like Start menu entry, Windows search item and so on.

## Jump Lists ##

Power8 displays 3 sources of JL in one menu:
  * system Recent list;
  * system Frequent list;
  * P8 internal JL manager data (this is the only source of Jump List data for WinXP).

There's no official way to get jump list for any desired application, so some of jump lists you can see in Windows may not be shown in Power8. And vice-versa. For example, seems Notepad is identified by it's window, not by exe file or link - so we can't show jump list for it.

However we display JL for applications that follow MS's guidelines and add required data to their launch shortcuts. For example, Remote desktop connection, Visual Studio, etc.

There are 2 kinds of Jump List elements:
  * file;
  * command.

Jump list element is treated as file if it exists locally on your disc. Commands are all the others (command line parameters, web addresses, ...). Command will be always launched with application, jump list of which it is located in. File, however, will be treated as usual, and opened in default associated system application.

## Settings window ##

Note that all your changes done in this window become effective immediately, you don't need to click OK to apply them!

### 1.1+: General tab ###

The new Settings window is available starting Power8 v.1.1. Right-click Start button, snd choose "Settings" to open the window.

![https://power8.googlecode.com/svn/wiki/Power8_401_9_Settings.png](https://power8.googlecode.com/svn/wiki/Power8_401_9_Settings.png)

The window has the following options:
  * Auto-Start/Check for updates/Block Metro (Win8 only) - duplicate corresponding context menu items of Start button;
  * Watch removable drives - allows you to make Power8 bypass the removable drives when listening to changes in the file system. This will allow you to safe-eject the removable drive, but also will eliminate the drive from Power8's computer menu-button's children. When switched on, this setting prevents removable devices to be ejected. So to eject these devices - switch it off. You can switch it on back after ejecting the device;
  * Auto-sort menus and lists... will sort Start menu and Computer's children items when new file or folder appeas in the system. Default is unchecked which helps you to identify that new files or folders were created during curent session;
  * Restart application when fatal error occurs - when Power8 faces unrecoverable error it will automatically restore itself;
  * Exchange All Programs and Search bar for better usability - starting from 1.4.3, you can use this option to add a bit of AI to Power8. That is, when it detects that it's running inside horizontal taskbar which is at the bottom of the screen, it automatically exchanges 2 mentioned controls to make you be able to access Start menu faster and move mouse less after clicking the main Power8 button:
![http://power8.googlecode.com/svn/wiki/Power8_413_0_ExApSeBar.png](http://power8.googlecode.com/svn/wiki/Power8_413_0_ExApSeBar.png)
  * Configure Start button (Win7+). Allows you to configure layout and look of the Start button to adjust it for your needs:
    * Aspect ratio sets the size of Start button;
    * Follow taskbar orientation will invert the Aspect Ratio when taskbar is located horizontally;
    * Select image allows you to select png/jpeg/gif/tiff image to put on the Start button instead of Windows rectangle;
      * You can doubleclick the textbox to clear its contents;
  * All programs text - sets text of Start Menu;
  * Inform me about configuration changes will, when turned on:
    * Mark Auto-Start and Auto-update options with Red color if they are unchecked;
    * Display warning sign and a hint over the Start button:
![https://power8.googlecode.com/svn/wiki/Power8_401_10_NotifyMark.png](https://power8.googlecode.com/svn/wiki/Power8_401_10_NotifyMark.png)
  * Show Donate menu item - allows you to hide "Donate" menu item which appears in Main button context menu in case you don't want to support the developers team;

### 1.5: New settings on General tab ###

As of 1.5, several new settings were added to General tab:
  * Show Main window close to Mouse after Alt+Z: when corresponding key combination is pressed and this setting is switched on, the Main window will be displayed not near the mouse pointer as it was before but in the corner occupied by Power8 button;
  * Confirm and/or Force power actions. By default (and previously) when user presses power button - Shutdown, Sleep, etc. - this action invoked in Forced mode and without any confirmation, immediately. New settings allow user to alternate this behavior;
  * Stretch Image parameter of Configure Start Button block: when image is set you may select one of the four layout options for image. It is simpler to experiment with setting than to describe intended result here so it's up to you to try;
  * Compact menu style...: displays contents of Programs folder right under start menu item, just like it was done in Windows 98.

### 1.2-1.3: Menu-buttons, web search engines and most frequently used list ###

![http://power8.googlecode.com/svn/wiki/Power8New03.png](http://power8.googlecode.com/svn/wiki/Power8New03.png)

Using these tabs, you can either hide some of Menu-buttons, or edit the list and contents of available web search engines, and  finally, set the MFU list style used by Power8.

To remove web search engine, select the row and press DELETE key.

To add a search engine, click the empty space. Placeholders appear helping you to put data into appropriate places. After you wrote the proper search line, commit the changes by pressing ENTER. Try this with e.g. Youtube, which has the search query
```
"http://www.youtube.com/results?search_query={0}"
```

MFU tab allows you to set what is displayed in launch list table when you open Power8 window. By default, Windows' UserAssist data is used (same that is used by Explorer; same used by Power8 starting from v.0.5).

Custom MFU list is empty by default. To add data there, right-click whatever file/folder/application/link/control panel element you want inside Power8 and choose "Add to custom launch list". To remove item, right-click it and choose "Remove item from custom launch-list" (command available only when you right-click item that is actually placed inside launch table).

3rd way to build the launch list is to use Power8 internal data it collects e.g. to show Jump Lists on Windows XP, etc. You can find this data under `%localappdata%\Power8_Team\` in file named "Launchdata.csv".

## 1.4 Keyboard navigation ##
Power8 enables you to use it with keyboard only.
  * Use **Alt+Z** to open main window;
  * Use **double Alt+Z** to focus main button. Then you can press menu key on windows keyboard to activate context menu. If it doesn't work, this means system thinks you pressed Alt key and not Alt+Z combination. Press **Esc** key couple of times to exit Alt mode;
  * Press **Space** key to set checks in context menu and dialogs, to push buttons, etc.;
  * Press **Tab** or **Shift+Tab** to navigate through dialog windows and Power8 main window;
  * Press **Right**, then **Down** when menu-button is in focus to activate dropdown. Press **Esc** to close it. Depending on OS you may need to press it 2 times;
  * In main window, press **Alt** to quickly navigate to main menu. Then, press **down** to show dropdown. Press **Esc** to close it. Depending on OS you may need to press it 2 times;
  * Press **Enter** to run the item selected in Main menu or in dropdown lists of menu-buttons;
  * In Search Box:
    * Press **Up** and **Down** to move selection in Recent list or in search results - depending on what is going on at the moment;
    * Press **Enter** to launch item selected in Recent list or Search results. If nothing is selected, Power8 will try to launch the text typed in the Search box as Operating System command;
    * Press **Esc** to clear text entered and display the Recent list. Press **Esc** again to close the main window;
    * _1.4.6+_ Press **Ctrl+Tab** to put selected item path to the search bar so it can be launched with additional parameters. For links, the path of target is being put;
  * In Recent list or Search results:
    * Press **Enter** to launch selected application of file;
    * Press **Up** and **Down** to navigate through lists. Please note: groups expanders are not accessible by these keys, but you can expand/collapse them by using **X** key;
    * Press **Ctrl+Up**, **Ctrl+Down** in Recent list when "Use custom list" is selected in Settings window, Most Frequently Used page to move selected item up or down;
    * _1.4.6+_ Press **Ctrl+Tab** to put selected item path to the search bar so it can be launched with additional parameters. For links, the path of target is being put;
    * Press **Right** or **Left** to open Jump-List dropdown;
    * Press **P** in Recent list to pin or unpin item. In Search results you can also press this key to pin/unpin an item in case it originates from the Recent list, however, this change will only affect Recent list layout and not the Search results;
    * Press **X** in Search results to expand or collapse group selected item is in.