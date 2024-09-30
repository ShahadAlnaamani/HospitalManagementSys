using System;
using System.Security.Cryptography.X509Certificates;


namespace HospitalManagementSys
{
	public abstract class Person
	{
		public string Name { get; private set; }
		public int Age { get; private set; }
		//public string Gender { get; private set; }
		public enum Gender { Male, Female, Other}
        public Gender g { get; set; }

        public Person(string name, int age ,Gender gender)
        {
			Name = name;
			Age = age;
			g = gender;
			/*
			if (gender.Trim().ToLower() == "female")
			{
				g = Gender.Female;
			}
			else if (gender.Trim().ToLower() == "male")
			{
				g = Gender.Male;
			}
			else 
			{ g = Gender.Other; }*/
        }

		public virtual void DisplayInfo()
		{
			Console.WriteLine($"Name: {Name}, Age: {Age}, Gender: {g}");
		}
	}
}
