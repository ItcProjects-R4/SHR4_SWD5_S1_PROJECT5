namespace Mini_Project1
{
	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public string Grade { get; set; }

		public Student() { }

		public Student(string name, int age, string grade)
		{
			Name = name;
			Age = age;
			Grade = grade;
		}

		public Student(int id, string name, int age, string grade)
		{
			Id = id;
			Name = name;
			Age = age;
			Grade = grade;
		}

		public override string ToString()
		{
			return $"ID: {Id}, Name: {Name}, Age: {Age}, Grade: {Grade}";
		}
	}
}