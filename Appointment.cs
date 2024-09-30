using System;
using System.Globalization;

namespace HospitalManagementSys
{
    public abstract class Appointment
    {
        //Attributes 
        public string PatientName { get; private set; }
        public string DoctorName { get; private set; }
        public DateTime? AppointmentDate { get; private set; }


        //Constructor
        public Appointment(string patientName, string doctorName)
        {
            PatientName = patientName;
            DoctorName = doctorName;
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
            Console.WriteLine($"Patient Name: {PatientName} | Doctor Name: {DoctorName} | Date: {AppointmentDate}");
        }
    }
}
