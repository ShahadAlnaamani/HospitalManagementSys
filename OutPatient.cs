using System;
using System.Xml.Linq;

namespace HospitalManagementSys
{
    public class OutPatient : Patient
    {
        //Attributes 
        public Clinic ClinicAssigned { get; private set; }
        public List<Appointment> Appointments { get; private set; }
        public string Ailment {  get; private set; }
        

        //Constructor
        public OutPatient(string name, int age, Gender gender, int pateintID, string ailment, Clinic clinic) : base(pateintID, name, age, gender)
        {
            ClinicAssigned = clinic;
            Ailment = ailment;
        }

        //Methods
        public override void DisplayInfo()
        {
            Console.WriteLine();
            base.DisplayInfo();
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.AppointmentDate > DateOnly.FromDateTime(DateTime.Today))
                {
                    Console.WriteLine($"Date: {appointment.AppointmentDate} | Time: {appointment.Time} | Doctor: {appointment.CurrentDoctor}");
                }
            }

        }
        public void BookAppointment(OutPatient patient, Doctor doctor, Clinic clinic, DateTime date, TimeSpan time)
        {//Patient patient, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime
            clinic.BookAppointment(patient, doctor, date, time);
        }
    }
}

