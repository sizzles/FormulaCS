using System;
using System.Collections.Generic;
using FormulaCS.Common;

namespace FormulaCS.StandardExcelFunctions
{
    public static class DateAndTime
    {
        public static readonly Dictionary<string, FunctionDelegate> FunctionDelegates;

        static DateAndTime()
        {
            FunctionDelegates = new Dictionary<string, FunctionDelegate>(StringComparer.OrdinalIgnoreCase)
            {
//                {"DATE", DateFunction},
//                {"MONTH", MonthFunction},
//                {"YEAR", YearFunction},
            };
        }
    }
}