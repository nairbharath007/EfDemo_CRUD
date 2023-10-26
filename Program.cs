using EfDemo.Data;
using EfDemo.Repository;

namespace EfDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployeeRepository repository = new EmployeeRepository(new MyContext());
            var employees = repository.GetAll();
            Console.WriteLine($"Id\tEmpName\tAddress\t\tSalary");
            Console.WriteLine(new String('-', 50));
            foreach( var employee in employees ) 
            {
                Console.WriteLine($"{employee.Id}\t{employee.EmpName}" +
                    $"\t{employee.Address}\t\t{employee.Salary}");
                Console.WriteLine(new string('-',50));
            }
            Console.WriteLine("Enter EmpId: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var employee1 = repository.GetById(id);
            if (employee1 != null)
            {
                Console.WriteLine($"Emp Name: {employee1.EmpName}\n Address: {employee1.Address}" +
                    $"\nSalary:{employee1.Salary}");
            }
            else
                Console.WriteLine("No such employee found");
        }
    }
}