using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
    public class MockEmplyeeData : IEmployeeData
    {
        //Hardcoding some data for our MockDataSet
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id= Guid.NewGuid(),
                Name  = "Farzin Fakhraddini"
            },
                   new Employee()
            {
                Id= Guid.NewGuid(),
                Name  = "Mehrdad Koofiani"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
