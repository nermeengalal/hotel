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

    [MetadataType(typeof(SupplierVM))]
    public partial class Supplier
    {
        public int id { get; set; }
        public string sup_name { get; set; }
        public string sup_phone { get; set; }
        public string type_of_service { get; set; }
        public Nullable<System.DateTime> date_of_recive { get; set; }
        public string name_of_mandob { get; set; }
    }

    public class SupplierVM
    {
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date_of_recive { get; set; }
       
    }
}
