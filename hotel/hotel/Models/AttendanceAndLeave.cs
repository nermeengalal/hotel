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

    [MetadataType(typeof(AttendanceAndLeaveVM))]
    public partial class AttendanceAndLeave
    {
        public int id { get; set; }
        public Nullable<int> emp_id { get; set; }
        public Nullable<System.DateTime> com_in { get; set; }
        public Nullable<System.DateTime> leave_in { get; set; }
        public string discount { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
    public class AttendanceAndLeaveVM
    {
        [DataType(DataType.Date)]
       
        public Nullable<System.DateTime> com_in { get; set; }
        [DataType(DataType.Date)]
       
        public Nullable<System.DateTime> leave_in { get; set; }
    }


}