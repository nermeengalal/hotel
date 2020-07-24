//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ReservationVMSD))]
    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            this.Services = new HashSet<Service>();
        }
    
        public int id { get; set; }
        public Nullable<int> cus_id { get; set; }
        public string room_num { get; set; }
        public Nullable<System.DateTime> checkin_date { get; set; }
        public Nullable<System.DateTime> checkout_date { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> days_num { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<System.DateTime> date_of_reserve { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; }
    }

    public class ReservationVMSD
    {
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_of_reserve { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> checkin_date { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> checkout_date { get; set; }
    }
}
