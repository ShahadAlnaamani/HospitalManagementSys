using System;
using System.Xml.Linq;

namespace HospitalManagementSys
{
    public class OutPatient : Patient
    {
        //Attributes 
        public Clinic ClinicAssigned { get; private set; }
        public List<Appointment> Appointments { get; private set; }

        //Constructor
        public OutPatient(int pateintID, string name, int age, Gender gender, Clinic clinic) : base(pateintID, name, age, gender)
        {
            ClinicAssigned = clinic;
        }

        //Methods
        public override void DisplayInfo()
        {
            Console.WriteLine();
            base.DisplayInfo();
            foreach (Appointment appointment in Appointments)
            {
                if (appointment.AppointmentDate > DateTime.Now)
                {
                    Console.WriteLine($"Date: {appointment.AppointmentDate} | Time: {appointment.AppointmentTime} | Doctor: {appointment.CurrentDoctor}");
                }
            }

        }
    }
}

