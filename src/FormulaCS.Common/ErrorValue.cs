using System;

namespace FormulaCS.Common
{
    public class ErrorValue
    {
        private enum ErrorType
        {
            Null,
            Div0,
            Value,
            Ref,
            Name,
            Num,
            NA
        }

        public static ErrorValue Null => new ErrorValue(ErrorType.Null);
        public static ErrorValue Div0 => new ErrorValue(ErrorType.Div0);
        public static ErrorValue Value => new ErrorValue(ErrorType.Value);
        public static ErrorValue Ref => new ErrorValue(ErrorType.Ref);
        public static ErrorValue Name => new ErrorValue(ErrorType.Name);
        public static ErrorValue Num => new ErrorValue(ErrorType.Num);
        public static ErrorValue NA => new ErrorValue(ErrorType.NA);

        private const string HashNull = "#NULL!";
        private const string HashDiv0 = "#DIV/0!";
        private const string HashValue = "#VALUE!";
        private const string HashRef = "#REF!";
        private const string HashName = "#NAME?";
        private const string HashNum = "#NUM!";
        private const string HashNA = "#N/A";

        private readonly ErrorType errorType;

        public ErrorValue(string token)
            : this(GetErrorType(token))
        { }

        private ErrorValue(ErrorType errorType)
        {
            this.errorType = errorType;
        }

        private static ErrorType GetErrorType(string token)
        {
            switch (token)
            {
                case HashNull: return ErrorType.Null;
                case HashDiv0: return ErrorType.Div0;
                case HashValue: return ErrorType.Value;
                case HashRef: return ErrorType.Ref;
                case HashName: return ErrorType.Name;
                case HashNum: return ErrorType.Num;
                case HashNA: return ErrorType.NA;
                default: throw new Exception("Unrecongised error token");
            }
        }

        public static bool IsErrorToken(string token)
        {
            switch (token)
            {
                case HashNull:
                case HashDiv0:
                case HashValue:
                case HashRef:
                case HashName:
                case HashNum:
                case HashNA:
                    return true;
                default:
                    return false;
            }
        }

        public override string ToString()
        {
            switch (errorType)
            {
                case ErrorType.Null: return HashNull;
                case ErrorType.Div0: return HashDiv0;
                case ErrorType.Value: return HashValue;
                case ErrorType.Ref: return HashRef;
                case ErrorType.Name: return HashName;
                case ErrorType.Num: return HashNum;
                case ErrorType.NA: return HashNA;
                default: throw new Exception("Unexpected condition");
            }
        }
    }
}