using EfDemo.Data;
using EfDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo.Repository
{
    internal class EmployeeRepository: IEmployeeRepository
    {
        private MyContext _context;
        public EmployeeRepository(MyContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }
        public Employee GetById(int id) 
        {
            return _context.Employees.Where(empl => empl.Id == id).FirstOrDefault();
        }

        public int Add(Employee employee) //id will not be a part of object
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            var newEmpId = _context.Employees.Where(empl => empl.EmpName == employee.EmpName)
                .OrderBy(empl => empl.Id).LastOrDefault().Id;
            return newEmpId;
        }

        public bool Update(Employee employee) //id is req in object
        {
            var emplyeeToUpdate = GetById(employee.Id);
            if (emplyeeToUpdate != null)
            {
                _context.Entry(emplyeeToUpdate).State = EntityState.Detached;
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int EmpId)
        {
            var employeeToDelete = GetById(EmpId);
            if(employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
