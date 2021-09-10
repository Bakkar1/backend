using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_mvc.Moddels
{
    public class MockEmployeeReository : IEmployeeRepository
    {
        public MockEmployeeReository()
        {
            employeeList = new List<Employee>()
            {
                new Employee(){Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@gmail.com"},
                new Employee(){Id = 2, Name = "Sam", Department = Dept.Payroll, Email = "sam@gmail.com"}
            };

        }
        private List<Employee> employeeList;
        public Employee GetEmployee(int id)
        {
            //var result = from employee in employeeList
            //              where employee.Id == id
            //              select employee;
            //return result.FirstOrDefault();

            return employeeList.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return employeeList;
        }

        public Employee Add(Employee employee)
        {
            // new id = the max id of de list + 1
            employee.Id = employeeList.Max(employee => employee.Id) + 1;
            employeeList.Add(employee);
            return employee;
        }


        public Employee Update(Employee employeeChanges)
        {
            Employee employee = employeeList.FirstOrDefault(emp => emp.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
        Employee IEmployeeRepository.Delete(int id)
        {
            Employee employee = employeeList.FirstOrDefault(emp => emp.Id == id);
            if (employee != null)
            {
                employeeList.Remove(employee);
            }
            return employee; ;
        }
    }
}
