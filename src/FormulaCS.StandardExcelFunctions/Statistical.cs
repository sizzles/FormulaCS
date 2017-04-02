using System;
using System.Collections.Generic;
using FormulaCS.Common;

namespace FormulaCS.StandardExcelFunctions
{
    public class Statistical
    {
        public static readonly Dictionary<string, FunctionDelegate> FunctionDelegates;

        static Statistical()
        {
            FunctionDelegates = new Dictionary<string, FunctionDelegate>(StringComparer.OrdinalIgnoreCase)
            {
//                {"AVERAGE", AverageFunction},
//                {"AVERAGEIF", AverageIfFunction},
//                {"MAX", MaxFunction},
//                {"MIN", MinFunction},
            };
        }
    }
}