﻿// -----------------------------------------------------------------------
// <copyright file="Program.cs" repo="TextScript">
//     Copyright (C) 2018 Lizoc Inc. <http://www.lizoc.com>
//     The source code in this file is subject to the MIT license.
//     See the LICENSE file in the repository root directory for more information.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Lizoc.XmlDoc;
using Lizoc.TextScript;
using Lizoc.TextScript.Runtime;
using Lizoc.TextScript.Functions;
using Lizoc.TextScript.Parsing;

namespace TextScriptDocGen
{
    class Program
    {
        static void Main(string[] args)
        {
        	if (args.Length != 1)
        	{
        		Console.WriteLine("ERROR!");
        		Console.WriteLine("TextScriptDocGen <out_filename.md>");
        		return;
        	}

        	string outputDocPath = args[0];

            /*
            var options = new ReaderOptions()
            {
                KeepNewLinesInText = true
            };
            */

            var members = DocReader.Read(typeof(Template).Assembly); //, options);

            var builtinClassNames = new Dictionary<string, string>()
            {
                [nameof(ArrayFunctions)] = "array",
                [nameof(DateTimeFunctions)] = "date",
                [nameof(HtmlFunctions)] = "html",
                [nameof(MathFunctions)] = "math",
                [nameof(ObjectFunctions)] = "object",
                [nameof(RegexFunctions)] = "regex",
                [nameof(StringFunctions)] = "string",
                [nameof(TimeSpanFunctions)] = "timespan",
                [nameof(FileSystemFunctions)] = "fs"
            };

            var writer = new StreamWriter(outputDocPath);

            string[] headText = new string[]
            {
                "Builtins",
                "========",
                "This is the reference documentation for all built-in functions that is available in text templates.",
                ""
            };

            string[] footerText = new string[]
            {
                "",
                "************************************************************************",
                "",
                "> Last updated on {0}",
                "> This page is generated by a tool. Any changes will be lost on the next update cycle.",
                ""
            };

            writer.WriteLine(string.Join(Environment.NewLine, headText));            

            var visitor = new MarkdownVisitor(builtinClassNames);
            members.Accept(visitor);

            writer.WriteLine(visitor.Toc);

            foreach (var classWriter in visitor.ClassWriters.OrderBy(c => c.Key).Select(c => c.Value))
            {
                writer.Write(classWriter.Head);
                writer.Write(classWriter.Body);
            }

            writer.WriteLine();
            writer.WriteLine(string.Format(string.Join(Environment.NewLine, footerText), DateTime.Now.ToString()));
            writer.Flush();
            writer.Close();
        }
    }
}
