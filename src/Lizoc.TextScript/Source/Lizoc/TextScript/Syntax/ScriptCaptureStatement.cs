﻿// -----------------------------------------------------------------------
// <copyright file="ScriptCaptureStatement.cs" repo="TextScript">
//     Copyright (C) 2018 Lizoc Inc. <http://www.lizoc.com>
//     The source code in this file is subject to the MIT license.
//     See the LICENSE file in the repository root directory for more information.
// </copyright>
// -----------------------------------------------------------------------

using Lizoc.TextScript.Runtime;

namespace Lizoc.TextScript.Syntax
{
    [ScriptSyntax("capture statement", "capture <variable> ... end")]
    public class ScriptCaptureStatement : ScriptStatement
    {
        public ScriptExpression Target { get; set; }

        public ScriptBlockStatement Body { get; set; }

        public override object Evaluate(TemplateContext context)
        {
            // unit test: 230-capture-statement.txt
            context.PushOutput();
            try
            {
                context.Evaluate(Body);
            }
            finally
            {
                var result = context.PopOutput();
                context.SetValue(Target, result);
            }
            return null;
        }

        public override void Write(TemplateRewriterContext context)
        {
            context.Write("capture").ExpectSpace();
            context.Write(Target);
            context.ExpectEos();
            context.Write(Body);
            context.ExpectEnd();
        }
    }
}