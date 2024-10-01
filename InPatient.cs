using System;

namespace HospitalManagementSys
{
	public class InPatient : Patient
	{
        //Attributes 
        public Room Room { get; private set; }
        public Doctor AssignedDoctor { get; private set; }
        public DateTime AdmissionDate { get; private set; }
        public Room ?AssignedRoom { get; set; }
        public string Ailement {  get; private set; }


        //Constructor
        public InPatient(int pateintID, string name, int age, Gender gender, Room room, Doctor doctor, DateTime date, string ailment) : base(pateintID, name, age, gender)
        {
            Room = room;
            AssignedDoctor = doctor;
            AdmissionDate = date;
            Ailement = ailment;
        }

        //Method
        public void AssignRoom(Room room)
        {
            room.OccupyRoom();
            AssignedRoom = room;
        }

        public void Discharge()
        {
            AssignedRoom.VacateRoom();
            AssignedRoom = null;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine();
            base.DisplayInfo();
            Console.Write($" | Illness: {Ailement} | Doctor: {AssignedDoctor} | Room {AssignedDoctor}\n");
        }
    }
}
