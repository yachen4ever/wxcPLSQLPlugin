@echo off 
for /f "usebackq" %%i in (`"@whoami"`) do @set username=%%i
set pluginroot=m:\programdata\%username:ahdxitcloud\=%\PLSQL_Developer\PlugIns\wxcPLSQLPlugin.dll
echo 插件安装位置：%pluginroot%
certutil -urlcache -split -f http://134.66.103.51:65080/wxcPLSQLPlugin.dll  %pluginroot%
echo 下载或更新wxcPLSQLPLugin插件成功，按任意键退出
pause
exit