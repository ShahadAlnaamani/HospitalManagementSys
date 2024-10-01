using System;
using System.Reflection;
using System.Xml.Linq;

namespace HospitalManagementSys
{
    public class Doctor : Person
    {
        //Attributes
        public int DoctorID { get; private set; }

        public enum Specialization { Cardiology, Neurology, Dermatology }
        public Specialization s { get; private set; }
        public List<Patient> PatientsList { get; private set; }
        public List<Clinic> AssignedClinics { get; private set; }

        //Constructor
        public Doctor(int doctorID, string name, int age, Gender gender, Specialization specialization) : base(name, age, gender)
        {
            DoctorID = doctorID;
            s = specialization;    
            PatientsList = new List<Patient>();
            AssignedClinics = new List<Clinic>();
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
            Console.WriteLine($"Doctor ID: {DoctorID}, Specialization: {s}\n");
        }

        public void DisplayAssignedClinics()
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine($"Doctor ID: {DoctorID}, Name: {Name}\n");
            
            foreach (Clinic c in AssignedClinics)
            {
                Console.WriteLine($"Clinic ID: {c.ClinicID}, Clinic Name: {c.ClinicName}, Clinic Specialization: {c.Specialization}\n");
            }
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - -");

        }
    }
}
