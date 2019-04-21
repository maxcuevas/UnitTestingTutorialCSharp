using System;
using ExampleDLLProjectForUnitTestDependingOnAnotherClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestClassesWithDependencies
{
    [TestClass]
    public class AddsBonusToSalaryTest
    {
        AddsBonusToSalary subject;

        [TestMethod]
        public void calculateYearlySalary_GivenEmployeeAge8_ReturnDouble()
        {
            subject = new AddsBonusToSalary(new SalaryCalculator(8));

            double expected = 88000;
            double actual = subject.calculateYearlySalary();

            Assert.AreEqual(expected,actual);
        }
    }
}
