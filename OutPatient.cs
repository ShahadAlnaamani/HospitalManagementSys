using System;
using System.Xml.Linq;

namespace HospitalManagementSys
{
    public class OutPatient : Patient
    {
        //Attributes 
        public Clinic ClinicAssigned { get; private set; }

        //Constructor
        public OutPatient(int pateintID, string name, int age, Gender gender, Clinic clinic) : base(pateintID, name, age, gender)
        {
            ClinicAssigned = clinic;
        }

        //Methods
        public override void DisplayInfo()
        {
            Console.WriteLine();
            base.DisplayInfo();
            //Add Appointment details 
            Console.Write($" | Illness:  | Doctor:  | Room \n");
        }
    }
}

