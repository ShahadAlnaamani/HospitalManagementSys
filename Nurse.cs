using System;

namespace HospitalManagementSys
{
	public class Nurse : Person, IDisplayInformation, IPatientCare
	{
		//Attributes
		public int NurseID { get; private set;}

        public Clinic AssignedClinic { get; private set; }

        public enum Specialization {General, Pediatrics, Surgery }
		public Specialization specialization { get; private set; }

		public List<Patient> AssignedPatients { get; private set; }
        public List<Appointment> AssistingAppointment { get; private set; }


        //Constructor
        public Nurse(string name, int age, Gender gender, int nurseId, Clinic clinic, Specialization spec, Patient patient ) : base (name, age, gender)
		{
			NurseID = nurseId;
			AssignedClinic = clinic;
			specialization = spec;
			AssignedPatients = new List<Patient>();
            AssistingAppointment = new List<Appointment>();
            AssignedPatients.Add( patient );
		}


		//Methods 
		public void AssistDoctor(Doctor doctor, Patient patient)
		{
			Console.WriteLine($"Nurse helping {doctor.Name} with patient {patient.Name} :)");
		}

		public void CheckVitals(Patient patient)
		{
            Console.WriteLine($"Nurse checking {patient.Name}'s vitals :)");
        }

		public void AdministerMedication (Patient patient, string medication)
		{
			Console.WriteLine($"Nurse administrating {medication} to patient {patient.Name}");
		}

		public void DisplayInfo()
		{
			Console.WriteLine($"Nurse ID: {NurseID} | Name: {Name} | Specialization: {specialization} | Assigned Clinic: {AssignedClinic.ClinicName}");
		}

		public void PatientCare()
		{
			Console.WriteLine("Nurse caring for patient...");
		}

		public void AssignClinic(Clinic clinic)
		{
			clinic.Nurses.Add(this);
		}

		public void Assisting(Appointment appointment)
		{
			AssistingAppointment.Add(appointment);
		}
	}

}
