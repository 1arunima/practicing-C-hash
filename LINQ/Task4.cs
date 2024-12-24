


using System.Diagnostics.Contracts;
using System.Text.Json;

public class Students {
    public int Id {get;set;}

    public string Name {get;set;}

    public int Age {get;set;}
    public string Major{get;set;}
    public string Email{get;set;}
    public  List<string> Skills{get;set;}
    public List<StudentCourses>StudentCourses{get;set;}
    public List<Awards>Awards{get;set;}
}

public class StudentCourses{
    public string Name {get;set;}
    public int Credits{get;set;}
    public string Grade{get;set;}
}

public class Awards{
    public string Name{get;set;}
    public int Year{get;set;}

}

public class Majors{
    public int Id{get;set;}
    public string Name{get;set;}
}

public class Courses{
    public string Name{get;set;}
    public string Department{get;set;}
    public int MaxCredits{get;set;}
    public string Semester{get;set;}
}

public class AllStudents{
    public List<Students>Students{get;set;}
    public List<Majors>Majors{get;set;}
    public List<Courses>Courses{get;set;}
}


public class Data{
    public static void Main()
    {
        string jsonString ="""
{
  "Students": [
    {
      "Id": 1,
      "Name": "Emma Stone",
      "Age": 20,
      "Major": "Computer Science",
      "Email": "emma.stone@example.com",
      "Skills": ["Python", "Machine Learning", "Data Analysis"],
      "StudentCourses": [
        {"Name": "AI Foundations", "Credits": 3, "Grade": "A"},
        {"Name": "Data Structures", "Credits": 4, "Grade": "A-"}
      ],
      "Awards": [
        {"Name": "Dean's List", "Year": 2023},
        {"Name": "Coding Excellence", "Year": 2022}
      ]
    },
    {
      "Id": 2,
      "Name": "Liam Johnson",
      "Age": 23,
      "Major": "Electrical Engineering",
      "Email": "liam.johnson@example.com",
      "Skills": ["Circuit Design", "Embedded Systems", "Mathematics"],
      "StudentCourses": [
        {"Name": "Control Systems", "Credits": 3, "Grade": "B+"},
        {"Name": "Signal Processing", "Credits": 4, "Grade": "A"}
      ],
      "Awards": [
        {"Name": "Research Grant", "Year": 2023}
      ]
    },
    {
      "Id": 3,
      "Name": "Sophia Brown",
      "Age": 25,
      "Major": "Mathematics",
      "Email": "sophia.brown@example.com",
      "Skills": ["Statistics", "R", "Machine Learning"],
      "StudentCourses": [
        {"Name": "Probability Theory", "Credits": 3, "Grade": "A+"},
        {"Name": "Data Analysis", "Credits": 3, "Grade": "A"}
      ],
      "Awards": []
    }
  ],
  "Majors": [
    {"Id": 1, "Name": "Computer Science"},
    {"Id": 2, "Name": "Electrical Engineering"},
    {"Id": 3, "Name": "Mathematics"}
  ],
  "Courses": [
    {"Name": "AI Foundations", "Department": "CS", "MaxCredits": 4, "Semester": "Fall"},
    {"Name": "Control Systems", "Department": "EE", "MaxCredits": 4, "Semester": "Spring"},
    {"Name": "Probability Theory", "Department": "Math", "MaxCredits": 3, "Semester": "Fall"}
  ]
}
""";



    AllStudents?studentsDetails=JsonSerializer.Deserialize<AllStudents>(jsonString);
   //1. List all students proficient in "Machine Learning" who are below 22 years old and sort them by their grade point average (GPA) in descending order.
     //GradeMApping

     var gradeMap = new Dictionary<string,double>{
            { "A+", 4.3 }, { "A", 4.0 }, { "A-", 3.7 },
            { "B+", 3.3 }, { "B", 3.0 }, { "B-", 2.7 },
            { "C+", 2.3 }, { "C", 2.0 }, { "C-", 1.7 },
            { "D+", 1.3 }, { "D", 1.0 }, { "F", 0.0 }
     };

     Console.WriteLine("1. Question ");

     var question1 = studentsDetails.Students.Where(s=>s.Skills.Contains("Machine Learning")&& s.Age>22)
                    .Select(s=>new{
                      studentName=s.Name,
                      GPA =s.StudentCourses.Select(c=>gradeMap[c.Grade]).Average()
                    }).OrderByDescending(s=>s.GPA);


        foreach(var item in question1){
          Console.WriteLine($"name :{item.studentName},GPA:{item.GPA:F2}");
        }

      //2.Retrieve a list of students along with their major names, total credits completed, and the average grade they achieved.
          Console.WriteLine("\n 2. Question ");
        var question2 =studentsDetails.Students.Select(s=> new {
                        StudentName =s.Name,
                        Majorname =s.Major,
                        TotalCredits=s.StudentCourses.Sum(c=>c.Credits),
                        averageGrade=s.StudentCourses.Select
                        (c=>gradeMap[c.Grade]).Average()
        });

        foreach(var item in question2){
          Console.WriteLine($"Name: {item.StudentName} MajorName:{item.Majorname} Total Credits:{item.TotalCredits} Average Grade :{item.averageGrade}");
        }

        //3.Find all students who have received more than one award and list their names along with the names of the awards.
          Console.WriteLine("\n 3. Question");
          var question3 = studentsDetails.Students.Where(s=>s.Awards.Count>1)
                                                  .Select(s=> new {
                                                    studentName =s.Name,
                                                    Awards =s.Awards.Select(b=>b.Name)
                                                  });

                  foreach( var item in question3){
                      Console.WriteLine($" Name :{item.studentName}");
                      Console.WriteLine("Awards :");
                      foreach (var award in item.Awards)
                      {
                        Console.WriteLine($" - {award}");
                      }
                  }  

         //4.  Group students by their major and calculate the total number of credits completed and the average GPA for each major.
          Console.WriteLine("\n 4. Question ");
           var question4 = studentsDetails.Students.GroupBy(s=>s.Major)
                                                    .Select(g=> new {
                                                      MajorName = g.Key,
                                                      TotalCredits=g.Sum(s=>s.StudentCourses.Sum(c=>c.Credits)),
                                                      AveageGPA = g.Average(s=>s.StudentCourses.Select(c=>gradeMap[c.Grade]).Average())
                                                    });


              foreach (var item in question4)
              {
                Console.WriteLine($" Major :{item.MajorName}");
                Console.WriteLine($" Total credits :{item.TotalCredits}");
                Console.WriteLine($" Average :{item.AveageGPA}");
              }  


              //5. Find all courses offered in the "Fall" semester that have a maximum of 4 credits and list the students enrolled in those courses.

         Console.WriteLine("\n 5. Question");
             var question5 = studentsDetails.Courses.Where(c=>c.Semester=="Fall" && c.MaxCredits<=4)
                                                    .Select(course=> new {
                                                      CourseName =course.Name,
                                                      EnrolledStudents= studentsDetails.Students.Where(s=>s.StudentCourses.Any(sc=>sc.Name==course.Name)).Select(s=>s.Name)
                                                    });

                      foreach (var item in question5)
                      {
                        Console.WriteLine($"Course offered in fall :{item.CourseName} ");

                        foreach(var student in item.EnrolledStudents){
                          Console.WriteLine($"Enrolled Students :{student}");
                        }

                      }
    }


}