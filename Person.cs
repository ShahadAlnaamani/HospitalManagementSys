using System;
using System.Security.Cryptography.X509Certificates;


namespace HospitalManagementSys
{
	public abstract class Person : IDisplayInformation
	{
		public string Name { get; private set; }
		public int Age;
		
		public enum Gender { Male, Female, Other}
        public Gender gender { get; private set; }

        public Person(string name, int age ,Gender gender)
        {
			Name = name;
			Age = age;
			this.gender = gender;
        }

		public virtual void IDisplayInfo()
		{
			Console.WriteLine($"Name: {Name}, Age: {Age}, Gender: {gender}");
		}
	}
}
