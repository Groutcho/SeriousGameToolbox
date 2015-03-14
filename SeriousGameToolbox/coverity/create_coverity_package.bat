rem will create a coverity cov-int package ready to send to analysis
rmdir cov-int /s
del cov-int.zip

set cov_path=%~dp0
set sln_path=%~dp0..\
cov-build --dir %cov_path%cov-int devenv %sln_path%SeriousGameToolbox.sln /rebuild Release
7z a -tzip cov-int.zip cov-int\