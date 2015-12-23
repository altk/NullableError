This application is created for demonstrating .NET Native compiler bug.
At some configurations(Windows, .Net Native, etc.) in Release x86/x64 configurations the application prints to output console:
-------------- ELSE --------------
-------------- FAIL --------------
This is incorrect behavior, because the application MUST prints
-------------- ELSE --------------
-------------- SUCCESS --------------