grammar Formula;

/* Parser rules */
main : expr? EOF;
expr : sign=('+'|'-') expr                   #Unary
     | expr '%'                              #Percentage
     | expr '^' expr                         #Pow
     | expr op=('*'|'/') expr                #MulDiv
     | expr op=('+'|'-') expr                #AddSub
     | expr '&' expr                         #Concatenate
     | expr op=('='|'<>') expr               #Equality
     | expr op=('<'|'>'|'<='|'>=') expr      #Relational
     | '(' expr ')'                          #Parenthesis
     | name=NAME '(' (expr (',' expr)*)? ')' #Function
     | STRING                                #String
     | BOOLEAN                               #Boolean
     | NUMBER                                #Number
     ;

/* Lexer rules */
STRING  : '"' ~["]* '"' ;
BOOLEAN : TRUE|FALSE ;
NUMBER  : FLOAT|DIGIT+ ;
NAME    : [a-zA-Z_\\] ([0-9a-zA-Z_.\\])* ;
S       : (' '|'\t'|'\r'|'\n'|'\u000C') -> skip ;
INVALID : . ;

/* Lexer fragments */
fragment DIGIT : [0-9] ;
fragment TRUE  : [Tt][Rr][Uu][Ee] ;
fragment FALSE : [Ff][Aa][Ll][Ss][Ee] ;
fragment FLOAT : DIGIT+ '.' DIGIT+ E? | DIGIT+ E ;
fragment E     : [Ee] ('+'?|'-') DIGIT+ ;