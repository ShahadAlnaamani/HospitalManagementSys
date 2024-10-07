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
            Console.WriteLine($"<!>Patient {name} (Out-Patient) is created and assigned to the {ClinicAssigned.ClinicName}<!>");
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
        public void BookAppointment(Doctor doctor, Clinic clinic, DateTime date, TimeSpan time)//OutPatient patient, Doctor doctor, Clinic clinic, DateTime date, TimeSpan time
        {//cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(10)
            clinic.BookAppointment(this, doctor, date, time);
        }
    }
}

