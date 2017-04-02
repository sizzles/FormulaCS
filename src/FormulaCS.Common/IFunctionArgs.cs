namespace FormulaCS.Common
{
    public interface IFunctionArgs
    {
        IExpression[] Parameters { get; set; }
        bool HasResult { get; }
        object Result { get; set; }
    }
}