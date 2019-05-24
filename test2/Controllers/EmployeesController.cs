using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataRepository;
using test2.Models;
using EmployeeApp.Model;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace test2.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Employees()
        {

            List<IEmployeeDTO> model = callAPI("");





            return View(model);
        }

        [HttpPost]
        public ActionResult EmployeesByID(string txtID)
        {

            string idemployee = txtID;
            List<IEmployeeDTO> model = callAPI(idemployee);
            return View("Employees",model);
        }


        public List<IEmployeeDTO> callAPI(string id)
        {
            IEnumerable<Employee> employeelst = null;

            Employee _employeeresult = null;
            IEmployeeDTO _employee;
            List<IEmployeeDTO> model = new List<IEmployeeDTO>();

            using (var client = new HttpClient())
            {

               
                //client.BaseAddress = new Uri("https://localhost:44394/api/EmpAPI/");
                //HTTP GET
                var uriString = string.Format("{0}/{1}", "https://localhost:44394/api/EmpAPI", id);

                var responseTask = client.GetAsync(uriString);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    if (id == "")
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                    readTask.Wait();
                    
                        employeelst = readTask.Result;
                        


                        foreach (Employee item in employeelst) // Loop through List with foreach
                        {
                            if (item.contractTypeName == "HourlySalary")
                            {
                                _employee = new HourlyEmployeeDTO();
                                _employee.id = item.id;
                                _employee.name = item.name;
                                _employee.contractTypeName = item.contractTypeName;
                                _employee.roleId = item.roleId;
                                _employee.roleName = item.roleName;
                                _employee.roleDescription = item.roleDescription;
                                _employee.monthlySalary = item.monthlySalary;
                                _employee.hourlySalary = item.hourlySalary;
                            }
                            else
                            {
                                _employee = new MonthlyEmployeeDTO();
                                _employee.id = item.id;
                                _employee.name = item.name;
                                _employee.contractTypeName = item.contractTypeName;
                                _employee.roleId = item.roleId;
                                _employee.roleName = item.roleName;
                                _employee.roleDescription = item.roleDescription;
                                _employee.monthlySalary = item.monthlySalary;
                                _employee.hourlySalary = item.hourlySalary;
                            }
                            model.Add(_employee);
                        }
                    }
                    else
                    {
                        var readTask = result.Content.ReadAsAsync<Employee>();
                        readTask.Wait();
                        _employeeresult = readTask.Result;

                        if (_employeeresult.contractTypeName == "HourlySalary")
                        {
                            _employee = new HourlyEmployeeDTO();
                            _employee.id = _employeeresult.id;
                            _employee.name = _employeeresult.name;
                            _employee.contractTypeName = _employeeresult.contractTypeName;
                            _employee.roleId = _employeeresult.roleId;
                            _employee.roleName = _employeeresult.roleName;
                            _employee.roleDescription = _employeeresult.roleDescription;
                            _employee.monthlySalary = _employeeresult.monthlySalary;
                            _employee.hourlySalary = _employeeresult.hourlySalary;
                        }
                        else
                        {
                            _employee = new MonthlyEmployeeDTO();
                            _employee.id = _employeeresult.id;
                            _employee.name = _employeeresult.name;
                            _employee.contractTypeName = _employeeresult.contractTypeName;
                            _employee.roleId = _employeeresult.roleId;
                            _employee.roleName = _employeeresult.roleName;
                            _employee.roleDescription = _employeeresult.roleDescription;
                            _employee.monthlySalary = _employeeresult.monthlySalary;
                            _employee.hourlySalary = _employeeresult.hourlySalary;
                        }
                        model.Add(_employee);
                    }
                    
                }
                else //web api sent error response 
                {
                    //log response status here..

                    employeelst = Enumerable.Empty<Employee>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }


            
            return model;
        }

    }
}