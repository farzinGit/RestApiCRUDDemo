using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDDemo.EmployeeData;
using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//In this controller we need 5 Employee Methods
//1. Get All Employees 
//2. Get a single Employee
//3. Add an Employee
//4. Edit and employee
//5. Delete and employee
//Source : https://www.youtube.com/watch?v=r4LlIhyQ9GY

namespace RestApiCRUDDemo.Controllers
{

    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //We need to inject IEmployeeData into our controller
        //So we need to head to startup > Service section

        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)  //We need to make IEmployeeData public so we don't get an error here
        {
            _employeeData = employeeData;
        }
        [HttpGet] //We specify our httpMethod
        [Route("api/[controller]")] //We move the rout from top to here
        public IActionResult GetEmployees()
        {
            //We want to return data we are getting from MockEmployeeData
            return Ok(_employeeData.GetEmployees());  //We have to wrap it into Ok object we are passing Data back as http OK result

        }

        //Second method to get a single employee based in ID
        [HttpGet] //We specify our httpMethod
        [Route("api/[controller]/{id}")] //We move the rout from top to here
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                //We want to return data we are getting from MockEmployeeData
                return Ok(employee);  //We have to wrap it into Ok object we are passing Data back as http OK result
            }
            return NotFound($"Employee with id: {id} was not found");

        }

        //Third method to add a single employee based in ID
        [HttpPost] //We specify our httpMethod
        [Route("api/[controller]")] //We dont need ID to add a new employee
        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);

        }

        //Delete method 
        [HttpDelete] //We specify our httpMethod
        [Route("api/[controller]/{id}")] //We need ID to delete an employee
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"Employee with id: {id} was not found");
        }

        //Update method 
        [HttpPatch] //We specify our httpMethod
        [Route("api/[controller]/{id}")] //We need ID to delete an employee
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            if (existingEmployee != null)
            {
                employee.Id = existingEmployee.Id;
                _employeeData.EditEmployee(employee);
                
            }
            return Ok(employee);
        }
    }

}
