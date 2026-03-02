using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Mini_Project1
{
    public class StudService : IStudent
    {
        private List<Student> _students;
        private int _index = 1;

        public StudService()
        {
            _students = new List<Student>();
        }

        #region AddStudentInteractive

        public void AddStudentInteractive(Student student)
        {
            if (student != null)
            {
                student.Id = _index++;
                _students.Add(student);
                Console.WriteLine("Student Added Successfully\n");
            }
            else
            {
                Console.WriteLine("Student not added");
            }
        }

        #endregion

        #region ShowStudents

        public List<Student> ShowStudents()
        {
            return _students.ToList();
        }

        #endregion

    }
}