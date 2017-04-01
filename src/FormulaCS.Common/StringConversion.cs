using System;

namespace FormulaCS.Common
{
    public static class StringConversion
    {
        public static double ToDouble(object obj)
        {
            if (obj is DateTime)
            {
                return ((DateTime)obj).ToOADate();
            }

            if (obj is char)
            {
                return 0;
            }

            if (obj is string)
            {
                return 0;
            }

            return Convert.ToDouble(obj);
        }
    }
}