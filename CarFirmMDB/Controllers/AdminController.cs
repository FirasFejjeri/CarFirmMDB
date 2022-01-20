using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarFirmMDB.Model;

namespace CarFirmMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AdminController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public JsonResult get()
        {
            MongoClient client = new MongoClient(_config.GetConnectionString("CarfirmConString"));
            var Admins_List = client.GetDatabase("CarFirm").GetCollection<Admin>("Admin").AsQueryable();
            return new JsonResult(Admins_List);
        }
        [HttpPost]
        public JsonResult Post(Admin newAdmin)
        {
            MongoClient client = new MongoClient(_config.GetConnectionString("CarfirmConString"));
            client.GetDatabase("CarFirm").GetCollection<Admin>("Admin").InsertOne(newAdmin);
            return new JsonResult("Added Succesfully");
        }
        [HttpPut]
        public JsonResult Put(Admin editAdmin)
        {
            MongoClient client = new MongoClient(_config.GetConnectionString("CarfirmConString"));
            var filter = Builders<Admin>.Filter.Eq("admin_Code", editAdmin.admin_Code);
            var update = Builders<Admin>.Update.Set("admin_Name", editAdmin.admin_Name)
                .Set("admin_Address", editAdmin.admin_Address)
                .Set("admin_Mail", editAdmin.admin_Mail)
                .Set("admin_Type", editAdmin.admin_Type);
            client.GetDatabase("CarFirm").GetCollection<Admin>("Admin").UpdateOne(filter,update);
            return new JsonResult("Updated Succesfully");
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            MongoClient client = new MongoClient(_config.GetConnectionString("CarfirmConString"));
            var filter = Builders<Admin>.Filter.Eq("admin_Code", id);
            client.GetDatabase("CarFirm").GetCollection<Admin>("Admin").DeleteOne(filter);
            return new JsonResult("Deleted Succesfully");
        }

    }
}
