// using System.Text.Json;
// using System.Text.Json.Serialization;
// using System.Linq;
// using Microsoft.VisualBasic;
// using System.Text.RegularExpressions;

// public class Employee
// {
//   public int Id { get; set; }


//   public string name { get; set; }


//   public int age { get; set; }


//   public int DepartmentId { get; set; }


//   public string email { get; set; }


//   public List<string> skills { get; set; }


//   public List<EmployeeProject> projects { get; set; }


//   public List<Evaluation> evaluations { get; set; }
// }

// public class EmployeeProject
// {

//   public string name { get; set; }


//   public int hoursWorked { get; set; }


//   public string role { get; set; }
// }

// public class Evaluation
// {

//   public int year { get; set; }


//   public double score { get; set; }
// }

// public class Department
// {
//   public int Id { get; set; }


//   public string name { get; set; }
// }

// public class Project
// {

//   public string name { get; set; }

//   public int budget { get; set; }


//   public string deadline { get; set; }
// }

// public class EmployeesDetails
// {

//   public List<Employee> employees { get; set; }
//   public List<Department> departments { get; set; }


//   public List<Project> projects { get; set; }
// }

// public class Data
// {
//   public static void Main()
//   {
//     string jsonString = """
//         {
//           "employees": [
//             {
//               "Id": 1,
//               "name": "Alice Johnson",
//               "age": 30,
//               "DepartmentId": 1,
//               "email": "alice.johnson@example.com",
//               "skills": ["C#", "SQL", "Azure"],
//               "projects": [
//                 {"name": "Project A", "hoursWorked": 120, "role": "Lead"},
//                 {"name": "Project B", "hoursWorked": 100, "role": "Developer"}
//               ],
//               "evaluations": [
//                 {"year": 2023, "score": 4.5},
//                 {"year": 2022, "score": 4.7}
//               ]
//             },
//             {
//               "Id": 2,
//               "name": "Bob Smith",
//               "age": 42,
//               "DepartmentId": 2,
//               "email": "bob.smith@example.com",
//               "skills": ["Marketing", "SEO", "Content Strategy"],
//               "projects": [
//                 {"name": "Project A", "hoursWorked": 200, "role": "Manager"},
//                 {"name": "Project C", "hoursWorked": 150, "role": "lead"}
//               ],
//               "evaluations": [
//                 {"year": 2023, "score": 4.2},
//                 {"year": 2022, "score": 4.0}
//               ]
//             },
//             {
//               "Id": 3,
//               "name": "Carol White",
//               "age": 25,
//               "DepartmentId": 1,
//               "email": "carol.white@example.com",
//               "skills": ["JavaScript", "Vue.js", "CSS"],
//               "projects": [
//                 {"name": "Project B", "hoursWorked": 90, "role": "Developer"},
//                 {"name": "Project C", "hoursWorked": 110, "role": "Frontend Lead"}
//               ],
//               "evaluations": [
//                 {"year": 2023, "score": 4.8},
//                 {"year": 2022, "score": 4.6}
//               ]
//             }
//           ],
//           "departments": [
//             {"Id": 1, "name": "Development"},
//             {"Id": 2, "name": "Marketing"}
//           ],
//           "projects": [
//             {"name": "Project A", "budget": 50000, "deadline": "2024-12-31"},
//             {"name": "Project B", "budget": 30000, "deadline": "2024-06-30"},
//             {"name": "Project C", "budget": 40000, "deadline": "2024-09-30"}
//           ]
//         }
//         """;

//     EmployeesDetails? employeesDetails = JsonSerializer.Deserialize<EmployeesDetails>(jsonString);

//     // 1. Find all employees who are proficient in "SQL" and sort them by age in descending order.

//     var question1 = employeesDetails.employees
//         .Where(e => e.skills.Contains("SQL"))
//         .OrderByDescending(e => e.age);

//     Console.WriteLine("Employees proficient in SQL sorted by age (descending):");
//     foreach (var employee in question1)
//     {
//       Console.WriteLine($"Name: {employee.name}, Age: {employee.age}");
//     }


//     //2. Retrieve a list of employees along with the names of their departments and the total budget of the projects they are working on.
//     // kitillaa
//     var question2 = employeesDetails.employees.Select(employee =>
// {

//   var department = employeesDetails.departments
//         .Where(d => d.Id == employee.DepartmentId).Select(k => k.name).FirstOrDefault();

//   // Calculate the total budget of projects the employee is working on
//   var totalBudget = employee.projects
//         // .Where(p => employeesDetails.projects.Any(pr => pr.name == p.name))
//         .Sum(p => employeesDetails.projects.First(pr => pr.name == p.name).budget);

//   return new
//   {
//     EmployeeName = employee.name,
//     DepartmentName = department,
//     TotalBudget = totalBudget
//   };
// });

//     // // Print the results
//     Console.WriteLine("\nEmployees with department names and total budget of projects:");
//     foreach (var result in question2)
//     {
//       Console.WriteLine($"Name: {result.EmployeeName}, Department: {result.DepartmentName}, Total Budget: {result.TotalBudget}");
//     }



//     //3. List the names of employees and the total number of hours they have worked on all projects.

//     var question3 = employeesDetails.employees.Select(employee =>
//     {
//       var totalHoursWorked = employee.projects.Sum(p => p.hoursWorked);

//       return new
//       {
//         employeeName = employee.name,
//         totalWorked = totalHoursWorked

//       };


//     });

//     Console.WriteLine("\nEmployees and the total number of hours they have worked on all projects:");
//     foreach (var item in question3)
//     {
//       Console.WriteLine($" Name of the Employess:{item.employeeName} TotalHours Worked {item.totalWorked}");
//     }
//     // 4. Group employees by the department and list the average evaluation score for each department for the year 2023

//     var question4 = employeesDetails.employees
//                    .GroupBy(employee => employee.DepartmentId)
//                    .Select(group =>
                   

//                       new
//                      {
//                        DepartmentName = employeesDetails.departments
//                         .FirstOrDefault(department => department.Id == group.Key)?.name,
//                        AverageScore = group
//                       .SelectMany(employee => employee.evaluations
//                       .Where(evaluation => evaluation.year == 2023))
//                       .Average(evaluation => evaluation.score)
//                      }
//                    );


//     Console.WriteLine("\nAverage evaluation score for each department in 2023:");
//     foreach (var item in question4)
//     {
//       Console.WriteLine($"Department :{item.DepartmentName}, AverageScore in 2023  {item.AverageScore}");
//     }

//   //5. Find all projects that have a deadline within the next 6 months and list the employees involved in those projects.

//     DateTime newDate =DateTime.Now.AddMonths(6);
//      var question5 =employeesDetails.projects.Where(i=>DateTime.TryParse(i.deadline,out DateTime deadlineDate)&& deadlineDate<newDate).Select(i=>i.name);
//      var finalAns5=employeesDetails.employees
//     //  .Where(i=>i.projects.Any(j=>question5.Contains(j.name)))
//      .Select(k=>new {EmpName=k.name , ProjectName=k.projects.Where(j=>question5.Contains(j.name)).Select(k=>k.name)});
//      Console.WriteLine("Find all projects that have a deadline within the next 6 months");
//      foreach(var i  in finalAns5){
//         Console.WriteLine(i.EmpName);
//          foreach(var j in i.ProjectName){
//           Console.WriteLine(j);
//          }
//      }  


//      //6. List employees who have worked on more than one project in a managerial role (e.g., "Lead" or "Manager").

// var question6 = employeesDetails.employees
//     .Where(e => e.projects.Count(p => 
//         p.role.Equals("Lead", StringComparison.OrdinalIgnoreCase) || 
//         p.role.Equals("Manager", StringComparison.OrdinalIgnoreCase)) > 1)
//     .Select(e => new
//     {
//         EmployeeName = e.name,
//         ManagerialProjects = e.projects
//             .Where(p => 
//                 p.role.Equals("Lead", StringComparison.OrdinalIgnoreCase) || 
//                 p.role.Equals("Manager", StringComparison.OrdinalIgnoreCase))
//             .Select(p => p.name)
//     });

// Console.WriteLine("\nEmployees who have worked on more than one project in a managerial role:");
// foreach (var item in question6)
// {
//     Console.WriteLine($"Name: {item.EmployeeName}");
//     Console.WriteLine("Managerial Projects:");
//     foreach (var projectName in item.ManagerialProjects)
//     {
//         Console.WriteLine($"- {projectName}");
//     }
// }


// //7. List all unique skills possessed by employees, ordered alphabetically.

// var question7 = employeesDetails.employees.SelectMany(e=>e.skills).Distinct().OrderBy(skill=>skill);


// Console.WriteLine("\nUnique skills possessed by employees (ordered alphabetically):");
// foreach(var skill in question7){
//   Console.WriteLine(skill);
// }

//       //8. Calculate the total budget for all projects and the average project budget.

//       var question8 = new {
//         TotalBudget=employeesDetails.projects.Sum(p=>p.budget),
//         AverageBudget =employeesDetails.projects.Average(p=>p.budget)

//       };
//       Console.WriteLine($"\n Total Budget for All Projects  {question8.TotalBudget}");
//        Console.WriteLine($" Total Average for All Projects  {question8.AverageBudget}");
    
//     //9. Check if there are any employees who have a perfect evaluation score (5.0) for any year.

//     var question9 =  employeesDetails.employees.Where(e=>e.evaluations.Any(ev=>ev.score==4.0))
//                                                 .Select(e=> new {
//                                                   EmpName= e.name,
//                                                   PerfectScores =e.evaluations
//                                                   .Where(ev => ev.score == 4.0)
//                                                   .Select(ev => ev.year)
//        });

//        Console.WriteLine("\n employess with a perfect evaluation Score 4.0");
//        foreach(var item in question9){
//         Console.WriteLine($" Name :{item.EmpName} ");
//         foreach( var year in item.PerfectScores){
//           Console.WriteLine($"-{year}");
//         }
//        }

//      //  10. Create a summary report listing each department's name, total number of employees, total hours worked on projects, and average evaluation score.


//      var question10 = employeesDetails.departments.Select(dept=>new {
//              deptName= dept.name,
//              TotalEmp =employeesDetails.employees.Count(e=>e.DepartmentId==dept.Id),
//              TotalHousWorked =employeesDetails.employees.Where(e=>e.DepartmentId==dept.Id).SelectMany(e=>e.projects).Sum(p=>p.hoursWorked),
//              AverageEvaluationScore= employeesDetails.employees.Where(e=>e.DepartmentId==dept.Id).SelectMany(e=>e.evaluations).Average(ev=>ev.score)       
//      });

//      Console.WriteLine("\n Department Summary Report:");
//      foreach(var dept in question10){
//       Console.WriteLine($"Department :{dept.deptName}");
//        Console.WriteLine($"Total employees :{dept.TotalEmp}");
//         Console.WriteLine($"Total Hours worked :{dept.TotalHousWorked}");
//            Console.WriteLine($"Total Average Evaluation Score:{dept.AverageEvaluationScore}");
//      }

//     // 11. For each project, list the names of the employees involved, their roles, and the total hours worked on that project

// var projectDetails = employeesDetails.projects.Select(proj => new
// {
//     ProjectName = proj.name,
//     Employees = employeesDetails.employees
//         .Where(e => e.projects.Any(p => p.name == proj.name))
//         .Select(e => new
//         {
//             EmployeeName = e.name,
//             Role = e.projects.First(p => p.name == proj.name).role,
//             HoursWorked = e.projects.First(p => p.name == proj.name).hoursWorked
//         }),
//     TotalHoursWorked = employeesDetails.employees
//         .Where(e => e.projects.Any(p => p.name == proj.name))
//         .SelectMany(e => e.projects)
//         .Where(p => p.name == proj.name)
//         .Sum(p => p.hoursWorked)
// });

// Console.WriteLine("\nProject Details:");
// foreach (var project in projectDetails)
// {
//     Console.WriteLine($"Project: {project.ProjectName}");
//     Console.WriteLine($"Total Hours Worked: {project.TotalHoursWorked}");
//     Console.WriteLine("Employees Involved:");
//     foreach (var emp in project.Employees)
//     {
//         Console.WriteLine($"- Name: {emp.EmployeeName}, Role: {emp.Role}, Hours Worked: {emp.HoursWorked}");
//     }
//     Console.WriteLine();
// }

// //12. Generate a flat list of employee-project pairs showing the employee's name, project name, role, and hours worked.


//    var EmployeeProjectPairs =employeesDetails.employees.SelectMany(employee=>employee.projects,(employee,project)=>new {
//                   EmpName =employee.name,
//                   projName=project.name,
//                   Role=project.role,
//                   HoursWorked=project.hoursWorked

//    });
//    Console.WriteLine("\n Employee-project Pairs:");
//    foreach(var item in EmployeeProjectPairs){
//     Console.WriteLine($"Employee :{item.EmpName}, Project:{item.projName}, Role:{item.Role}, HoursWorked:{item.HoursWorked}");
//    }

    
//   }
// }
