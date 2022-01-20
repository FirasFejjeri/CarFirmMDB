using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFirmMDB.Model
{
    public class Car
    {
        public string car_Reg { get; set; }
        public string car_Brand { get; set; }
        public string car_Power { get; set; }
        public int car_Places { get; set; }         
        public CarType car_Type { get; set; }
        public Locality location { get; set; }
    }
}
