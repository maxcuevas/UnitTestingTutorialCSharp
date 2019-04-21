using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleDLLProjectForUnitTestDependingOnAnotherClass
{
    class AddsBonusToSalary
    {
        SalaryCalculator salaryCalculator;

        public AddsBonusToSalary(SalaryCalculator salaryCalculator)
        {
            this.salaryCalculator = salaryCalculator;
        }

        public double calculateYearlySalary()
        {
            return salaryCalculator.calculateSalary() * 1.1;
        }
    }
}
