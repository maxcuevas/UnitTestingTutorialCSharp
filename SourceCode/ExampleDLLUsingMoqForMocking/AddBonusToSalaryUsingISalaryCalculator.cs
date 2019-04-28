using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;


[assembly: InternalsVisibleTo("ExampleDLLUsingMoqForMockingUnitTest")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

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
