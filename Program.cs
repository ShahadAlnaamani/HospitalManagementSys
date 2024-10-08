using static HospitalManagementSys.Person;
using static HospitalManagementSys.Room;

namespace HospitalManagementSys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //Creating user interface 

            Console.WriteLine("- - - - -C I T Y   H O S P I T A L- - - - - ");
            Console.WriteLine("1. Admin \n2. Doctor");
            Console.Write("\nEnter: ");
            int Option = 0;

            try 
            {
                Option = int.Parse(Console.ReadLine());
            } catch (Exception e) { Console.WriteLine(e.Message); }
            
            switch(Option)
            {
                case 1:
                    //Admin options 
                    Console.Clear();
                    Console.WriteLine("- - - - -C I T Y   H O S P I T A L- - - - - ");
                    Console.WriteLine("1. Add new doctor \n2. Assign patient to room \n3.Create patient \n4.Assign patient to room \n5.Book appointment");
                    Console.Write("\nEnter: ");
                    break;


                case 2:
                    //Doctor options
                    Console.Clear();
                    Console.WriteLine("- - - - -C I T Y   H O S P I T A L- - - - - ");
                    Console.WriteLine("1. Add new appointment \n2. Doctor \n3.Assign patient to room");
                    Console.Write("\nEnter: ");
                    break;


                default:
                    Console.WriteLine("<!>Improper input<!>");
                    break;
            }
            
            */

            Hospital hospital = new Hospital();

            Console.WriteLine("\n\nT E S T   C A S E S:\n");
            Console.WriteLine("1. DOCTOR ASSIGNMENT");
            // Create doctors
            Doctor doctor1 = new Doctor(1, "Dr. John Smith", 45, Gender.Male, Doctor.Specialization.Cardiology);
            Doctor doctor2 = new Doctor(2, "Dr. Alice Brown", 38, Gender.Female, Doctor.Specialization.Neurology);
            
            // Create clinics
            Clinic cardiologyClinic = new Clinic(1, "Cardiology Clinic", Clinic.Specializations.Cardiology);
            Clinic neurologyClinic = new Clinic(2, "Neurology Clinic", Clinic.Specializations.Neurology);
           
            // Assign doctors to clinics and generate appointment slots (9 AM - 12 PM)
            doctor1.AssignToClinic(cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(1), doctor1); // Expected: Appointments generated for 9 AM, 10 AM, 11 AM
            doctor2.AssignToClinic(neurologyClinic, new DateTime(2024, 10, 6), TimeSpan.FromHours(3), doctor2);  // Expected: Appointments generated for 9 AM, 10 AM, 11 AM



            Console.WriteLine("\n2. ROOM ASSIGNMENT");
            // Create rooms for clinics
            Room room1 = new Room(101, RoomType.IPR);  // Room for in-patients
            Room room2 = new Room(102, RoomType.OPR);  // Room for out-patients
            cardiologyClinic.AddRoom(room1); // Expected: Room 101 added to Cardiology Clinic
            neurologyClinic.AddRoom(room2);  // Expected: Room 102 added to Neurology Clinic


            Console.WriteLine("\n\n3. PATIENT CREATION AND ASSIGNMENT");
            // Create patients
            InPatient inpatient1 = new InPatient("Jane Doe", 30, Gender.Female, 101, "Cardiac Arrest", doctor1, DateTime.Now);
            
            OutPatient outpatient1 = new OutPatient("Mark Doe", 28, Gender.Male, 102, "Migraine", neurologyClinic);

            // Assign room to in-patient
            inpatient1.AssignRoom(room1); // Expected: Room 101 becomes occupied

            Console.WriteLine("\n\n4. BOOKING APPOINTMENT");
            // Book an appointment for out-patient in Cardiology Clinic
           // outpatient1.BookAppointment(outpatient1, doctor1, cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(10)); // Expected: Appointment at 10 AM booked

            outpatient1.BookAppointment(doctor1, cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(1)); // Expected: Appointment at 10 AM booked

            Console.WriteLine("\n\n5. DOCTOR ASSIGNED CLINICS");
            // View doctor's assigned clinics
            doctor1.DisplayAssignedClinics(); // Expected: Cardiology Clinic is displayed

            Console.WriteLine("\n\n6. DISPLAY AVAILABLE APPOINTMENTS");
            // View available appointments in Cardiology Clinic
            cardiologyClinic.IDisplayInfo();
            // Expected: Show available slots for Dr. John Smith at 9 AM, 11 AM (10 AM is booked)

            Console.WriteLine("\n\n7. DISCHARGE PATIENT");
            // Discharge in-patient
            inpatient1.Discharge(); // Expected: Room 101 becomes available, patient discharged
                                    // Book another appointment for the same out-patient in Cardiology Clinic
            outpatient1.BookAppointment(doctor2, cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(2)); // Expected: Appointment at 11 AM booked
                                                                                                              // Try booking a time outside available slots
            outpatient1.BookAppointment(doctor1, cardiologyClinic, new DateTime(2024, 10, 5), TimeSpan.FromHours(3));
            // Expected: No available appointments for this time

            Console.WriteLine("\n\n8. APPOINTMENT CANCELLATION");
            // Cancel an appointment
            cardiologyClinic.ScheduleEvent(outpatient1, doctor2, new DateTime(2024, 10, 5), TimeSpan.FromHours(1));
            // Expected: Appointment cancellation message for 10 AM


            // View available appointments after booking and cancellation
            cardiologyClinic.IDisplayInfo();
            // Expected: 10 AM slot available again, 9 AM and 11 AM booked
        }
    }
}
