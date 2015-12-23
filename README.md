This application is created for demonstrating .NET Native compiler bug.</br>
At some configurations(Windows, .Net Native, etc.) in Release x86/x64 configurations the application prints to output console:</br>
-------------- ELSE --------------</br>
-------------- FAIL --------------</br>
This is incorrect behavior, because the application MUST prints:</br>
-------------- ELSE --------------</br>
-------------- SUCCESS --------------</br>
