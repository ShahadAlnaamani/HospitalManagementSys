using System;
using System.Diagnostics;

namespace HospitalManagementSys
{
    public class Room
    {
        //Attributes 
        public int RoomNumber { get; private set; }
        public bool IsOccupied { get; private set; }
        public enum RoomType {General, ICU, OperationTheater }
        public RoomType r { get; private set; }



        //Constructor
        public Room(int roomNumber, RoomType roomType)
        {
            RoomNumber = roomNumber;
            r = roomType;
        }


        //Methods 

        public void OccupyRoom()
        {
            if (IsOccupied) 
            {
                Console.WriteLine("<!>This room is already booked :( <!>");
            }

            else
            {
                IsOccupied = true; 
            }
        }

        public void VacateRoom()
        {
            if (!IsOccupied)
            {
                Console.WriteLine("<!>This room is not occupied :( <!>");
            }

            else
            {
                IsOccupied = false;
            }
        }
    
    }
}
