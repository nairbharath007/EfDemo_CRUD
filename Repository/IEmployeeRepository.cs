using EfDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo.Repository
{
    internal interface IEmployeeRepository
    {
        public List<Employee> GetAll();

        public Employee GetById(int id);

    }
}
