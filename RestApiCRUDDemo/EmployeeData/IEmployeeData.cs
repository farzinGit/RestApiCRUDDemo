using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This is a service interface To fetch data 

namespace RestApiCRUDDemo.EmployeeData
{
    public interface IEmployeeData //We added "public"
    {
        //Get a list of Employees
        List<Employee> GetEmployees(); //Return a list of employee

        //Returning a single Employee
        Employee GetEmployee(Guid id);

        //Add Employee Method
        Employee AddEmployee(Employee employee);

        //Delete
        void DeleteEmployee(Employee employee);

        //Edit
        Employee EditEmployee(Employee employee);
    }
}
