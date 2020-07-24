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

    [MetadataType(typeof(BillingVM))]
    public partial class Billing
    {
        public int id { get; set; }
        public Nullable<int> cus_id { get; set; }
        public Nullable<System.DateTime> date_of_bill { get; set; }
        public string credit_no { get; set; }
        public Nullable<decimal> total { get; set; }
    
        public virtual Customer Customer { get; set; }
    }

    public class BillingVM
    {
        [DataType(DataType.Date)]

        public Nullable<System.DateTime> date_of_bill { get; set; }


    }
}