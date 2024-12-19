using System;
using System.Linq;
using System.Collections.Generic;



public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public List<string> Hobbies { get; set; }

    // Constructor
    public Person(string name, int age, string email, List<string> hobbies)
    {
        Name = name;
        Age = age;
        Email = email;
        Hobbies = hobbies;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Step 2: Create a list of Person objects
        var people = new List<Person>
        {
            new Person("John Doe", 28, "john.doe@example.com", new List<string> { "Reading", "Swimming", "Coding" }),
            new Person("Jane Smith", 34, "jane.smith@example.com", new List<string> { "Painting", "Running", "Cycling" }),
            new Person("Sam Brown", 22, "sam.brown@example.com", new List<string> { "Gaming", "Music", "Cooking" }),
            new Person("Emily White", 45, "emily.white@example.com", new List<string> { "Gardening", "Photography", "Traveling" }),
            new Person("Michael Green", 29, "michael.green@example.com", new List<string> { "Hiking",  "Swimming" })
        };

        //1. older than 30
        var  olderThan= people.Where(s=>s.Age>30);
        Console.WriteLine($"older than 30:");

        foreach(var person in olderThan){
               Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
        }

        //2.Name and Email
        Console.WriteLine(" -----      Extract only the names and email addresses of all people.");


        var NameEmail =people.Select(s=> new { s.Name, s.Email});

        foreach(var person in NameEmail){
            Console.WriteLine($"Name:{person.Name} Email:{person.Email}");
        }


        //3. Sort the list of people by age in ascending order.

        var sorting = people.OrderBy(s=>s.Age);

        Console.WriteLine("---------- sorted the people in ascending order");
        foreach (var person in sorting)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
        }



        //4.Group people by the first letter of their name.

        var groupByFirstLetter = people.GroupBy(s => s.Name[0]).ToList();

        Console.WriteLine("--------People grouped by the first letter of their name:");
       foreach (var group in groupByFirstLetter)
        {
          Console.WriteLine($"Group: {group.Key}"); // Correct usage of group.Key
         foreach (var person in group)
        {
        Console.WriteLine($"  Name: {person.Name}, Age: {person.Age}, Email: {person.Email}");
         }
       Console.WriteLine();
     }


     //5. Find the average age of all people in the dataset.

        var avgAge = people.Average(s=>s.Age);
        Console.WriteLine($"Average age of the people :{avgAge:F2}");


        // 6.Find the first person who has "Swimming" as a hobby.

         var personWithSwimming =people.FirstOrDefault(s=>s.Hobbies.Contains("Swimming"));

         if(personWithSwimming!=null){
            Console.WriteLine("-------the first person with swimming as a hobby " );
            Console.WriteLine($" Name ;{personWithSwimming.Name} , Age:{personWithSwimming.Age}");
         }



        //7. List the names of people who are older than 25 and have "Cycling" as a hobby.

        var whole = people.Where(p=>p.Age >25 && p.Hobbies.Contains("Cycling")).Select(p=>p.Name);

        Console.WriteLine("---------People who are older than 25 and have 'Cycling' as a hobby ");
        foreach (var item in whole)
        {
            Console.WriteLine(item);
        }
       //8. Count the number of people who have more than two hobbies
        var moreThan2Hobbies= people.Count(s=>s.Hobbies.Count>2);

        Console.WriteLine($"Number of people who have more than two hobbies: {moreThan2Hobbies} ");

       // 9. Check if there is any person whose name starts with 'E'

        var nameStartsE = people.Any(s=>s.Name.StartsWith("E"));
        
        Console.WriteLine($" Name starts with E {nameStartsE}");

      var personWithE =people.FirstOrDefault(p=>p.Name.StartsWith("E"));
        if(personWithE!=null){
            Console.WriteLine( $" the name starts with E:{personWithE.Name}");

        }else{
            Console.WriteLine(" No person with E");
        }



      //  10. List all unique hobbies in the dataset.

      var  uniqueHobby = people.SelectMany(p=>p.Hobbies.Distinct());
      Console.WriteLine("unique Hobbies are");
      foreach(var item in uniqueHobby){
        Console.WriteLine(item);

      }
        //  find the person with Maxium Age 


        var maximumAge = people.OrderByDescending(p=>p.Age).First();

       
        Console.WriteLine($" maximum age of the person {maximumAge.Age}");


        //Find the average number of hobbies for all people.


        var avgHobbies =people.Average(p=>p.Hobbies.Count);
         Console.WriteLine($"avarageHobbies{avgHobbies}");
       


    }

}