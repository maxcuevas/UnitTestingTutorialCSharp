using System;
using ExampleDLLProjectForUnitTestDependingOnAnotherClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ExampleDLLUsingMoqForMockingUnitTest
{
    [TestClass]
    public class MoqExample
    {
        AddBonusToSalaryUsingISalaryCalculator subject;
        Mock<ISalaryCalculator> mockISalaryCalculator;


        [TestInitialize]
        public void setUp()
        {
            mockISalaryCalculator = new Mock<ISalaryCalculator>();
            subject = new AddBonusToSalaryUsingISalaryCalculator(mockISalaryCalculator.Object);

        }

        [TestMethod]
        public void calculateYearlySalary_GivenSalary100e5_Return110e5()
        {
            mockISalaryCalculator.Setup(mock => mock.calculateSalary()).Returns((int)100e5);

            int expected = (int)110e5;
            int actual = subject.calculateYearlySalary();

            Assert.AreEqual(expected, actual);

        }
    }
}
