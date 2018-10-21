@echo off
@echo ******************************

@echo  ******************************************************************************************
@echo  ***                        Batch lernen!!!!
@echo  ***                        Using batch file in Nant is cool
@echo  ***                        No Panic to clean soltion with Batch
@echo  ***
@echo  ***
@echo  ***
@echo  ***
@echo  *****************************************************************************************

FOR /F "tokens=*" %%G IN ('DIR /B /AD /S bin') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S obj') DO RMDIR /S /Q "%%G"
