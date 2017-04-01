namespace FormulaCS.Common
{
    public interface IFunctionArgs
    {
        object Result { get; set; }
        IExpression[] Parameters { get; set; }
    }
}