rem will create a coverity cov-int package ready to send to analysis
set cov_path=%~dp0
set sln_path=%~dp0..\
cov-build --dir %cov_path%cov-int devenv %sln_path%SeriousGameToolbox.sln /rebuild Release