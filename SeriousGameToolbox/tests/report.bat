cd %~dp0
call opencover.bat
..\packages\ReportGenerator.2.1.3.0\ReportGenerator.exe -reports:results.xml -targetdir:coverage
coverage\index.htm