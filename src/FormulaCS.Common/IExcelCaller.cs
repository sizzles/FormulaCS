namespace FormulaCS.Common
{
    public interface IExcelCaller
    {
        string Sheet { get; }
        int Row { get; }
        int Column { get; }
    }
}