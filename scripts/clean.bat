@ECHO OFF

IF EXIST ..\.vs RMDIR /S /Q ..\.vs
IF EXIST ..\packages RMDIR /S /Q ..\packages

SET PROJ=FormulaCS
IF EXIST ..\src\%PROJ%\bin RMDIR /S /Q ..\src\%PROJ%\bin
IF EXIST ..\src\%PROJ%\obj RMDIR /S /Q ..\src\%PROJ%\obj
IF EXIST ..\src\%PROJ%\%PROJ%.csproj.user DEL ..\src\%PROJ%\%PROJ%.csproj.user
IF EXIST ..\src\%PROJ%\%PROJ%.csproj.DotSettings DEL ..\src\%PROJ%\%PROJ%.csproj.DotSettings

SET PROJ=FormulaCS.Common
IF EXIST ..\src\%PROJ%\bin RMDIR /S /Q ..\src\%PROJ%\bin
IF EXIST ..\src\%PROJ%\obj RMDIR /S /Q ..\src\%PROJ%\obj
IF EXIST ..\src\%PROJ%\%PROJ%.csproj.user DEL ..\src\%PROJ%\%PROJ%.csproj.user
IF EXIST ..\src\%PROJ%\%PROJ%.csproj.DotSettings DEL ..\src\%PROJ%\%PROJ%.csproj.DotSettings

SET PROJ=FormulaCS.Parser
IF EXIST ..\src\%PROJ%\bin RMDIR /S /Q ..\src\%PROJ%\bin
IF EXIST ..\src\%PROJ%\obj RMDIR /S /Q ..\src\%PROJ%\obj
IF EXIST ..\src\%PROJ%\%PROJ%.csproj.user DEL ..\src\%PROJ%\%PROJ%.csproj.user
IF EXIST ..\src\%PROJ%\%PROJ%.csproj.DotSettings DEL ..\src\%PROJ%\%PROJ%.csproj.DotSettings

SET PROJ=FormulaCS.StandardExcelFunctions
IF EXIST ..\src\%PROJ%\bin RMDIR /S /Q ..\src\%PROJ%\bin
IF EXIST ..\src\%PROJ%\obj RMDIR /S /Q ..\src\%PROJ%\obj
IF EXIST ..\src\%PROJ%\%PROJ%.csproj.user DEL ..\src\%PROJ%\%PROJ%.csproj.user
IF EXIST ..\src\%PROJ%\%PROJ%.csproj.DotSettings DEL ..\src\%PROJ%\%PROJ%.csproj.DotSettings

SET PROJ=FormulaCS.Common.Tests
IF EXIST ..\test\%PROJ%\bin RMDIR /S /Q ..\test\%PROJ%\bin
IF EXIST ..\test\%PROJ%\obj RMDIR /S /Q ..\test\%PROJ%\obj
IF EXIST ..\test\%PROJ%\%PROJ%.csproj.user DEL ..\test\%PROJ%\%PROJ%.csproj.user
IF EXIST ..\test\%PROJ%\%PROJ%.csproj.DotSettings DEL ..\test\%PROJ%\%PROJ%.csproj.DotSettings

SET PROJ=FormulaCS.StandardExcelFunctions.Tests
IF EXIST ..\test\%PROJ%\bin RMDIR /S /Q ..\test\%PROJ%\bin
IF EXIST ..\test\%PROJ%\obj RMDIR /S /Q ..\test\%PROJ%\obj
IF EXIST ..\test\%PROJ%\%PROJ%.csproj.user DEL ..\test\%PROJ%\%PROJ%.csproj.user
IF EXIST ..\test\%PROJ%\%PROJ%.csproj.DotSettings DEL ..\test\%PROJ%\%PROJ%.csproj.DotSettings

ECHO Finished
ECHO.
PAUSE