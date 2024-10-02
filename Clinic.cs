using System;
using System.Runtime.CompilerServices;

namespace HospitalManagementSys
{
	public class Clinic
	{
		//Attributes 
		public int ClinicID { get; private set; }

        public string ClinicName { get; private set; }
        public double TotalHours { get; private set; }

        public enum Specializations {Cardiology, Neurology, Dermatology }
        public Specializations s { get; private set; }

        public List<Room> RoomsList { get; private set; }

		public Dictionary <Doctor,List <Appointment>> AvailableAppointments { get; private set; }
    


		//Constructor 
		public Clinic(int clinicID, string clinicName, Specializations specialization) 
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
			TotalHours = TotalTime;

			if (AvailableAppointments.ContainsKey(doctor))
			{
				AvailableAppointments[doctor] = new List<Appointment>() { appointment };
				Console.WriteLine($"<!>Doctor {doctor.Name} new clinic created {appointment.AppointmentDate}<!>");
			}

			else 
			{
                AvailableAppointments.Add(doctor, new List<Appointment>() {appointment});
                Console.WriteLine($"<!>Doctor {doctor.Name} new clinic created {appointment.AppointmentDate}<!>");
            }
			
        }


		public void BookAppointment(Patient patient, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime)
        {
			bool Found = false;
			foreach (KeyValuePair<Doctor, List<Appointment>> line in AvailableAppointments)
			{ 
				if (line.Key == doctor)
				{
					foreach(Appointment appointment in line.Value) 
					{
						if (appointment.AppointmentDate == appointmentDate && appointment.AppointmentTime == appointmentTime)
						{ 
							appointment.ScheduleAppointment(appointmentDate, appointmentTime, true);
							Found = true;
							AvailableAppointments.Remove(line.Key);
							Console.WriteLine("<!>Appointment Scheduled<!>");
							break;
						}
					}
				}
			}

			if (Found != true)
			{ Console.WriteLine("<!>Appointment was not found<!>"); }
        }

		public void DisplayAvailableAppointments()
		{
			foreach (KeyValuePair<Doctor, List<Appointment>> line in AvailableAppointments)
			{
				
                Console.WriteLine($"\n\nD O C T O R - {line.Key}:");
                Console.WriteLine("APPOINTMENTS:");

				foreach (Appointment appointment in line.Value)
				{
					Console.WriteLine($"Date: {appointment.AppointmentDate} | Time: {appointment.AppointmentTime}");
				}
			}
		}
    }
}
