@ECHO OFF

SETLOCAL EnableDelayedExpansion

SET SCRIPTPATH=%~dp0

REM NuGet feed v3 (VS 2015 / NuGet v3.x): https://api.nuget.org/v3/index.json
REM NuGet feed v2 (VS 2013 and earlier / NuGet 2.x): https://www.nuget.org/api/v2

SET NUGETEXE=%SCRIPTPATH%\.nuget\nuget.exe

SET NUGETSERVERAPIURL=https://www.nuget.org/api/v2/package
rem SET NUGETSERVERAPIURL=https://www.nuget.org
SET NUGETSERVERAPIKEY=1d9c8df7-5dbc-40d0-baef-b36a8c9244e2

IF EXIST *.nupkg DEL *.nupkg

"%NUGETEXE%" pack "%SCRIPTPATH%\DNX.Helpers\DNX.Helpers.csproj"

FOR %%F IN (*.nupkg) DO (
    ECHO.Pushing: %%~F
	%NUGETEXE% push "%%~F" -Source "%NUGETSERVERAPIURL%" -ApiKey "%NUGETSERVERAPIKEY%"
)
