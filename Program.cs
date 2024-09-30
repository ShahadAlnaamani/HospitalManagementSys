using static HospitalManagementSys.Person;
using static HospitalManagementSys.Room;

namespace HospitalManagementSys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test Case 1: Create doctors and patients
            Console.WriteLine("===== Test Case 1: Create Doctors and Patients =====");
            Doctor doctor1 = new Doctor(1, "Dr. Smith", 45, Gender.Male, "Cardiology");
            Doctor doctor2 = new Doctor(2, "Dr. Brown", 38, Gender.Female, "Neurology");
            Patient patient1 = new Patient(101, "John Doe", 30, Gender.Male, "Heart Disease", doctor1);
            Patient patient2 = new Patient(102, "Jane Roe", 28, Gender.Female, "Migraine", doctor2);


            // Display information
            patient1.DisplayInfo();
            patient2.DisplayInfo();
            doctor1.DisplayInfo();
            doctor2.DisplayInfo();
           

        }
    }
}
