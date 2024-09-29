using System;
using System.Globalization;

namespace HospitalManagementSys
{
    public abstract class Patient : Person
    {
        //Attributes 
        public string PatientID { get; private set; }
        public string Ailement {  get; private set; }
        public string AssignedDoctor { get; private set; }



        //Sending over required data to parent class 
        public Patient(string pateintID, string name, int age, string gender, string ailment, string assignedDoctor) : base(name, DOB, gender)
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

        public void AssignRoom()
        {
            //Use Room class 
        }

        public void Discharge()
        {
            //Use Room class 
        }



    }
}
