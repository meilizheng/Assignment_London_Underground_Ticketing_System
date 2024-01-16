using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_London_Underground_Ticketing_System
{
    public class Rider
    {
        //Created the fields
        public int UniqueNumber { get; set; }
        public Station StationOn { get; set; }
        public Station StationOff { get; set; }

        //Created the Constructor with parameters
        public Rider(int uniqueNumber, Station on, Station off)
        {
            UniqueNumber = uniqueNumber;
            StationOn = on;
            StationOff = off;
        }

        //Created the method to check if the StationOff is active
        public bool IsActive
        {
            get => (StationOff == 0) ? true : false;
        }

    } // class

} // namespace
