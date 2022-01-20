using CarFirmMDB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarFirmMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ClientController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public JsonResult get()
        {
            MongoClient client = new MongoClient(_config.GetConnectionString("CarfirmConString"));
            var Clients_List = client.GetDatabase("CarFirm").GetCollection<Client>("Client").AsQueryable();
            return new JsonResult(Clients_List);
        }
        [HttpPost]
        public JsonResult Post(Client newClient)
        {
            MongoClient client = new MongoClient(_config.GetConnectionString("CarfirmConString"));
            client.GetDatabase("CarFirm").GetCollection<Client>("Client").InsertOne(newClient);
            return new JsonResult("Added Succesfully");
        }
        [HttpPut]
        public JsonResult Put(Client editClient)
        {
            MongoClient client = new MongoClient(_config.GetConnectionString("CarfirmConString"));
            var filter = Builders<Client>.Filter.Eq("client_Code", editClient.client_Code);
            var update = Builders<Client>.Update.Set("client_Name", editClient.client_Name)
                .Set("client_Address", editClient.client_Address)
                .Set("client_Mail", editClient.client_Mail)
                .Set("client_Tel", editClient.client_Tel);
            client.GetDatabase("CarFirm").GetCollection<Client>("Client").UpdateOne(filter, update);
            return new JsonResult("Updated Succesfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient client = new MongoClient(_config.GetConnectionString("CarfirmConString"));
            var filter = Builders<Client>.Filter.Eq("client_Code", id);
            client.GetDatabase("CarFirm").GetCollection<Client>("Client").DeleteOne(filter);
            return new JsonResult("Deleted Succesfully");
        }
    }
}
