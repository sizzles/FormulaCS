using FormulaCS.Common;

namespace FormulaCS.Evaluator
{
    public class FunctionArgs : IFunctionArgs
    {
        private object result;

        public IExpression[] Parameters { get; set; } = new IExpression[0];

        public bool HasResult { get; private set; }

        public object Result
        {
            get => result;
            set
            {
                result = value;
                HasResult = true;
            }
        }
    }
}