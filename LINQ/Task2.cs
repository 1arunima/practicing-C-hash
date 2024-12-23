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
//                     Age = 35,
//                     DepartmentId = 1,
//                     Email = "alice.johnson@example.com",
//                     Projects = new List<Project>
//                     {
//                         new Project { Name = "Project A", HoursWorked =90 },
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

//         // 1. Find employees who are older than 30 and work in the "Development" department


//         var question1 = employeeData.Employees.Where(e =>e.Age > 30 && employeeData.Departments.Any(d => d.Id == e.DepartmentId && d.Name == "Development"));
      
//        foreach (var employee in question1)
//         {
//          Console.WriteLine($"Employee Name: {employee.Name}, Age: {employee.Age}, Department: Development");
//         }


//         // 2. Retrieve the names of employees along with their department names.
//          var question2 = employeeData.Employees.Select(e=>new {
//             employeeName =e.Name,
//             DepartmentName=employeeData.Departments.FirstOrDefault(d=>d.Id ==e.DepartmentId)?.Name

//          });

//         foreach(var item in question2){
//             Console.WriteLine($"Retrieve the names of employees along with their department names  Employee Name: {item.employeeName}, Department Name: {item.DepartmentName}");
//         }

//         //3. List the names of employees and the total hours they have worked across all projects


//         var question3 = employeeData.Employees.Select(e=>new{
//             employeeName =e.Name,
//             TotalHoursWorked = e.Projects.Sum(p=>p.HoursWorked)
//         });

//         foreach(var item in question3){
//             Console.WriteLine($" Name of the employee:{item.employeeName},Hours Worked :{item.TotalHoursWorked}" );
//         }


//         //4. Group employees by department and calculate the average age of employees in each department---------manasilayilla



//            var question4 = employeeData.Employees.GroupBy(e => e.DepartmentId).Select(g => new
//                {
//                  DepartmentId = g.Key,
//                  DepartmentName = employeeData.Departments.FirstOrDefault(d => d.Id == g.Key)?.Name,
//                 AverageAge = g.Average(e => e.Age) 
//              });
//            foreach (var item in question4){

//           Console.WriteLine($"Department: {item.DepartmentName}, Average Age: {item.AverageAge}");
//            }


//           //5. Find the name of the employee who worked the most hours on "Project A".
             
//             var question5 = employeeData.Employees
//             .Select(e => new
//             {
//                 EmployeeName = e.Name,
//                 TotalHoursWorked = e.Projects
//                     .Where(p => p.Name == "Project A") 
//                     .Sum(p => p.HoursWorked)
//             })
//             .OrderByDescending(e => e.TotalHoursWorked) 
//             .FirstOrDefault(); 

//         if (question5 != null && question5.TotalHoursWorked > 0)
//         {
//             Console.WriteLine($"Employee with most hours on Project A: {question5.EmployeeName} with {question5.TotalHoursWorked} hours.");
//         }
//         else
//         {
//             Console.WriteLine("No employee worked on Project A.");
//         }
                    
//         // 6.  Extract a list of employees with their names and the names of projects they have worked on.
//          var question6 = employeeData.Employees.Select(e=>new {
//             EmployeeName =e.Name,
//             ProjectNames = string.Join(",", e.Projects.Select(p=>p.Name))
//             });

//             foreach (var item in question6)
//               {
//          Console.WriteLine($"Employee Name: {item.EmployeeName}, Projects: {item.ProjectNames}");
//            }

//          // 7.  List the names of employees who have worked more than 100 hours on any single project.


//          var question7 = employeeData.Employees.Where(e=>e.Projects.Any(p=>p.HoursWorked>100))
//                                                 .Select(e=>e.Name);
        
//             foreach(var item in question7){
//                 Console.WriteLine($"Employeee Name:{item}");
//             }

//         //8. Check if there is any employee who has worked on "Project D".

//         var question8 =  employeeData.Employees.Where(e=>e.Projects.Any(p=>p.Name == "Project D"));

        
//             if(question8.Any()){
//                 Console.WriteLine("there is atleast one employeee ");
//             }else{
//                 Console.WriteLine("there is no employee worked on Project D");
//             }


//             //9.  List all unique project names across all employees.

//             var question9 = employeeData.Employees.SelectMany(p=>p.Projects).Select(p=>p.Name).Distinct();
//             foreach(var item in question9){
//                 Console.WriteLine($"Unique Project Name:{item}");



//             }
//             //10. Calculate the total number of hours worked by all employees combined.



//             var question10 = employeeData.Employees.SelectMany(e=>e.Projects).Sum(p=>p.HoursWorked);

//             Console.WriteLine($"total number of hours worked by all empployess combined:{question10}");

//     }
// }
