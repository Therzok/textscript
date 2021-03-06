﻿// -----------------------------------------------------------------------
// <copyright file="ScriptMemberIgnoreAttribute.cs" repo="TextScript">
//     Copyright (C) 2018 Lizoc Inc. <http://www.lizoc.com>
//     The source code in this file is subject to the MIT license.
//     See the LICENSE file in the repository root directory for more information.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Lizoc.TextScript.Runtime
{
    [AttributeUsage(AttributeTargets.Field| AttributeTargets.Property|AttributeTargets.Method)]
    public class ScriptMemberIgnoreAttribute : Attribute
    {
    }
}