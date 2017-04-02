using FormulaCS.Common;
using FormulaCS.Parser;

namespace FormulaCS.Evaluator
{
    public class Expression : IExpression
    {
        private readonly FormulaParser.ExprContext context;
        private readonly EvaluationVisitor visitor;

        public Expression(FormulaParser.ExprContext context, EvaluationVisitor visitor)
        {
            this.context = context;
            this.visitor = visitor;
        }

        public object Evaluate()
        {
            return context.Accept(visitor);
        }
    }
}