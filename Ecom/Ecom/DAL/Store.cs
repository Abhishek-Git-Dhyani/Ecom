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
    
    public partial class Store
    {
        public int id { get; set; }
        public int storeId { get; set; }
        public string CenterCode { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int pincode { get; set; }
        public string lattitude { get; set; }
        public string longitude { get; set; }
    }
}
