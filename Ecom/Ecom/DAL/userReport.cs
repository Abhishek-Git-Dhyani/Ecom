//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecom.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class userReport
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public Nullable<bool> CBC_Report { get; set; }
        public Nullable<bool> disorder_Report { get; set; }
        public Nullable<bool> Prescription_Report { get; set; }
    }
}
