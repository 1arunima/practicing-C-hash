// using System ;
// using System.Linq;
// using System.Collections.Generic;
// using System.Globalization;
// using System.Diagnostics.Contracts;



// // class Program {
// //     static void Main(){
// //         List<int> numbers =new List<int>{1,2,3,4,5,6,7,8};

// //         var evenNum= numbers.Where(num=>num%2==0);

// //         foreach (var number in evenNum)
// //         {
// //              Console.WriteLine(number);
// //         }

// //     }
// // }


// class Student
// {
//     public int StudentID { get; set; }
//     public string StudentName { get; set; }
//     public int Age { get; set; }

//     public string Grade { get; set;}
// }

// class Program2
// {
//     static void Main()
//     {
//             var studentList = new List<Student>() { 
//             new Student() { StudentID = 1, StudentName = "John", Age = 13 , Grade= "C"} ,
//             new Student() { StudentID = 2, StudentName = "Moin",  Age = 15 ,Grade= "A" } ,
//             new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 ,Grade= "C"} ,
//             new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, Grade= "B"} ,
//             new Student() { StudentID = 5, StudentName = "Ron" , Age = 15,Grade= "B"  } 
//         };



//          var groupedByGrade= studentList.GroupBy(s=>s.Grade);


//          Console.WriteLine("Students grouped by Grade:");
//          foreach(var group in groupedByGrade){
//             Console.WriteLine($" Grade:{group:key}");
//             foreach(var student in group){
//                 Console.WriteLine($"- {student.StudentName}");
//             }
//          }


    

//           var StudentName = new List<string>{"Arunima ", "Pranu", "Sreya Shine"};

//           var containsName = StudentName.Contains("Arunima ");
//           Console.WriteLine($"it is there: {containsName}");


//             // order by


//             var sortedNames = StudentName.OrderByDescending(name => name);
//             Console.WriteLine("sorted  namesa are :");

//             foreach(var name in sortedNames) {
//                 Console.WriteLine(name);
//             }


//             // select 
//              var nameJoin =StudentName.Select(s=>StudentName);
//              Console.WriteLine(string.Join(", ", StudentName));
//           // checking the student exists 

//             bool studentExists = studentList.Any(s => s.StudentID == 10);
//         Console.WriteLine($"Student with ID 2 exists: {studentExists}");

//         //to add a student 

//              studentList.Add(new Student(){ StudentID=6,StudentName="usman",Age=19});

//              var StudentRemove =studentList.FirstOrDefault(s=>s.StudentID==9);

//              if(StudentRemove!=null){
//                     studentList.Remove(StudentRemove);  
//              }

//         // LINQ Method 
//         var teenAgerStudents = studentList.Where(s => s.Age > 12 && s.Age < 20)
//                                           .ToList();

//         // Display Results
//         Console.WriteLine("Teenager Students:");
//         foreach (var student in teenAgerStudents)
//         {
//             Console.WriteLine($"Name: {student.StudentName}, Age: {student.Age}");
//         }
//     }
// }