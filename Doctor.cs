using System;
using System.Reflection;
using System.Xml.Linq;

namespace HospitalManagementSys
{
    public class Doctor : Person
    {
        //Attributes
        public int DoctorID { get; private set; }
        public string Specialization { get; private set; }
        public List<Patient> PatientsList { get; private set; } 

        //Constructor
        public Doctor(int doctorID, string name, int age, Gender gender, string specialization) : base(name, age, gender)
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
            Console.WriteLine($"Doctor ID: {DoctorID}, Specialization: {Specialization}\n");
        }
    }
}
