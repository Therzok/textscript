using System.IO;

namespace Lizoc.TextScript.Syntax
{
    [ScriptSyntax("raw statement", "<raw_text>")]
    public class ScriptRawStatement : ScriptStatement
    {
        public string Text { get; set; }

        public int EscapeCount { get; set; }

        public override object Evaluate(TemplateContext context)
        {
            if (Text == null)
                return null;

            int length = Span.End.Offset - Span.Start.Offset + 1;
            if (length > 0)
            {
                // If we are in the context of output, output directly to TemplateContext.Output
                if (context.EnableOutput)
                    context.Write(Text, Span.Start.Offset, length);
                else
                    return Text.Substring(Span.Start.Offset, length);
            }
            return null;
        }

        public override void Write(TemplateRewriterContext context)
        {
            if (Text == null)
                return;

            if (EscapeCount > 0)
                context.WriteEnterCode(EscapeCount);

            // TODO: handle escape
            int length = Span.End.Offset - Span.Start.Offset + 1;
            if (length > 0)
                context.Write(Text.Substring(Span.Start.Offset, length));

            if (EscapeCount > 0)
                context.WriteExitCode(EscapeCount);
        }

        public override string ToString()
        {
            int length = Span.End.Offset - Span.Start.Offset + 1;
            return Text?.Substring(Span.Start.Offset, length) ?? string.Empty;
        }
    }
}