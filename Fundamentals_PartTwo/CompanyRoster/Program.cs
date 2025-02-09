namespace CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int numberOfInputs=int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine().Split();
                Employee currentEmployee = new(input[0], decimal.Parse(input[1]), input[2]);
                employees.Add(currentEmployee);
            }
            
            foreach (Employee employee in employees)
            {
                decimal totalSalaryOfDepartment = employees.Where(e=> e.DepartmentName == employee.DepartmentName).Sum(s=>s.Salary);
                decimal totalCountOfDepartment = employees.Where(e => e.DepartmentName == employee.DepartmentName).Count();
                employee.AverageSalary = totalSalaryOfDepartment / totalCountOfDepartment;
            }
            List<Employee> orderedEmployees =employees.OrderByDescending(s => s.AverageSalary).ThenByDescending(s=>s.Salary).ToList();
            string bestDepartment = orderedEmployees[0].DepartmentName;
            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            foreach (Employee employee in orderedEmployees.Where(e=> e.DepartmentName==bestDepartment))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }

        public class Employee
        { 
            public Employee(string name, decimal salary, string department)
            {
                Name = name;
                Salary = salary;
                DepartmentName = department;
            }
            public string Name { get; set; }
            public decimal Salary { get; set; }
            public string DepartmentName { get; set; }
            public decimal AverageSalary { get; set; }
          
        }
       
    }
}
