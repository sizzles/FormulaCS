using FormulaCS.Common;
using Xunit;

namespace FormulaCS.Evaluator.Tests
{
    public class FormulaEvaluatorTests
    {
        private readonly FormulaEvaluator evaluator = new FormulaEvaluator();

        public FormulaEvaluatorTests()
        {
            evaluator.Functions.Add("AddThem", AddThemFunction);
        }

        private static void AddThemFunction(IFunctionArgs args, IExcelCaller caller)
        {
            var arg1 = StringConversion.ToDouble(args.Parameters[0].Evaluate());
            var arg2 = StringConversion.ToDouble(args.Parameters[1].Evaluate());
            args.Result = arg1 + arg2;
        }

        private object Eval(string formula)
        {
            return evaluator.Evaluate(formula);
        }

        [Fact]
        public void EvaluatesMultiplication()
        {
            Assert.Equal(6d, Eval("3*2"));
        }

        [Fact]
        public void EvaluatesDivision()
        {
            Assert.Equal(2d, Eval("4/2"));
        }

        [Fact]
        public void EvaluatesAddition()
        {
            Assert.Equal(6d, Eval("4+2"));
        }

        [Fact]
        public void EvaluatesSubtraction()
        {
            Assert.Equal(2d, Eval("4-2"));
        }

        [Fact]
        public void EvaluatesPercentage()
        {
            Assert.Equal(0.1d, Eval("10%"));
        }

        [Fact]
        public void EvaluatesRelational()
        {
            Assert.Equal(true, Eval("2>1"));
            Assert.Equal(false, Eval("1>2"));
            Assert.Equal(false, Eval("0.1>2"));
            Assert.Equal(true, Eval("0.1<2"));
            Assert.Equal(false, Eval("10<10"));
            Assert.Equal(false, Eval("10>10"));
            Assert.Equal(true, Eval("10>=10"));
            Assert.Equal(true, Eval("10<=10"));
        }

        [Fact]
        public void EvaluatesString()
        {
            Assert.Equal("Test", Eval("\"Test\""));
        }

        [Fact]
        public void EvaluatesUnary()
        {
            Assert.Equal(-3d, Eval("-3"));
            Assert.Equal(-4d, Eval("-(2+2)"));
            Assert.Equal(2d, Eval("+(4/2)"));
            Assert.Equal(-2d, Eval("+(4/-2)"));
            Assert.Equal(2d, Eval("++++++2"));
        }

        [Fact]
        public void EvaluatesFunction()
        {
            Assert.Equal(4d, Eval("AddThem(2,2)"));
        }

        [Fact]
        public void EvaluatesParenthesis()
        {
            Assert.Equal(4d, Eval("(2+2)"));
            Assert.Equal(12d, Eval("2*(2+4)"));
        }

        [Fact]
        public void EvaluatesNumber()
        {
            Assert.Equal(4d, Eval("4"));
            Assert.Equal(4d, Eval("4.0"));
            Assert.Equal(100000000000000000000d, Eval("1e20"));
            Assert.Equal(100000000000000000000d, Eval("1e+20"));
            Assert.Equal(0.00000000000000000001d, Eval("1e-20"));
        }

        [Fact]
        public void EvaluatesConcatenate()
        {
            Assert.Equal("ABC", Eval("\"AB\"&\"C\""));
        }

        [Fact]
        public void EvaluatesPower()
        {
            Assert.Equal(4d, Eval("2^2"));
            Assert.Equal(64d, Eval("2^2^3"));
            Assert.Equal(64d, Eval("(2^2)^3"));
            Assert.Equal(256d, Eval("2^(2^3)"));
        }

        [Fact]
        public void EvaluatesEquality()
        {
            Assert.Equal(true, Eval("2<>1"));
            Assert.Equal(true, Eval("10=10"));
            Assert.Equal(true, Eval("\"Test\"=\"Test\""));
            Assert.Equal(false, Eval("\"Test\"=\"TestX\""));
            Assert.Equal(true, Eval("\"Test\"<>\"TestX\""));
        }

        [Fact]
        public void EvaluatesBoolean()
        {
            Assert.Equal(true, Eval("TRUE"));
            Assert.Equal(true, Eval("true"));
            Assert.Equal(true, Eval("True"));
            Assert.Equal(false, Eval("FALSE"));
            Assert.Equal(false, Eval("false"));
            Assert.Equal(false, Eval("False"));
        }
    }
}