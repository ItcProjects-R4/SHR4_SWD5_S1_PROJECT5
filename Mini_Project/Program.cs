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
				Console.WriteLine("\n------------------------------------------------------------------------------------");

				switch (choice)
				{
					case "1":
						AddStudentInteractive();
						Console.WriteLine("\n------------------------------------------------------------------------------------");
						break;
					case "2":
						ShowStudents();
						Console.WriteLine("\n------------------------------------------------------------------------------------");
						break;
					case "3":
						exit = true;
						Console.WriteLine("Exiting application...");
						Console.WriteLine("\n------------------------------------------------------------------------------------");
						break;
					default:
						Console.WriteLine("Invalid option. Please try again.");
						Console.WriteLine("\n------------------------------------------------------------------------------------");
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
				Console.Write("Enter Name: ");
				string name = Console.ReadLine();

				int age;
				Console.Write("Enter Age: ");
				while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
				{
					Console.Write("Invalid age. Enter a valid positive number: ");
				}

				Console.Write("Enter Grade: ");
				string grade = Console.ReadLine() ?? string.Empty;

				var student = new Student(name, age, grade);
				_studentService.AddStudentInteractive(student);

				Console.WriteLine("\nStudent Added:");
				Console.WriteLine(student);
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
			Console.WriteLine($"Total Students: {students.Count}");
		}
	}
}