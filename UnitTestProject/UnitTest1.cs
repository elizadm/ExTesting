using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Decision dec = new Decision();
            Assert.AreEqual(true, dec.Solution("txt1.txt"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Decision dec = new Decision();
            Assert.AreEqual(false, dec.Solution("nonexistent.txt"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Decision dec = new Decision();
            Assert.AreEqual(false, dec.Solution("txt2.txt"));
        }

    }
}
