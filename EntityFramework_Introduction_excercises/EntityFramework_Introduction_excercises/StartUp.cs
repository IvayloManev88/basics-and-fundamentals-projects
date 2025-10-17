using Microsoft.VisualBasic;
using SoftUni.Data;
using SoftUni.Models;
using System.Diagnostics.Metrics;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();
            context.Database.EnsureCreated();
            Console.WriteLine(RemoveTown(context));
        }
        //03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {

                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                }).ToArray();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return sb.ToString().Trim();

        }

        //04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return sb.ToString().Trim();
        }

        //05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Department.Name.Equals("Research and Development"))
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }
            return sb.ToString().Trim();
        }

        //06

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            const string newAddressString = "Vitoshka 15";
            const int newAddressTownId = 4;

            /*
            Address newAddress = new Address()
            {
                TownId = newAddressTownId,
                AddressText = newAddressString
            };
            Employee nakovEmployee = context.Employees.First(e => e.LastName.Equals("Nakov"));
            nakovEmployee.Address = newAddress;

            context.SaveChanges();
            */
            string[] addresses = context.Employees
                .Where(e => e.AddressId.HasValue)
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();
            return String.Join(Environment.NewLine, addresses);

        }

        private static void RollbackDB(SoftUniContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        //07

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    ManagerFirstName = e.Manager,
                    ManagerLastName = e.Manager,
                    Project = e.EmployeesProjects
                        .Select(p => p.Project)
                        .Where(p => p.StartDate.Year >= 2001 &&
                                    p.StartDate.Year <= 2003)
                        .Select(p => new
                        {
                            ProjectName = p.Name,
                            ProjectStartDate = p.StartDate,
                            ProjectEndDate = p.EndDate
                        }).ToArray()
                })
                .Take(10)
                .ToArray();

            foreach ( var e in employees )
            {
                sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Project)
                {
                    string startDateFormat = p.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt");
                    string endDateFormat = p.ProjectEndDate.HasValue ? p.ProjectEndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";
                    sb.AppendLine($"--{p.ProjectName} - {startDateFormat} - {endDateFormat}");
                }
            }
            return sb.ToString().TrimEnd();
        }
        //08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            
            var addresses= context.Addresses
                .Select(a=> new
                {
                    a.AddressText,
                    TownName=a.Town.Name,
                    Count = a.Employees.Count()
                    
                })
                .OrderByDescending(e=>e.Count)
                .ThenBy(t=>t.TownName)
                .ThenBy(e=>e.AddressText)
                .Take (10) .ToArray();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.Count} employees");
            }
            return sb.ToString().TrimEnd();

        }
        //09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects.
                        Select(p => new
                        {
                          ProjectName=  p.Project.Name
                        })
                        .OrderBy(p=>p.ProjectName)
                        .ToArray()

                }).First();
            sb.AppendLine($"{employees.FirstName} {employees.LastName} - {employees.JobTitle}");
            foreach (var p in employees.Projects)
            {
                sb.AppendLine($"{p.ProjectName}");
            }
            return sb.ToString().TrimEnd();
        }
        //10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var departments = context.Departments
                .Where(e=>e.Employees.Count()>5)
                .OrderBy(e => e.Employees.Count())
                .Select(d=>new
                {
                    DepartmentName=d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    EmployeesForProjects = d.Employees
                    .Select(e=> new
                    {
                        EmpFirstName = e.FirstName,
                        EmpLastName = e.LastName,
                        EmpJobTitle=e.JobTitle
                    })
                    .OrderBy(e=>e.EmpFirstName)
                    .ThenBy(e =>e.EmpLastName)
                    .ToArray()

                }).ToArray();
            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName}  {d.ManagerLastName}");
                foreach (var e in d.EmployeesForProjects)
                {
                    sb.AppendLine($"{e.EmpFirstName} {e.EmpLastName} - {e.EmpJobTitle}");
                }
                
            }
            return sb.ToString().TrimEnd();
        }
        //11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10).ToArray();
            var selectedProjects = projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderBy(p=>p.Name)
                .ToArray();

            foreach (var  p in selectedProjects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }
            return sb.ToString().TrimEnd();
        }

        //12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departmentsForRaise = new string[]
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };
            StringBuilder sb = new StringBuilder();
            var employeesRaises = context.Employees
                .Where(e => departmentsForRaise.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e=>e.LastName).ToList();
            foreach (var employee in employeesRaises)
            {
                employee.Salary = employee.Salary * 1.12m;
            }
            context.SaveChanges();
            foreach (var e in employeesRaises)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        //13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e=>e.FirstName)
                .ThenBy(e=>e.LastName)
                .Select(e=> new
                {
                    e.FirstName, 
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                }).ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();


        }

        //14
        public static string DeleteProjectById(SoftUniContext context)
        {
            const int projectIdToDelete = 2;
            IEnumerable<EmployeeProject> employeeProjectToDelete = context.EmployeesProjects.Where(p => p.ProjectId == projectIdToDelete).ToArray();
            context.EmployeesProjects.RemoveRange(employeeProjectToDelete);
            Project projectToDelete = context.Projects.Where(p => p.ProjectId == projectIdToDelete).First();
            if (projectToDelete != null)
            {
                context.Projects.Remove(projectToDelete);
            }

            context.SaveChanges();
            string[] projectNames = context.Projects.Select(p => p.Name).ToArray();
            return String.Join(Environment.NewLine, projectNames);
        }

        //15
        public static string RemoveTown(SoftUniContext context)
        {
            
            IEnumerable<Employee> employeeWithSeattle = context.Employees.Where(e => e.Address!=null&&e.Address.Town.Name.Equals("Seattle"));
            foreach (Employee e in employeeWithSeattle)
            {
                e.AddressId = null;
            }
            IEnumerable<Address> addressesToRemove = context.Addresses.Where(a => a.Town.Name.Equals("Seattle"));
            int count = addressesToRemove.Count();
            foreach (Address a in addressesToRemove)
            {
                context.Addresses.Remove(a);
            }
            context.Towns.Remove(context.Towns.First(t => t.Name.Equals("Seattle")));
            context.SaveChanges();
            return $"{count} addresses in Seattle were deleted";


        }
    }
}
