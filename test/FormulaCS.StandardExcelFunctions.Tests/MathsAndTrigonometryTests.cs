using FormulaCS.Evaluator;
using Xunit;

namespace FormulaCS.StandardExcelFunctions.Tests
{
    public class MathsAndTrigonometryTests
    {
        private readonly FormulaEvaluator evaluator = new FormulaEvaluator();

        public MathsAndTrigonometryTests()
        {
            evaluator.AddStandardFunctions();
        }

        private object Eval(string formula)
        {
            return evaluator.Evaluate(formula);
        }

        [Fact]
        public void EvaluatesRoundUp()
        {
            // Examples from https://support.office.com/en-gb/article/ROUNDUP-function-f8bc9b23-e795-47db-8703-db171d0c42a7
            Assert.Equal(4.0, Eval("ROUNDUP(3.2, 0)"));
            Assert.Equal(77.0, Eval("ROUNDUP(76.9, 0)"));
            Assert.Equal(3.142, Eval("ROUNDUP(3.14159, 3)"));
            Assert.Equal(-3.2, Eval("ROUNDUP(-3.14159, 1)"));
            Assert.Equal(31500.0, Eval("ROUNDUP(31415.92654, -2)"));
        }

        [Fact]
        public void EvaluatesRoundDown()
        {
            // Examples from https://support.office.com/en-gb/article/ROUNDDOWN-function-2ec94c73-241f-4b01-8c6f-17e6d7968f53
            Assert.Equal(3.0, Eval("ROUNDDOWN(3.2, 0)"));
            Assert.Equal(76.0, Eval("ROUNDDOWN(76.9, 0)"));
            Assert.Equal(3.141, Eval("ROUNDDOWN(3.14159, 3)"));
            Assert.Equal(-3.1, Eval("ROUNDDOWN(-3.14159, 1)"));
            Assert.Equal(31400.0, Eval("ROUNDDOWN(31415.92654, -2)"));
        }
    }
}