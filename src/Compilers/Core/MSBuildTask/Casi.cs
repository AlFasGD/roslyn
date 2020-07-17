// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable enable

using System;
using System.Text;
using Microsoft.Build.Framework;

namespace Microsoft.CodeAnalysis.BuildTasks
{
    public class Casi : InteractiveCompiler
    {
        #region Properties - Please keep these alphabetized.

        // These are the parameters specific to Casi.

        #endregion

        #region Tool Members
        /// <summary>
        /// Return the name of the tool to execute.
        /// </summary>
        protected override string ToolNameWithoutExtension => "csi";
        #endregion

        #region Interactive Compiler Members
        protected override void AddResponseFileCommands(CommandLineBuilderExtension commandLine)
        {
            commandLine.AppendSwitchIfNotNull("/lib:", AdditionalLibPaths, ",");
            commandLine.AppendSwitchIfNotNull("/loadpaths:", AdditionalLoadPaths, ",");
            commandLine.AppendSwitchIfNotNull("/imports:", Imports, ";");

            Casc.AddReferencesToCommandLine(commandLine, References, isInteractive: true);

            base.AddResponseFileCommands(commandLine);
        }
        #endregion
    }
}
