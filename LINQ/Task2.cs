// using System;
// using System.Collections.Generic;
// using System.Linq; 

// public class Project
// {
//     public string Name { get; set; } =string.Empty;
//     public int HoursWorked { get; set; }
// }

// public class Employee
// {
//     public int ID { get; set; }
//     public string Name { get; set; } =string.Empty;
//     public int Age { get; set; }
//     public int DepartmentId { get; set; }
//     public string Email { get; set; } =string.Empty;
//     public List<Project> Projects { get; set; } =new List<Project>();
// }

// public class Department
// {
//     public int Id { get; set; }
//     public string Name { get; set; } =string.Empty;
// }

// public class EmployeeData
// {
//     public List<Employee> Employees { get; set; } = new List<Employee>(); 
//     public List<Department> Departments { get; set; } = new List<Department>(); 
// }
// class Program
// {
//     static void Main(string[] args)
//     {
//         var employeeData = new EmployeeData
//         {
//             Departments = new List<Department>
//             {
//                 new Department { Id = 1, Name = "Development" },
//                 new Department { Id = 2, Name = "Marketing" }
//             },
//             Employees = new List<Employee>
//             {
//                 new Employee
//                 {
//                     ID = 1,
//                     Name = "Alice Johnson",
//                     Age = 30,
//                     DepartmentId = 1,
//                     Email = "alice.johnson@example.com",
//                     Projects = new List<Project>
//                     {
//                         new Project { Name = "Project A", HoursWorked = 120 },
//                         new Project { Name = "Project B", HoursWorked = 100 }
//                     }
//                 },
//                 new Employee
//                 {
//                     ID = 2,
//                     Name = "Bob Smith",
//                     Age = 42,
//                     DepartmentId = 2,
//                     Email = "bob.smith@example.com",
//                     Projects = new List<Project>
//                     {
//                         new Project { Name = "Project A", HoursWorked = 200 },
//                         new Project { Name = "Project C", HoursWorked = 150 }
//                     }
//                 },
//                 new Employee
//                 {
//                     ID = 3,
//                     Name = "Carol White",
//                     Age = 25,
//                     DepartmentId = 1,
//                     Email = "carol.white@example.com",
//                     Projects = new List<Project>
//                     {
//                         new Project { Name = "Project B", HoursWorked = 90 },
//                         new Project { Name = "Project C", HoursWorked = 110 }
//                     }
//                 }
//             }
//         };

//          // Find employees who are older than 30 and work in the "Development" department


//         var question1=employeeData.Employees.Where(e=>e.Age>30&&employeeData.Departments.Any( d=>d.Id== e.DepartmentId && d.Name=="Development"));

//         foreach(var employees in question1){
//                 Console.WriteLine($"employees who are older than 30 and work in the  department{employees}");
//         }
     
//     }
// }
