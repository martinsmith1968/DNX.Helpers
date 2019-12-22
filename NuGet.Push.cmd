@ECHO OFF

SETLOCAL EnableDelayedExpansion

SET SCRIPTPATH=%~dp0

CALL "%SCRIPTPATH%\NuGet.Package.cmd"

SET APPNAME=DNX.Helpers

REM NuGet feed v3 (VS 2015 / NuGet v3.x): https://api.nuget.org/v3/index.json
REM NuGet feed v2 (VS 2013 and earlier / NuGet 2.x): https://www.nuget.org/api/v2

SET NUGETEXE=%SCRIPTPATH%\.nuget\nuget.exe
SET NUGETSERVERAPIURL=https://www.nuget.org/api/v2/package

CALL SetNuGetServerAPIKey.cmd "%APPNAME%"

FOR %%F IN (*.nupkg) DO (
    ECHO.Pushing: %%~F
    %NUGETEXE% push "%%~F" -Source "%NUGETSERVERAPIURL%" -ApiKey "%NUGETSERVERAPIKEY%"
)
