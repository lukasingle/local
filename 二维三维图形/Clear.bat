@��Clear.bat����Ҫɾ���������ļ��ĸ��ļ����£�Ȼ��˫�����ļ�����������
@����ʱ��ɾ����ǰ�����ļ��м��������ļ����µġ�obj,bin,debug,ipch���ļ��м�����
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