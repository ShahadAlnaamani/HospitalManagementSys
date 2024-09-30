using System;
using System.Diagnostics;

namespace HospitalManagementSys
{
    public abstract class Room
    {
        //Attributes 
        public int RoomNumber { get; private set; }
        public bool IsOccupied { get; private set; }
        public enum RoomType {General, ICU, OperationTheater }
        public RoomType r { get; private set; }



        //Constructor
        public Room(int roomNumber, bool isOccupied, string roomType)
        {
            RoomNumber = roomNumber;
            IsOccupied = isOccupied;

            if (roomType.Trim().ToLower() == "general")
            {
                r = RoomType.General;
            }

            else if (roomType.Trim().ToLower() == "icu")
            {
                r = RoomType.ICU;
            }

            else if (roomType.Trim().ToLower() == "operationtheater")
            {
                r = RoomType.OperationTheater;
            }
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
