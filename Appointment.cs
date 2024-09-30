using System;
using System.Globalization;

namespace HospitalManagementSys
{
    public class Appointment
    {
        //Attributes 
        public Patient CurrentPatient { get; private set; }
        public Doctor CurrentDoctor { get; private set; }
        public DateTime? AppointmentDate { get; private set; }


        //Constructor
        public Appointment(Patient patient, Doctor doctor, DateTime date)
        {
            CurrentPatient = patient;
            CurrentDoctor = doctor;
            ScheduleAppointment(date);
        }

        //Methods 
        public void ScheduleAppointment(DateTime date)
        {
            AppointmentDate = date;
        }

        public void CancelAppointment()
        {
            AppointmentDate = null;
        }

        public void GetAppointmentDetails()
        {
            Console.WriteLine($"Patient Name: {CurrentPatient.Name} | Doctor Name: {CurrentDoctor.Name} | Date: {AppointmentDate}");
        }
    }
}
