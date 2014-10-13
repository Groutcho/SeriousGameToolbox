using SeriousGameToolbox.Data.Texts;
using SeriousGameToolbox.I2D.Tests.Controls;
using SeriousGameToolbox.Logging;
using SeriousGameToolbox.Tests.Controllers;
using SeriousGameToolbox.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGameToolbox.Tests.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = Logger.Instance;

            log.AddChannel(new FileLoggerChannel(@"c:\temp\coco.txt") { PreciseTimestamp = true });

            log.Log("toto");
        }
    }
}
