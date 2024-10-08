﻿using System;
using System.Runtime.CompilerServices;

namespace HospitalManagementSys
{
	public class Clinic : IDisplayInformation
	{
		//Attributes 
		public int ClinicID { get; private set; }

        public string ClinicName { get; private set; }
       // public double TotalHours { get; private set; }

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
			Console.WriteLine($"<!>Room {room.RoomNumber} (Room type {room.r}) is added to the {ClinicName} ");
		}

		public void AddAvailableAppointment(Patient patient, Doctor doctor, DateTime appointmentDay, TimeSpan period ) //double TotalTime
        {
			DateOnly date = DateOnly.FromDateTime(appointmentDay);
            Appointment appointment = new Appointment(patient, doctor, appointmentDay, period);
			appointment.ScheduleAppointment(date, period, false);
			//TotalHours = TotalTime;

			if (AvailableAppointments.ContainsKey(doctor))
			{
				AvailableAppointments[doctor] = new List<Appointment>() { appointment };
				Console.WriteLine($"<!>Doctor {doctor.Name} new clinic created {appointment.AppointmentDate}<!>");
			}

			else 
			{
                AvailableAppointments.Add(doctor, new List<Appointment>() {appointment});
				//DateTime date = appointment.AppointmentDate;
				//	new DateTime(appointment.AppointmentDate.Year, appointment.AppointmentDate.Month, appointment.AppointmentDate.Year)
                Console.WriteLine($"<!>{doctor.Name} is assigned to the {ClinicName} for {appointment.AppointmentDate}, {appointment.Time}<!>\n");
            }
			
        }


		public void BookAppointment(Patient patient, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime)
        {
			bool Found = false;
			DateOnly date = DateOnly.FromDateTime(appointmentDate);


            foreach (KeyValuePair<Doctor, List<Appointment>> line in AvailableAppointments)
			{ 
				if (line.Key == doctor)
				{
					
					foreach(Appointment appointment in line.Value) 
					{
                        if (appointment.AppointmentDate == date && appointment.AppointmentTime == appointmentTime)
						{ 
							appointment.ScheduleAppointment(date, appointmentTime, true);
							Found = true;
							TimeOnly time = TimeOnly.ParseExact("0:00 am", "h:mm tt");

							if (appointmentTime.ToString() == "01:00:00")
							{ time = (TimeOnly.ParseExact("9:00 am", "h:mm tt")); }

							else if (appointmentTime.ToString() == "02:00:00")
							{ time = (TimeOnly.ParseExact("10:00 am", "h:mm tt")); }

							else if (appointmentTime.ToString() == "03:00:00")
							{ time = (TimeOnly.ParseExact("11:00 am", "h:mm tt")); }

							if (time != TimeOnly.ParseExact("0:00 am", "h:mm tt"))
							{
								appointment.WorkDay.Remove(time);
								//AvailableAppointments.Remove(line.Key); //remove only the specific hour 
								Console.WriteLine($"<!>Appointment Scheduled for patient {patient.Name} with {doctor.Name} at {appointment.Time}<!>");
								break;
							}

							else { Console.WriteLine("<!>Improper time<!>"); }
						}
					}
				}
			}

			if (Found != true)
			{ Console.WriteLine("<!>Appointment was not found<!>"); }
        }

		public void IDisplayInfo()
		{
			foreach (KeyValuePair<Doctor, List<Appointment>> line in AvailableAppointments)
			{
			
                Console.WriteLine($"\n\nD O C T O R - {line.Key.Name}:");
                Console.WriteLine("APPOINTMENTS:");

				foreach (Appointment appointment in line.Value)
				{
					if (appointment.WorkDay != null)
					{
						Console.WriteLine($"Doctor: {appointment.CurrentDoctor.Name} | Date: {appointment.AppointmentDate} | Time: {appointment.Time}");
					}
				}
			}
		}
    }
}
