@echo Off
set nuget=
if "%nuget%" == "" (
    set nuget=".\Tools\NuGet\NuGet.exe"
)

print nuget

set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

REM Build
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ".\Tokiota.Toolkit\Tokiota.Toolkit.sln" /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

REM Package
mkdir Build
cmd /c %nuget% pack ".\Tokiota.Toolkit\Source\Tokiota.Toolkit.XCutting.IoC.WebForm.AutofacAdapter\Tokiota.Toolkit.XCutting.IoC.WebForm.WindsorAdapter.csproj" -IncludeReferencedProjects -o Build -p Configuration=%config% %version%

pause