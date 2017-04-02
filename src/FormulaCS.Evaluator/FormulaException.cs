namespace FormulaCS.Evaluator
{
    public class FormulaException : System.Exception
    {
        public int CharPosition { get; }

        public FormulaException(int charPosition, string msg)
            : base(msg)
        {
            CharPosition = charPosition;
        }
    }
}