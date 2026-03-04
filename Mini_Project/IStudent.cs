using System.Collections.Generic;

namespace Mini_Project1
{
	public interface IStudent
	{
		void AddStudentInteractive(Student student);
		List<Student> ShowStudents();
	}
}