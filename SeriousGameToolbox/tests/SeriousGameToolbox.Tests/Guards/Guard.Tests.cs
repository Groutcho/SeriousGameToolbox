﻿using NUnit.Framework;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SGT = SeriousGameToolbox.Guards;

namespace SeriousGameToolbox.Tests.Guards
{
    [TestFixture]
    [Category("Guards")]
    public class Guard_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GuardAgainstArgumentNull()
        {
            SGT.Guard.AgainstNullArgument("success", Deliberate.Null as object);
        }

        [Test]
        public void GuardAgainstArgumentNull_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => SGT.Guard.AgainstNullArgument("success", new object()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GuardAgainstNullString()
        {
            SGT.Guard.AgainstNullOrEmptyString("theString", Deliberate.Null as string);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GuardAgainstEmptyString()
        {
            SGT.Guard.AgainstNullOrEmptyString("theString", string.Empty);
        }

        [Test]
        public void GuardAgainstEmptyString_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => SGT.Guard.AgainstNullOrEmptyString("theString", "not empty"));
        }
    }
}
