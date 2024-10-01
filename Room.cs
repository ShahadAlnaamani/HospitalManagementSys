﻿using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace HospitalManagementSys
{
    public class Room
    {
        //Attributes 
        public int RoomNumber { get; private set; }
        public bool IsOccupied { get; private set; }
        public enum RoomType {IR, OPR}
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
                Console.WriteLine($"<!>Room {RoomNumber} booked<!>");
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
                Console.WriteLine($"<!>Room {RoomNumber} now available<!>");
            }
        }

        public virtual void DisplayRoomInfo()
        {
            Console.WriteLine($"Room Number: {RoomNumber} | Room Type: {r} | Is occupied: {IsOccupied}");
        }

    }
}
