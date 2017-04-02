using System;
using System.Collections.Generic;
using FormulaCS.Common;

namespace FormulaCS.StandardExcelFunctions
{
    public static class LookupAndReference
    {
        public static readonly Dictionary<string, FunctionDelegate> FunctionDelegates;

        static LookupAndReference()
        {
            FunctionDelegates = new Dictionary<string, FunctionDelegate>(StringComparer.OrdinalIgnoreCase)
            {
//                {"INDEX", IndexFunction},
//                {"INDIRECT", IndirectFunction},
//                {"MATCH", MatchFunction},
//                {"ROW", RowFunction},
//                {"VLOOKUP", VlookupFunction},
            };
        }
    }
}