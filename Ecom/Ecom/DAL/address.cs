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
    
    public partial class address
    {
        public Nullable<int> id { get; set; }
        public int address1 { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string addressline3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int pincode { get; set; }
        public string landmark { get; set; }
    
        public virtual user user { get; set; }
    }
}
