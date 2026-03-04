using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Mini_Project1
{
	public class StudService : IStudent
	{
		
		private readonly string _connectionString =
			"Server=.;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;";

		//  إضافة طالب جديد
		public void AddStudent(Student student)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				string query = "INSERT INTO Students (Name, Age, Grade) VALUES (@Name, @Age, @Grade)";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					command.Parameters.AddWithValue("@Name", student.Name);
					command.Parameters.AddWithValue("@Age", student.Age);
					command.Parameters.AddWithValue("@Grade", student.Grade);

					connection.Open();
					command.ExecuteNonQuery();
				}
			}

			Console.WriteLine("Student saved to database successfully.");
		}

		// 🔹 تنفيذ الإضافة عبر التفاعل مع المستخدم
		public void AddStudentInteractive(Student student)
		{
			AddStudent(student);
		}

		// 🔹 جلب جميع الطلاب من قاعدة البيانات
		public List<Student> ShowStudents()
		{
			var students = new List<Student>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				string query = "SELECT Id, Name, Age, Grade FROM Students";
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							students.Add(new Student(
								(int)reader["Id"],
								reader["Name"].ToString(),
								(int)reader["Age"],
								reader["Grade"].ToString()
							));
						}
					}
				}
			}

			return students;
		}
	}
}