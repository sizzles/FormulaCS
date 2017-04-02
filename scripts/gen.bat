@ECHO OFF

CD ..\src\FormulaCS.Parser
CALL antlr4 Formula.g4 -o . -package FormulaCS.Parser -Dlanguage=CSharp -no-listener -visitor

ECHO Finished
ECHO.
PAUSE