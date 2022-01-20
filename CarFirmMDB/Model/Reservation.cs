using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFirmMDB.Model
{
    public class Reservation
    {
        public int reservation_code { get; set; }
        public DateTime reservation_date { get; set; }
        public string reservation_status { get; set; }
        public string reservation_Destination { get; set; }
        public DateTime reservation_Time { get; set; }
        public string comment { get; set; }
        public int passenger_Nbr { get; set; }  
    }
}
