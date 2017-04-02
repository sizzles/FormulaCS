using System;
using System.Collections.Generic;
using FormulaCS.Common;

namespace FormulaCS.StandardExcelFunctions
{
    public static class Logical
    {
        public static readonly Dictionary<string, FunctionDelegate> FunctionDelegates;

        static Logical()
        {
            FunctionDelegates = new Dictionary<string, FunctionDelegate>(StringComparer.OrdinalIgnoreCase)
            {
//                {"AND", AndFunction},
//                {"IF", IfFunction},
//                {"IFERROR", IfErrorFunction},
//                {"OR", OrFunction},
            };
        }
    }
}