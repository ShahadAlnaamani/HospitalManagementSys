using System;
using System.Security.Cryptography.X509Certificates;


namespace HospitalManagementSys
{
	public abstract class Person
	{
		public string Name { get; private set; }
		public int Age { get; private set; }
		//public string Gender { get; private set; }
		public enum Gender { Male, Female}
        public Gender g { get; private set; }

        public Person(string name, int age, string gender)
		{
			Name = name;
			Age = age;
			
			if (gender.Trim().ToLower() != "male")
			{
				g = Gender.Female;
			}
			else
            {
                g = Gender.Male;
            }
        }

		public virtual void DisplayInfo()
		{
			Console.WriteLine($"Name: {Name}, Age: {Age}, Gender: {g}");
		}
	}
}
