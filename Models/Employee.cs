using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo.Models
{
    internal class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }

        public string Address { get; set; }

        public double Salary { get; set; }
    }
}
