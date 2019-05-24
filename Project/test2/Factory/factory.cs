using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataRepository;
using EmployeeApp.Model;

namespace test2.Factory
{
    

    

    abstract class Creator
    {
        public abstract IEmployeeDTO FactoryMethod(string type);
    }

    class ConcreteCreator : Creator
    {
        public override IEmployeeDTO FactoryMethod(string type)
        {
            switch (type)
            {
                case "Monthly": return new MonthlyEmployeeDTO();
                case "Hourly": return new HourlyEmployeeDTO();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }

}
