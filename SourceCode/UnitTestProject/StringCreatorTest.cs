using System;
using ExampleDLLProjectForUnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class StringCreatorTest
    {
        private StringCreator subject;

        [TestInitialize]
        public void setUp() {
            subject = new StringCreator();
        }

        [TestMethod]
        public void getStringToReturn()
        {

            string expected = "I expect this string to return";
            string actual = subject.getStringToReturn(expected);

            Assert.AreEqual(expected, actual);
        }
    }
}
