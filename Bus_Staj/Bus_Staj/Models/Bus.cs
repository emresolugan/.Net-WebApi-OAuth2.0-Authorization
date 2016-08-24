using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus_Staj.Models
{
    public class Bus
    {
        public int ID { get; set; }
        public string Plaka { get; set; }
        public string Seat_Count { get; set; }
        public int Model_ID { get; set; }
    }
}