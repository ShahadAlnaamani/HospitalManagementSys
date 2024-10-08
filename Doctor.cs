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

        public void ScheduleFollowUp(Doctor doctor, DateTime day, DateTime date, TimeSpan time, Patient patient)
        {
            Console.WriteLine("<!>Scheduling follow up :)<!>");
            Appointment appointment = new Appointment(patient, this, day, time, null);
            appointment.ScheduleEvent(patient, doctor, date, time, true);
        }

        public void PatientCare()
        {
            Console.WriteLine("<!>Caring for patient :)<!>");
        }

        public void Discharge(Patient patient)
        {
            patient.Discharge();
        }

        public void ScheduleEvent(Patient patient, Doctor doctor, DateTime date, TimeSpan time)
        {
            Appointment appointment = new Appointment(patient, doctor, date, time, null);

        }

        public void CancelEvent(Appointment appointment)
        {
            appointment.CancelEvent(appointment);
            Console.WriteLine("Doctor cancelled appointment");
        }
    }
}
