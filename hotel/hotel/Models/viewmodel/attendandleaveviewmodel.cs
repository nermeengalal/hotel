using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hotel.Models.viewmodel
{
    public class attendandleaveviewmodel
    {
        public string Empname { get; set; }
        public int id { get; set; }
       
        public Nullable<System.DateTime> com_in { get; set; }
        public Nullable<System.DateTime> leave_in { get; set; }
        public string discount { get; set; }
    }
}