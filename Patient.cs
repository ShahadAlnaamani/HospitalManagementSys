using System;
using System.Globalization;

namespace HospitalManagementSys
{
    public abstract class Patient : Person
    {
        //Attributes 
        public int PatientID { get; private set; }
        public string Ailement {  get; private set; }
        public string AssignedDoctor { get; private set; }
        public Room ?AssignedRoom { get; set; }




        //Sending over required data to parent class 
        public Patient(int pateintID, string name, int age, string gender, string ailment, string assignedDoctor) : base(name, age, gender)
        {
            PatientID = pateintID;
            Ailement = ailment;
            AssignedDoctor = assignedDoctor;
        }


        //Methods
        public override void DisplayInfo()
        {
            Console.WriteLine();
            base.DisplayInfo();
            Console.WriteLine($"PatientID: {PatientID}, Ailement {Ailement}, Doctor{AssignedDoctor}\n");
        }

        public void AssignRoom(Room room)
        {
            room.OccupyRoom();
        }

        public void Discharge(Room room)
        {
            room.VacateRoom();
            AssignedRoom = null;
        }



    }
}
