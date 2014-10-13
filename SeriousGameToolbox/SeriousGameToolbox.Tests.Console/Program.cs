using SeriousGameToolbox.Data.Texts;
using SeriousGameToolbox.I2D.Tests.Controls;
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
            Bubbling_Tests t = new Bubbling_Tests();
            t.Event_Is_Bubbled_All_The_Way_Up();
        }
    }
}
