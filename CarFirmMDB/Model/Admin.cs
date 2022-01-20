using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFirmMDB.Model
{
    [BsonIgnoreExtraElements]
    public class Admin
    {
        public int admin_Code { get; set; }
        public string admin_Name { get; set; }
        public string admin_Address { get; set; }
        public string admin_Mail { get; set; }
        public string admin_Type { get; set; }
        public Account account { get; set; }
        public List<Reservation> reservation { get; set; }
    }
}
