using NUnit.Framework;
using SeriousGameToolbox.Controllers.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Controllers.Phases
{
    [TestFixture]
    [Category("Phases")]
    public class PhaseCompletedEventArgs_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullPhase_ThrowsArgumentNullException()
        {
            new PhaseOutput(null);
        }
    }
}
