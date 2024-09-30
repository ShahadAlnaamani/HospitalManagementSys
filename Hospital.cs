using System;

namespace HospitalManagementSys
{ 
    public abstract class Hospital
    {
        //Attributes 
        public List<Patient> PatientsList { get; private set; }
        public List<Doctor> DoctorsList { get; private set; }
        public List<Room> RoomsList { get; private set; }

        //Constructor
        public Hospital()
        {
            PatientsList = new List<Patient>();
            DoctorsList = new List<Doctor>();
            RoomsList = new List<Room>();
        }

        //Methods 
        public void AddDoctor(Doctor doctor)
        {
            DoctorsList.Add(doctor);
        }

        public void AddPatient(Patient patient)
        {
            PatientsList.Add(patient);
        }

        public void AssignRoomToPatient(Patient patient, Room room)
        {
            if (!RoomsList.Contains(room))
            {
                RoomsList.Add(room);
            }

            room.OccupyRoom();
            patient.AssignedRoom = room;
        }

        public void GetDoctorPatients(Doctor doctor)
        {
            Console.WriteLine($"Doctor ID: {doctor.DoctorID} | Doctor Name: {doctor.Name}");

            foreach (Patient patient in doctor.PatientsList) 
            {
                Console.WriteLine($"Patient Name: {patient.Name}");
            }
            Console.WriteLine("\n");
        }
    }
}
