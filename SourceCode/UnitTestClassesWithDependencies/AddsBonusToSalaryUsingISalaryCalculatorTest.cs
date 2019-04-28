using System;
using ExampleDLLProjectForUnitTestDependingOnAnotherClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestClassesWithDependencies
{
    [TestClass]
    public class AddsBonusToSalaryUsingISalaryCalculatorTest
    {
        AddBonusToSalaryUsingISalaryCalculator subject;

        [TestMethod]
        public void calculateYearlySalary_GivenSalaryOf100000_Return110000()
        {
            subject = new AddBonusToSalaryUsingISalaryCalculator(new MySalaryCalculator());

            int expected = (int)110e3;
            int actual = subject.calculateYearlySalary();

            Assert.AreEqual(expected, actual);
        }

    }

    public class MySalaryCalculator : ISalaryCalculator
    {
        public int calculateSalary()
        {
            return (int)100e3;
        }
    }
}
