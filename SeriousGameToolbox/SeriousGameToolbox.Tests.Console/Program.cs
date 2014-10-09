using SeriousGameToolbox.Tests.Controllers;
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
            Game_Tests test = new Game_Tests();

            test.FakeGame_ChainsThreePhasesSuccessfully();
        }
    }
}
