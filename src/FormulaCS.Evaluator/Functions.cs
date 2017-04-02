using System.Collections.Generic;
using FormulaCS.Common;

namespace FormulaCS.Evaluator
{
    public class Functions
    {
        private readonly Dictionary<string, FunctionDelegate> funcs = new Dictionary<string, FunctionDelegate>();
    }
}