@将Clear.bat放在要删除的所有文件的根文件夹下，然后双击该文件，即可运行
@运行时，删除当前所在文件夹及所有子文件夹下的“obj,bin,debug,ipch”文件夹及内容
@echo off
set nowPath=%cd%
cd \
cd %nowPath%

::delete specify folder(obj,bin)
for /r %nowPath% %%i in (obj,bin) do (IF EXIST %%i RD /s /q %%i) 

::delete specify folder(debug,ipch)
for /r %nowPath% %%i in (debug,ipch) do (IF EXIST %%i RD /s /q %%i) 

echo OK
pause                                                                                                                                                                                                                                                                                                                                                                                                                                              