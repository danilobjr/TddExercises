using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddExercises.Main.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var isTrue = true;

            Assert.IsTrue(isTrue);
        }
    }
}
