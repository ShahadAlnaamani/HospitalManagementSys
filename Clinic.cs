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
		public Clinic(int clinicID, string clinicName, Specialization specialization)
		{
			RoomsList = new List<Room>();
            ClinicID = clinicID;
			ClinicName = clinicName;
			s = specialization;
		}


		//Methods
	}
}
