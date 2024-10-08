using System;
using System.Reflection;
using System.Xml.Linq;

namespace HospitalManagementSys
{
    public class Doctor : Person, IDisplayInformation, IInPatientCare, IOutPatientCare, ISchedulable
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
        public void AssignToClinic(Clinic clinic, DateTime day, TimeSpan period, Doctor doctor)
        {
            //double totalTime = period.TotalHours;
            day = day.Date;
            AssignedClinics.Add(clinic);
            clinic.AddAvailableAppointment(null, doctor, day, period); //totalTime

        }
        public void AssignRoom(Patient patient)
        {
            PatientsList.Add(patient);
            Console.WriteLine($"<!>Patient {patient} added<!>");
        }

        public void Discharge(Patient patient)
        {
            PatientsList.Remove(patient);
            Console.WriteLine($"<!>Patient {patient} removed<!>");
        }

        public override void IDisplayInfo()
        {
            Console.WriteLine();
            base.IDisplayInfo();
            Console.WriteLine($"Doctor ID: {DoctorID}, Specialization: {s}\n");
        }

        public void DisplayAssignedClinics()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine($"Doctor ID: {DoctorID}, Name: {Name}\n");

            foreach (Clinic c in AssignedClinics)
            {
                Console.WriteLine($"Clinic ID: {c.ClinicID}, Clinic Name: {c.ClinicName}, Clinic Specialization: {c.s}\n");
            }
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - -");

        }

        public void ScheduleFollowUp()
        {
            Console.WriteLine("<!>Scheduling follow up :)<!>");
            /*
            Console.WriteLine("Would you like to book an appointment?");
            Console.WriteLine("1. yes / 2. no");
            Console.Write("Enter: ");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            { 
                Appointment appointment = new Appointment();
                Console.WriteLine("Input date");
                Console.Write("Enter: ");
                DateOnly date = new DateOnly(DateOnly.ParseExact(Console.ReadLine());

                Console.WriteLine("Input time");
                Console.Write("Enter: ");
                TimeSpan time = TimeSpan.ParseExact(Console.ReadLine());
                appointment.ScheduleEvent(date, time, true); }

            else
            { Console.WriteLine("Leaving..."); }*/
        }

        public void PatientCare()
        {
            Console.WriteLine("<!>Caring for patient :)<!>");
        }
    }
}
