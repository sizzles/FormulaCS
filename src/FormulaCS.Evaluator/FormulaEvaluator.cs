using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using FormulaCS.Common;
using FormulaCS.Parser;
using FormulaCS.StandardExcelFunctions;

namespace FormulaCS.Evaluator
{
    public class FormulaEvaluator
    {
        public readonly Dictionary<string, FunctionDelegate> Functions = new Dictionary<string, FunctionDelegate>(StringComparer.OrdinalIgnoreCase);

        public void AddStandardFunctions()
        {
            AddFunctions(DateAndTime.FunctionDelegates);
            AddFunctions(Logical.FunctionDelegates);
            AddFunctions(LookupAndReference.FunctionDelegates);
            AddFunctions(MathsAndTrigonometry.FunctionDelegates);
            AddFunctions(Statistical.FunctionDelegates);
            AddFunctions(Text.FunctionDelegates);
        }

        public void AddFunctions(Dictionary<string, FunctionDelegate> delegates)
        {
            foreach (var f in delegates)
            {
                Functions.Add(f.Key, f.Value);
            }
        }

        public object Evaluate(string formula)
        {
            if (string.IsNullOrEmpty(formula))
            {
                return 0;
            }

            var inputStream = new AntlrInputStream(formula);
            var lexer = new FormulaLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new FormulaParser(tokens);

            var errorListener = new FormulaErrorListener();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);
            var parseTree = parser.main();

            if (!errorListener.IsValid)
            {
                throw new FormulaException(
                    errorListener.ErrorLocation,
                    errorListener.ErrorMessage);
            }

            return new EvaluationVisitor(Functions).VisitMain(parseTree);
        }
    }
}