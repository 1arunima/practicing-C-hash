// using System;

// namespace EnumExample
// {
//     // Define an enum for Days of the Week
//     enum DaysOfWeek
//     {
//         Sunday,    // Default value 0
//         Monday,    // 1
//         Tuesday =5,
//         Wednesday, // 3
//         Thursday,  // 4
//         Friday,    // 5
//         Saturday   // 6
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Declare and assign an enum value
//             DaysOfWeek today = DaysOfWeek.Wednesday;

//             // Display the enum value
//             Console.WriteLine("Today is: " + today);

//             // Cast enum to int
//             int dayNumber = (int)today;
//             Console.WriteLine("Day Number: " + dayNumber);

//             // Assign enum using an integer
//             DaysOfWeek anotherDay = (DaysOfWeek)4;
//             Console.WriteLine("Another day: " + anotherDay);

//             // Iterate through all enum values
//             Console.WriteLine("All days of the week:");
//             foreach (string day in Enum.GetNames(typeof(DaysOfWeek)))
//             {
//                 Console.WriteLine(day);
//             }
//         }
//     }
// }
