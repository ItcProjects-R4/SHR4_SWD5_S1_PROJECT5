using System;
using System.Collections.Generic;

namespace Mini_Project1
{
    internal class Program
    {
        private static StudService _studentService;
       
        static void Main(string[] args)
        {
            _studentService = new StudService();
            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("------------------------------------------------------------------------------------");

                switch (choice)
                {
                    case "1":
                        AddStudentInteractive();
                        Console.WriteLine("");
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                    case "2":
                        ShowStudents();
                        Console.WriteLine("");
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                    case "3":
                        exit = true;
                        Console.WriteLine("Exiting application...");
                        Console.WriteLine("");
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.WriteLine("");
                        Console.WriteLine("------------------------------------------------------------------------------------");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }


        static void DisplayMenu()
        {
            Console.WriteLine("\t\t\t\t================================================");
            Console.WriteLine("\t\t\t\t        Student Management System               ");
            Console.WriteLine("\t\t\t\t================================================");
            Console.WriteLine("\t\t\t\t==           1 - Add Student                  ==");
            Console.WriteLine("\t\t\t\t==           2 - Show Students                ==");
            Console.WriteLine("\t\t\t\t==           3 - Exit                         ==");
            Console.WriteLine("\t\t\t\t================================================");

            Console.Write("Enter your choice: ");
        }

        static void AddStudentInteractive()
        {
            Console.WriteLine("\n\t\t\t\t=== ADD Student ===");

            try
            {
                var student = new Student();

                Console.Write("Enter Name: ");
                student.Name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = 0;
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    student.Age = age;
                }
                else
                {
                    Console.WriteLine("Invalid age input. Age will be set to 0.");
                }
                Console.Write("Enter Grade: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal grade))
                {
                    student.Grade = grade.ToString();
                }
                _studentService.AddStudentInteractive(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
            }

        }
            static void ShowStudents()
            {
            Console.WriteLine("\n\t\t\t=== Students List ===");
            var students = _studentService.ShowStudents();

            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }
            Console.WriteLine("\t\t+------+--------------------+-----+-------+");
            Console.WriteLine("\t\t| ID   | Name               | Age | Grade |");
            Console.WriteLine("\t\t+------+--------------------+-----+-------+");

            foreach (var s in students)
            {
                Console.WriteLine($"\t\t| {s.Id,-4} | {s.Name,-18} | {s.Age,-3} | {s.Grade,-5} |");
            }

            Console.WriteLine("\t\t+------+--------------------+-----+-------+");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine($"Total Students: {students.Count}");
      
        }
    }
}
