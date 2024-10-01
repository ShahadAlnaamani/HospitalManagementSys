using System;
using System.Globalization;

namespace HospitalManagementSys
{
    public class Patient : Person
    {
        //Attributes 
        public int PatientID { get; private set; }
        //**********public string Ailement {  get; private set; }
        //**************public Doctor AssignedDoctor { get; private set; }
        //*************public Room ?AssignedRoom { get; set; }




        //Sending over required data to parent class 
        public Patient(int pateintID, string name, int age, Gender gender) : base(name, age, gender)
        {
            //*****(, string ailment, Doctor assignedDoctor)
            PatientID = pateintID;
            //*********Ailement = ailment;
           //***** AssignedDoctor = assignedDoctor;
        }


        //Methods
        public override void DisplayInfo()
        {
            Console.WriteLine();
            base.DisplayInfo();
            Console.Write($"\nPatientID: {PatientID}, Patient Name: {Name} ");
        }

        /************
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


        *************/
    }
}
