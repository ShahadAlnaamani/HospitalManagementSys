using System;
using System.Reflection;
using System.Xml.Linq;

namespace HospitalManagementSys
{
    public abstract class Doctor : Person
    {
        //Attributes
        public int DoctorID { get; private set; }
        public string Specialization { get; private set; }
        public List<Patient> PatientsList { get; private set; } 

        //Constructor
        public Doctor(string name, int age, string gender, int doctorID, string specialization) : base(name, age, gender)
        {
            DoctorID = doctorID;
            Specialization = specialization;    
            PatientsList = new List<Patient>();
        }

        //Methods 
        public void AddPatient(Patient patient)
        { 
            PatientsList.Add(patient);
        }

        public void RemovePatient(Patient patient)
        {
            PatientsList.Remove(patient);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine();
            base.DisplayInfo();
            Console.WriteLine($"PatientID: {DoctorID}, Ailement {Specialization}\n");
        }
    }
}
