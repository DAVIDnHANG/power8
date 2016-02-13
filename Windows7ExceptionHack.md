# <font color='red'>WARNING! This project has been migrated to <a href='https://github.com/AgentMC/power8/wiki/Windows7ExceptionHack'>GitHub</a> </font> #
# Introduction #

There were some reports about issues on Windows 7 where Power8 didn't run correctly. The hack-fix was implemented in version 1.4.1, but it requires manual activation. This page is about how to use it to fix the issue.

# Symptoms #

Power8 crashes right on start-up, or it crashes when you hover the main button with mouse. The exception message is quite big, and it starts with the following:

`System.NullReferenceException: Object reference not set to an instance of an object. ---> System.ArithmeticException: Overflow or underflow in the arithmetic operation.`

`   at System.Double.Equals(Object obj)`

Examples can be found here: [Issue 9](https://code.google.com/p/power8/issues/detail?id=9).

# Cause #

This is not an issue in Power8. The issue is caused by not identified 3rd-party component that interferes correct FPU-based calculation of Power8 UI elements sizes.

This issue has been seen for some time in the Internet, for example, here: http://social.msdn.microsoft.com/Forums/en-US/wpf/thread/a31f9c7a-0e15-4a09-a544-bec07f0f152c

# Solution #

Power8 tries to utilize same fpureset() approach discussed at the page linked above. However since the solution is based on dynamic DLL load and method binding, this can be a performance hit, so hack is disabled by default.

To activate and use it:

  1. Ensure **any** of these is installed in your system. If none - install last one:
    * [C++ 2008 x86](http://www.microsoft.com/en-us/download/details.aspx?id=5582)
    * [C++ 2008 x64](http://www.microsoft.com/en-us/download/details.aspx?id=2092)
    * [C++ 2010 x86](http://www.microsoft.com/en-us/download/details.aspx?id=8328)
    * [C++ 2010 x64](http://www.microsoft.com/en-us/download/details.aspx?id=13523)
    * [C++ 2012](http://www.microsoft.com/en-us/download/details.aspx?id=30679)
  1. Open Power8.exe.config file in Power8 installation directory with notepad;
  1. Find setting `TryFpResetBeforeUiCtors` and set it's `Value` to `True` (by default it's `False`);
  1. Save file and start Power8.

NOTE: if Power8 will fail loading DLL from packages mentioned above, it will save a flag telling that this hack should be ultimately disabled. There will be no easy way then to clear this flag. So: **DO NOT TRY TO USE HACK IF YOU DID NOT INSTALL C++ PACKAGES BEFORE**.