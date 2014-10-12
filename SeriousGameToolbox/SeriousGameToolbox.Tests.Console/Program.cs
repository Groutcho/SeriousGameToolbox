using SeriousGameToolbox.Data.Texts;
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
            FileObject_Tests t = new FileObject_Tests();
            t.StringOperator_Returns_CorrectValue();
        }
    }
}
