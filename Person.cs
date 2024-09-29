﻿using System;
using System.Security.Cryptography.X509Certificates;


namespace HospitalManagementSys
{
	public abstract class Person
	{
		public string Name { get; private set; }
		public int Age { get; private set; }
		public string Gender { get; private set; }

		public Person(string name, int age, string gender)
		{
			Name = name;
			Age = age;
			Gender = gender;
		}

		public virtual void DisplayInfo()
		{
			Console.WriteLine($"Name: {Name}, Age: {Age}, Gender: {Gender}");
		}
	}
}
