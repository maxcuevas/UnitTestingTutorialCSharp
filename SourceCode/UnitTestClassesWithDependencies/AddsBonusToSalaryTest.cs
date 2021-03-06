﻿using System;
using ExampleDLLProjectForUnitTestDependingOnAnotherClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestClassesWithDependencies
{
    [TestClass]
    public class AddsBonusToSalaryTest
    {
        AddsBonusToSalary subject;

        [TestMethod]
        public void calculateYearlySalary_GivenEmployeeAge8_ReturnInt()
        {
            subject = new AddsBonusToSalary(new SalaryCalculator(8));

            int expected = (int)88e3;
            double actual = subject.calculateYearlySalary();

            Assert.AreEqual(expected, actual);
        }
    }
}
