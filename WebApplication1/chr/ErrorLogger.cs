using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHR
{
    static public class ErrorLogger
    {
        static public void AddError(Exception err)
        {
            string[] errorLines =
            {
                "=====================================================================",
                "FATAL ERROR: " + err.GetType(),
                "TIME OF ERROR: "+ System.DateTimeOffset.Now.ToString(),
                err.ToString(),
                "====================================================================="
            };

            System.IO.File.AppendAllLines(@"logs\errorlog.txt", errorLines);
        }
    }
}