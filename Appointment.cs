using System;
using System.Globalization;

namespace HospitalManagementSys
{
    public class Appointment
    {
        //Attributes 
        public Patient Patient { get; private set; }
        public Doctor CurrentDoctor { get; private set; }
        public DateTime? AppointmentDate { get; private set; }
        public TimeSpan? AppointmentTime { get; private set; }
        public bool IsBooked { get; private set; }


        //Constructor
        public Appointment(Patient patient, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            Patient = patient;
            CurrentDoctor = doctor;
            ScheduleAppointment(appointmentDate, appointmentTime);
        }

        //Methods 
        public void ScheduleAppointment(DateTime appointmentDate, TimeSpan appointmentTime)
        {
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            Console.WriteLine($"<!>Appointment scheduled for {appointmentDate} at {appointmentTime}<!>");
        }

        public void CancelAppointment()
        {
            AppointmentDate = null;
            AppointmentTime = null;
            Console.WriteLine($"<!>Appointment for patient {this.Patient.Name} cancelled<!>");
        }

        public void GetAppointmentDetails()
        {
            Console.WriteLine($"Patient Name: {Patient.Name} | Date: {AppointmentDate} | Time: {AppointmentTime}");
        }
    }
}
