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
        public List<TimeOnly> WorkDay { get; private set; }
        public TimeOnly WorkEnd { get; private set; }
        public bool IsBooked { get; private set; }

        public string Time { get; private set; }


        //Constructor
        public Appointment(Patient patient, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            Patient = patient;
            CurrentDoctor = doctor;
            WorkDay = new List<TimeOnly>();
            WorkDay.Add(TimeOnly.ParseExact("9:00 am", "h:mm tt"));
            WorkDay.Add(TimeOnly.ParseExact("10:00 am", "h:mm tt"));
            WorkDay.Add(TimeOnly.ParseExact("11:00 am", "h:mm tt"));
            // ScheduleAppointment(appointmentDate, appointmentTime);
        }

        //Methods 
        public void ScheduleAppointment(DateTime appointmentDate, TimeSpan appointmentTime, bool book)
        { 
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;

            switch (appointmentTime.ToString()) //Assigning appointment 
            {
                case "1":
                    Time = " 9:00 AM ";
                    break;

                case "2":
                    Time = " 10:00 AM ";
                    break;

                case "3":
                    Time = " 11:00 PM ";
                    break;

                default:
                    Console.WriteLine("<!>Invalid appointment time<!>");
                    break;
            }

            
            IsBooked = false;//ensures that defualt is false
            if (book) 
            { 
                IsBooked = true;
                Console.WriteLine("<!> Appointment booked<!>");
            }
            
            Console.WriteLine($"<!>Appointment scheduled for {appointmentDate} at {appointmentTime}<!>");
        }

        public void CancelAppointment()
        {
            IsBooked = false;
            Console.WriteLine($"<!>Appointment for patient {this.Patient.Name} cancelled<!>");
        }

        public void GetAppointmentDetails()
        {
            Console.WriteLine($"Patient Name: {Patient.Name} | Date: {AppointmentDate} | Time: {Time}");
        }
    }
}
