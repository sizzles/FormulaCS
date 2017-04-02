using System;
using System.Collections.Generic;
using FormulaCS.Common;

namespace FormulaCS.StandardExcelFunctions
{
    public class Text
    {
        public static readonly Dictionary<string, FunctionDelegate> FunctionDelegates;

        static Text()
        {
            FunctionDelegates = new Dictionary<string, FunctionDelegate>(StringComparer.OrdinalIgnoreCase)
            {
//                {"SUBSTITUTE", SubstituteFunction},
//                {"TEXT", TextFunction},
            };
        }
    }
}