﻿// -----------------------------------------------------------------------
// <copyright file="ScriptArrayInitializerExpression.cs" repo="TextScript">
//     Copyright (C) 2018 Lizoc Inc. <http://www.lizoc.com>
//     The source code in this file is subject to the MIT license.
//     See the LICENSE file in the repository root directory for more information.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using Lizoc.TextScript.Runtime;

namespace Lizoc.TextScript.Syntax
{
    [ScriptSyntax("array initializer", "[item1, item2,...]")]
    public class ScriptArrayInitializerExpression : ScriptExpression
    {
        public ScriptArrayInitializerExpression()
        {
            Values = new List<ScriptExpression>();
        }

        public List<ScriptExpression> Values { get; private set; }

        public override object Evaluate(TemplateContext context)
        {
            ScriptArray scriptArray = new ScriptArray();
            foreach (ScriptExpression value in Values)
            {
                var valueEval = context.Evaluate(value);
                scriptArray.Add(valueEval);
            }
            return scriptArray;
        }

        public override void Write(TemplateRewriterContext context)
        {
            context.Write("[");
            context.WriteListWithCommas(Values);
            context.Write("]");
        }

        public override string ToString()
        {
            return "[" + StringHelper.Join(", ", Values) + "]";
        }
    }
}