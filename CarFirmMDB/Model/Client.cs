using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFirmMDB.Model
{
    [BsonIgnoreExtraElements]
    public class Client
    {
        public int client_Code { get; set; }
        public string client_Name { get; set;  }
        public string client_Address { get; set; }
        public string client_Tel { get; set; }
        public string client_Mail { get; set; }
        public Account account { get; set; }
        public List<Reservation> reservations { get; set; }
        public List<Comment> comments { get; set; }
    }
}
