@echo off
@%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\msbuild CI_Main.build /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

pause