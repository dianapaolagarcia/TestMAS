using System;

namespace EmployeeApp.Model
{

    public interface IEmployee
    {
         int id { get; set; }
         string name { get; set; }
         string contractTypeName { get; set; }
         int roleId { get; set; }
         string roleName { get; set; }
         string roleDescription { get; set; }
         decimal hourlySalary { get; set; }
         decimal monthlySalary { get; set; }
    }


    public interface IEmployeeDTO
    {
        int id { get; set; }
        string name { get; set; }
         string contractTypeName { get; set; }
         int roleId { get; set; }
         string roleName { get; set; }
         string roleDescription { get; set; }
         decimal hourlySalary { get; set; }
         decimal monthlySalary { get; set; }
         decimal yearlySalary { get;  }
    }

    public class Employee: IEmployee
    {

        public int id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
        public decimal hourlySalary { get; set; }
        public decimal monthlySalary { get; set; }
    }
}
