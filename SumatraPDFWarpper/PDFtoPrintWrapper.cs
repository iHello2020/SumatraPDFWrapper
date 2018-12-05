﻿using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace SumatraPDFWarpper
{
    public class SumatraPDFWarpper
    {
        private static readonly string utilPath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "SumatraPDF.exe");
        private static readonly TimeSpan printTimeout = new TimeSpan(0, 1, 0);

        /// <summary>
        /// Runs new SumatraPDF.exe process with passed parameters
        /// </summary>
        /// <param name="filePath">Path to a PDF file.</param>
        /// <param name="printerName">Name of a printer (if the printer is network, use network format e.g. "\\printmachine\defaultprinter").</param>
        /// <param name="timeout">Printing timeout. If SumatraPDF.exe process isn't exited after this timeout, the process will be killed. Default value is 1 minute.</param>
        /// <returns>Asynchronous task.</returns>
        public async Task Print(
            string filePath, string printerName, TimeSpan? timeout = null)
        {
            using (var proc = new Process
            {
                StartInfo =
                    {
                    WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = utilPath,
                        Arguments = $@"-silent -print-to ""{printerName}"" ""{filePath}""",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
            })
            {
                proc.Start();
                bool result = await proc.WaitForExitAsync(timeout ?? printTimeout);
                if (!result)
                {
                    proc.Kill();
                }
            }
        }
    }
}