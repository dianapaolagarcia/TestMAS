using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataRepository;
using EmployeeApp.Model;
namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAPIController : ControllerBase
    {

        [HttpGet()]
        public ActionResult<List<Employee>> Get()
        {

            EmployeeContext employeeContext = new EmployeeContext();


            List<Employee> data = employeeContext.GetEmployeeAsync("http://masglobaltestapi.azurewebsites.net/api/Employees").Result;



            return data;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)

        {
            EmployeeContext employeeContext = new EmployeeContext();


            List<Employee> data = employeeContext.GetEmployeeAsync("http://masglobaltestapi.azurewebsites.net/api/Employees").Result;

            Employee _employee = new Employee();

            _employee = data.Find(x => x.id == id);

            return _employee;
        }

    }
}