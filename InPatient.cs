using System;

namespace HospitalManagementSys
{
	public class InPatient : Patient
	{
        //Attributes 
        public Room Room { get; private set; }
        public Doctor AssignedDoctor { get; private set; }
        public DateTime AdmissionDate { get; private set; }
        public Room? AssignedRoom { get; set; }
        public string Ailment {  get; private set; }


        //Constructor
        public InPatient(string name, int age, Gender gender, int pateintID, string ailment, Doctor doctor, DateTime date) : base(pateintID, name, age, gender)
        {
            Room = null;
            AssignedDoctor = doctor;
            AdmissionDate = date;
            Ailment = ailment;
            Console.WriteLine($"<!>Patient {Name} (In-Patient) is created<!> ");
        }

        //Method
        public void AssignRoom(Room room)
        {
            Room = room;
            room.OccupyRoom();
            AssignedRoom = room;
            Console.WriteLine($"<!>Patient {Name} is assigned room {room.RoomNumber}<!>");
        }

        public void Discharge()
        {
            AssignedRoom.VacateRoom();
            Console.WriteLine($"<!>Patient {Name} vacated room {AssignedRoom.RoomNumber}<!>");
            AssignedRoom = null;
        }

        public override void IDisplayInfo()
        {
            Console.WriteLine();
            base.IDisplayInfo();
            Console.Write($" | Illness: {Ailment} | Doctor: {AssignedDoctor.Name} | Room {AssignedRoom.RoomNumber}\n");
        }
    }
}
