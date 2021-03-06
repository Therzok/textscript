﻿// -----------------------------------------------------------------------
// <copyright file="SpecialChar.cs" repo="TextScript">
//     Copyright (C) 2018 Lizoc Inc. <http://www.lizoc.com>
//     The source code in this file is subject to the MIT license.
//     See the LICENSE file in the repository root directory for more information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Lizoc.TextScript.Parsing
{
    internal class SpecialChar
    {
        public const char EscapeChar = '^';
        public const char Null = (char)0;
        public const char NewLine = '\n';
        public const char CarriageReturn = '\r';
        public const char Backspace = '\b';
        public const char FormFeed = '\f';
        public const char Tab = '\t';
        public const char VerticalTab = '\v';
        public const char SingleQuote = '\'';
        public const char DoubleQuote = '"';
    }
}