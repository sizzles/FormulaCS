using System.IO;
using Antlr4.Runtime;

namespace FormulaCS.Evaluator
{
    public class FormulaErrorListener : BaseErrorListener
    {
        public bool IsValid { get; private set; } = true;
        public int ErrorLocation { get; private set; }
        public string ErrorMessage { get; private set; }

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            IsValid = false;
            ErrorLocation = charPositionInLine;
            ErrorMessage = msg;
        }
    }
}