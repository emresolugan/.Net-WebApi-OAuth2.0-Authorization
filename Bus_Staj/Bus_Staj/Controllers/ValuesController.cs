using Bus_Staj.App_Start;
using Bus_Staj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http; 


namespace Bus_Staj.Controllers
{
    [Authorize]
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController{
    
        DataContext db = new DataContext();

       
        ////[HttpGet]
        ////public IHttpActionResult ExternalLogin()
        ////{
        ////return new ChallengeResult("&amp;quot;Google&amp;quot;,&amp;quot;/api/home&amp;quot;", this.Request);
        ////}

        // GET api/values 
        [HttpGet]
        public IEnumerable<Bus> Get()
        {
            return db.Buses.AsEnumerable<Bus>();
        }
        
      
        // GET api/values/5
        [HttpGet]
       public Bus Get(int id)
        {
            return db.Buses.Where(f => f.ID == id).FirstOrDefault<Bus>();  
        }

        // POST api/values
        [HttpPost]
        public void Post(Bus bus)
        {
            db.Buses.Add(bus);
            db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, Bus bus)
        {
            Bus item = db.Buses.First(f => f.ID == id);
            item.Plaka = bus.Plaka;
            item.Seat_Count = bus.Seat_Count;
            item.Model_ID = bus.Model_ID;
            db.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Bus item = db.Buses.First(f => f.ID == id);
            db.Buses.Remove(item);
            db.SaveChanges();
        }
    }
}
