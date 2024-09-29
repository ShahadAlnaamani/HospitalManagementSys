using System;
using System.Security.Cryptography.X509Certificates;


namespace HospitalManagementSys
{
	public abstract class Person
	{
		public string Name { get; private set; }
		public double Age { get; private set; }
		public string Gender { get; private set; }

		public Person(string name, DateTime DOB, string gender)
		{
			Name = name;
			TimeSpan timeSpan = DateTime.Today - DOB;
			Age = timeSpan.TotalDays;
			Gender = gender;
		}

		public virtual void DisplayInfo()
		{
			Console.WriteLine($"Name: {Name}, Age: {Age}, Gender: {Gender}");
		}
	}
}
