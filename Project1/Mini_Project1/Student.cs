using System;
using System.Collections.Generic;
using System.Text;

namespace Mini_Project1
{
    public class Student
    {
      
            // Properties
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Grade { get; set; }

        // Default constructor
        public Student()
            {
            
            }

        // Constructor (original 3-arg kept for compatibility)
        public Student(string name, int age, string grade)
            {
                Name = name;
                Age = age;
                Grade = grade;
            }

            // Constructor that accepts Id + other fields (fixes CS1729)
            public Student(int id, string name, int age, string grade)
            {
                Id = id;
                Name = name;
                Age = age;
                Grade = grade;
            }

            // Method
           /* public void PrintInfo()
            {
                Console.WriteLine($"Id: {Id} | Name: {Name} | Age: {Age} | Grade: {Grade}");
            }*/
       

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, " +
                   $"Grade: {Grade}";
        }
    }
}
