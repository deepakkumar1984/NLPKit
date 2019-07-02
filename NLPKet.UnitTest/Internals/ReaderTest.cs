using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLPKit.Internals;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLPKet.UnitTest.Internals
{
    [TestClass]
    public class ReaderTest
    {
        [TestMethod]
        public void ReadStringTest()
        {
            var (s, p) = Reader.ReadString("\"Hello\", world\"!", 0);
            Assert.AreEqual(s, "Hello");
        }

        [TestMethod]
        public void ReadIntTest()
        {
            var (s, p) = Reader.ReadInt("\"Hello\", 458 world\"!", 0);
            Assert.AreEqual(s, 458);
        }

        [TestMethod]
        public void ReadNumberTest()
        {
            var (s, p) = Reader.ReadNumber("Value of PI: 3.148!", 0);
            Assert.AreEqual(s, 3.148f);
        }
    }
}
