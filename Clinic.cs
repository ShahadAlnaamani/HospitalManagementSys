using System;

namespace HospitalManagementSys
{
	public class Clinic
	{
		//Attributes 
		public int ClinicID { get; private set; }

        public string ClinicName { get; private set; }

        public enum Specialization {Cardiology, Neurology, Dermatology }
        public Specialization s { get; private set; }

        public List<Room> RoomsList { get; private set; }

		public Dictionary <Doctor,List<Appointment>> AvailableAppointments { get; private set; }
    


		//Constructor 
		public Clinic(int clinicID, string clinicName, Specialization specialization, Appointment a)
		{
			RoomsList = new List<Room>();
            ClinicID = clinicID;
			ClinicName = clinicName;
			s = specialization;
			AvailableAppointments = new Dictionary<Doctor, List<Appointment>>();	

        }


        //Methods
        public void AddRoom(Room room) 
		{
			RoomsList.Add(room);
		}

		public void AddAvailableAppointment(Doctor doctor, DateTime appointmentDay, TimeSpan period, double TotalTime)
		{
			Appointment appointment;
			appointment.ScheduleAppointment(appointmentDay, period);
        }


		public void BookAppointment(Patient patient, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime)
		{
			//remove available appointment 

			//add update appointment 
		}
    }
}
