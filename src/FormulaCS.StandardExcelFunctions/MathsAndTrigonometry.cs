using System;
using System.Collections.Generic;
using FormulaCS.Common;

namespace FormulaCS.StandardExcelFunctions
{
    public static class MathsAndTrigonometry
    {
        public static readonly Dictionary<string, FunctionDelegate> FunctionDelegates;

        static MathsAndTrigonometry()
        {
            FunctionDelegates = new Dictionary<string, FunctionDelegate>(StringComparer.OrdinalIgnoreCase)
            {
//                {"LN", LnFunction},
//                {"LOG", LogFunction},
//                {"POWER", PowerFunction},
//                {"PI", PiFunction},
//                {"ROUND", RoundFunction},
                {"ROUNDUP", RoundUpFunction},
                {"ROUNDDOWN", RoundDownFunction},
//                {"RADIANS", RadiansFunction},
//                {"SQRT", SqrtFunction},
//                {"SUM", SumFunction},
//                {"TAN", TanFunction},
            };
        }

        /// <remarks>
        /// This function is used by the RoundUp and RoundDown functions in this file.
        /// See <a href="http://stackoverflow.com/a/13483008">this link</a> for the original example.
        /// </remarks>
        private static decimal RoundFactor(int places)
        {
            var factor = 1m;

            if (places < 0)
            {
                places = -places;
                for (var i = 0; i < places; i++)
                {
                    factor /= 10m;
                }
            }

            else
            {
                for (var i = 0; i < places; i++)
                {
                    factor *= 10m;
                }
            }

            return factor;
        }

        /// <remarks>
        /// See <a href="https://support.office.com/en-gb/article/ROUNDUP-function-f8bc9b23-e795-47db-8703-db171d0c42a7">this link</a> for more information.
        /// </remarks>
        private static void RoundUpFunction(IFunctionArgs args, IExcelCaller caller)
        {
            if (args.Parameters.Length != 2)
            {
                throw new ArgumentException("ROUNDUP function takes 2 arguments, " +
                                            $"got {args.Parameters.Length}");
            }

            var arg1 = args.Parameters[0].Evaluate();
            if (arg1 is ErrorValue)
            {
                args.Result = arg1;
                return;
            }

            var arg2 = args.Parameters[1].Evaluate();
            if (arg2 is ErrorValue)
            {
                args.Result = arg2;
                return;
            }

            // This code snippet based on example at http://stackoverflow.com/a/13483008
            var number = new decimal(StringConversion.ToDouble(arg1));
            var places = Convert.ToInt32(arg2);
            var factor = RoundFactor(places);
            number *= factor;
            number = Math.Ceiling(number);
            number /= factor;

            args.Result = Convert.ToDouble(number);
        }

        /// <remarks>
        /// See <a href="https://support.office.com/en-gb/article/ROUNDDOWN-function-2ec94c73-241f-4b01-8c6f-17e6d7968f53">this link</a> for more information.
        /// </remarks>
        private static void RoundDownFunction(IFunctionArgs args, IExcelCaller caller)
        {
            if (args.Parameters.Length != 2)
            {
                throw new ArgumentException("ROUNDDOWN function takes 2 arguments, " +
                                            $"got {args.Parameters.Length}");
            }

            var arg1 = args.Parameters[0].Evaluate();
            if (arg1 is ErrorValue)
            {
                args.Result = arg1;
                return;
            }

            var arg2 = args.Parameters[1].Evaluate();
            if (arg2 is ErrorValue)
            {
                args.Result = arg2;
                return;
            }

            // This code snippet based on example at http://stackoverflow.com/a/13483008
            var number = new decimal(StringConversion.ToDouble(arg1));
            var places = Convert.ToInt32(arg2);
            var factor = RoundFactor(places);
            number *= factor;
            number = Math.Floor(number);
            number /= factor;

            args.Result = Convert.ToDouble(number);
        }
    }
}
