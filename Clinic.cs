using System;

namespace HospitalManagementSys
{
	public class Clinic : Room
	{
		//Attributes 
		public int ClinicID { get; private set; }

        public string ClinicName { get; private set; }

        public enum Specialization {Cardiology, Neurology, Dermatology }
        public Specialization s { get; private set; }

        public List<Room> RoomsList { get; private set; }

		public Dictionary <Doctor,List<Appointment>> AvailableAppointments { get; private set; }
    


		//Constructor 
		public Clinic(int clinicID, string clinicName, Specialization specialization, Appointment a, int roomNumber, RoomType roomType) : base(roomNumber, roomType)
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

		public void AddAvailableAppointment(Patient patient, Doctor doctor, DateTime appointmentDay, TimeSpan period, double TotalTime)
		{
			Appointment appointment = new Appointment(patient, doctor, appointmentDay, period);
			appointment.ScheduleAppointment(appointmentDay, period, false);
        }


		public void BookAppointment(Patient patient, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime)
        {
			
			foreach (KeyValuePair<Doctor, List<Appointment>> line in AvailableAppointments)
			{ 
				if (line.Key == doctor)
				{
					foreach(Appointment appointment in line.Value) 
					{
						if (appointment.AppointmentDate == appointmentDate && appointment.AppointmentTime == appointmentTime)
						{ 
							appointment.ScheduleAppointment(appointmentDate, appointmentTime, true);
						}
					}
				}
			}
        }

		public void DisplayAvailableAppointments()
		{ 

		}
    }
}
