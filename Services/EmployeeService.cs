using edu.Models;
using Newtonsoft.Json;

namespace edu.Services
{
    public class EmployeeService
    {
        private readonly string filePath = 
            Path.Combine(Directory.GetCurrentDirectory(), "employees.json");

        public List<Employee> ReadEmployees()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var employees = JsonConvert.DeserializeObject<List<Employee>>(json);
                return employees ?? [];
            }
            return new List<Employee>();
        }


        public void WriteEmployees(List<Employee> employees)
        {
            var intojson = 
                JsonConvert.SerializeObject(
                    employees, Newtonsoft.Json.Formatting.Indented
                );
            File.WriteAllText(filePath, intojson);
        }

        public void AddEmployee(Employee employee)
        {
            var employees = ReadEmployees();

            employees.Add(employee);

            WriteEmployees(employees);
        }


        public void DeleteEmployee(int employeeId)
        {
            var employees = ReadEmployees();

            foreach (var employee in employees)
            {
                if (employee.EmployeeID == employeeId)
                {
                    employees.Remove(employee);
                    break;
                }
            }
        }


        public void UpdateEmployeeDesignation(int employeeId, string newDesignation)
        {
            var employees = ReadEmployees();

            foreach (var employee in employees)
            {
                if (employee.EmployeeID == employeeId)
                {
                    employee.Designation = newDesignation;

                    WriteEmployees(employees);
                    return;
                }
            }
        }


        public List<Employee> GetEmployeesByLanguage(string languageName, int score)
        {
            var employees = ReadEmployees();
            var empsWithLang = new List<Employee>();

            foreach (var employee in employees)
            {
                foreach (var language in employee.KnownLanguages)
                {
                    if (language.LanguageName == languageName && language.ScoreOutof100 > score)
                    {
                        empsWithLang.Add(employee);
                        break;
                    }
                }
            }

            return empsWithLang;
        }
        public Employee? SearchById(int employeeId)
        {
            var employees = ReadEmployees();
            foreach(var Employee in employees)
            {
                if(Employee.EmployeeID == employeeId)
                {
                    return Employee;
                }
            }
            return null;
        }

    }
}
