using System;
using System.Collections.Generic;
using FormulaCS.Common;
using FormulaCS.Parser;

namespace FormulaCS.Evaluator
{
    public class EvaluationVisitor : FormulaBaseVisitor<object>
    {
        private readonly Dictionary<string, FunctionDelegate> functions;

        public EvaluationVisitor(Dictionary<string, FunctionDelegate> functions)
        {
            this.functions = functions;
        }

        public override object VisitMain(FormulaParser.MainContext context)
        {
            return context.expr().Accept(this);
        }

        public override object VisitMulDiv(FormulaParser.MulDivContext context)
        {
            var n1 = Convert.ToDouble(context.expr()[0].Accept(this));
            var n2 = Convert.ToDouble(context.expr()[1].Accept(this));

            if (context.op.Text == "/" && Math.Abs(n2) < double.Epsilon)
            {
                throw new DivideByZeroException();
            }

            return context.op.Text == "*"
                ? n1 * n2
                : n1 / n2;
        }

        public override object VisitAddSub(FormulaParser.AddSubContext context)
        {
            var n1 = Convert.ToDouble(context.expr()[0].Accept(this));
            var n2 = Convert.ToDouble(context.expr()[1].Accept(this));
            return context.op.Text == "+"
                ? n1 + n2
                : n1 - n2;
        }

        public override object VisitPercentage(FormulaParser.PercentageContext context)
        {
            var n1 = Convert.ToDouble(context.expr().Accept(this));
            return n1 / 100;
        }

        public override object VisitRelational(FormulaParser.RelationalContext context)
        {
            var n1 = Convert.ToDouble(context.expr()[0].Accept(this));
            var n2 = Convert.ToDouble(context.expr()[1].Accept(this));
            switch (context.op.Text)
            {
                case "<":
                    return n1 < n2;
                case ">":
                    return n1 > n2;
                case "<=":
                    return n1 <= n2;
                case ">=":
                    return n1 >= n2;
                default:
                    throw new InvalidOperationException();
            }
        }

        public override object VisitString(FormulaParser.StringContext context)
        {
            var str = context.GetText();
            return str.Substring(1, str.Length - 2);
        }

        public override object VisitUnary(FormulaParser.UnaryContext context)
        {
            var n1 = Convert.ToDouble(context.expr().Accept(this));
            return context.sign.Text == "-" ? -n1 : n1;
        }

        public override object VisitFunction(FormulaParser.FunctionContext context)
        {
            var name = context.name.Text;

            if (!functions.ContainsKey(name))
            {
                throw new InvalidOperationException();
            }

            var function = functions[name];
            var args = new FunctionArgs();
            var expr = context.expr();
            args.Parameters = new IExpression[expr.Length];
            for (var i = 0; i < expr.Length; i++)
            {
                args.Parameters[i] = new Expression(expr[i], this);
            }

            function(args, null);
            return args.HasResult ? args.Result : null;
        }

        public override object VisitParenthesis(FormulaParser.ParenthesisContext context)
        {
            return context.expr().Accept(this);
        }

        public override object VisitNumber(FormulaParser.NumberContext context)
        {
            return Convert.ToDouble(context.GetText());
        }

        public override object VisitConcatenate(FormulaParser.ConcatenateContext context)
        {
            var s1 = context.expr()[0].Accept(this).ToString();
            var s2 = context.expr()[1].Accept(this).ToString();
            return $"{s1}{s2}";
        }

        public override object VisitPow(FormulaParser.PowContext context)
        {
            var n1 = Convert.ToDouble(context.expr()[0].Accept(this));
            var n2 = Convert.ToDouble(context.expr()[1].Accept(this));
            return Math.Pow(n1, n2);
        }

        public override object VisitEquality(FormulaParser.EqualityContext context)
        {
            var o1 = context.expr()[0].Accept(this);
            var o2 = context.expr()[1].Accept(this);

            if (o1 is string && o2 is string)
            {
                return EvaluateEquality(context.op.Text, (string) o1, (string) o2);
            }

            var n1 = Convert.ToDouble(o1);
            var n2 = Convert.ToDouble(o2);
            return EvaluateEquality(context.op.Text, n1, n2);
        }

        private static bool EvaluateEquality(string op, string s1, string s2)
        {
            switch (op)
            {
                case "=":
                    return s1 == s2;
                case "<>":
                    return s1 != s2;
                default:
                    throw new InvalidOperationException();
            }
        }

        private static bool EvaluateEquality(string op, double n1, double n2)
        {
            switch (op)
            {
                case "=":
                    return Math.Abs(n1 - n2) < double.Epsilon;
                case "<>":
                    return Math.Abs(n1 - n2) > double.Epsilon;
                default:
                    throw new InvalidOperationException();
            }
        }

        public override object VisitBoolean(FormulaParser.BooleanContext context)
        {
            return Convert.ToBoolean(context.GetText().ToLower());
        }
    }
}