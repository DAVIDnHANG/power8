# <font color='red'>WARNING! This project has been migrated to <a href='https://github.com/AgentMC/power8/wiki/DuplicatedIconsHack'>GitHub</a> </font> #
# Introduction #

There were some reports about issues on Windows 7 and Windows 8.1 where Power8 didn't show Control panel items' icons correctly. The hack-fix was implemented in version 1.4.5, but it requires manual activation. This page is about how to use it to fix the issue.

# Symptoms #

When you open Control Panel menu-button, you can see that some icons are duplicated. Candidates for duplication are: Action Center, Credential manager, Biometric Devices, and so on. The issue is purely graphical and doesn't affect performance or functionality of application.

# Cause #

This is not an issue in Power8. The issue is caused by certain changes in .Net Framework 4.5.1 and/or DLL loader of Windows 8.1 (potentially the last one, since similar behavior was from time to time achievable on Windows 7).

This issue has been sent to Microsoft, and you can get acquainted with details here: https://connect.microsoft.com/VisualStudio/feedback/details/812220/consecutive-loadlibrary-lib1-freelibrary-hlib1-and-loadlibrary-lib2-from-managed-code-through-p-invoke-results-in-same-hinstance-for-lib1-and-lib2-on-windows-8-1

# Solution #

Power8 may not free loaded dlls after extracting images. This results in always different HMODULE, and so always different HICON retrieved. However, _theoretically_ this can lead to bigger memory consumption, and thus hack is disabled by default.

BTW, practical tests unexpectedly show up to 5% **LESS** memory consumption with hack on, so activation may be useful even on the system without the glitch.

To activate and use the hack:

## Version 1.5.1 and later ##

  1. Open Power8 settings dialog and switch to Menu-Buttons tab;
  1. When Control Panel menu-button is checked, the child "Fix duplicated icons..." checkbox becomes enabled;
  1. Check it to activate the hack, uncheck to disable the hack. Since icons are cached by Power8, it may require to restart the application to reload Control Panel icons affected by the hack.

## Version 1.5.0 and older ##

  1. Open Power8.exe.config file in Power8 installation directory with notepad;
  1. Find setting `DoNotFreeLibraries` and set it's `Value` to `True` (by default it's `False`);
  1. Save file and (re)start Power8.

If this doesn't help:

  1. Close Power8;
  1. Using system run dialog (Win+R key combination), open `%localappdata%\Power8_Team` folder;
  1. Remove all subfolders from this folder. **NOTE: this will reset all your settings**;
  1. Start Power8;