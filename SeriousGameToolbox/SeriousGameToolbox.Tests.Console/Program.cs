using SeriousGameToolbox.Data.Texts;
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
            XmlTextContainerSerializer serializer = new XmlTextContainerSerializer();

            serializer.Parse(Properties.Resources.text_container_1);
        }
    }
}
