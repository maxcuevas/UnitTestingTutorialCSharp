using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleDLLProjectForUnitTestDependingOnAnotherClass
{
    class AddBonusToSalaryUsingISalaryCalculator
    {
        ISalaryCalculator salaryCalculator;

        public AddBonusToSalaryUsingISalaryCalculator(ISalaryCalculator salaryCalculator)
        {
            this.salaryCalculator = salaryCalculator;
        }

        public int calculateYearlySalary()
        {
            return (int)(salaryCalculator.calculateSalary() * 1.1);
        }
    }
}
