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
            Assert.Equal(1.0, Eval("ROUNDDOWN(1.55555, 0)"));
            Assert.Equal(1.5, Eval("ROUNDDOWN(1.55555, 1)"));
            Assert.Equal(1.55, Eval("ROUNDDOWN(1.55555, 2)"));
        }

        [Fact]
        public void EvaluatesRoundDown()
        {
            // TODO
        }
    }
}