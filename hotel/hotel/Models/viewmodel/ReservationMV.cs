using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotel.Models.viewmodel
{
    [MetadataType(typeof(ReservationMVS))]
    public class ReservationMV
    {
        public int id { get; set; }
        public string cus_name { get; set; }
        public string room_num { get; set; }
        public Nullable<System.DateTime> checkin_date { get; set; }
        public Nullable<System.DateTime> checkout_date { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> days_num { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<System.DateTime> date_of_reserve { get; set; }
    }
    public class ReservationMVS
    {
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> checkin_date { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> checkout_date { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_of_reserve { get; set; }
    }
}