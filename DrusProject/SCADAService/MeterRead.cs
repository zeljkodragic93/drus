//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCADAService
{
    using System;
    using System.Collections.Generic;
    
    public partial class MeterRead
    {
        public int id { get; set; }
        public int Meter_ID { get; set; }
        public int Type { get; set; }
        public double Value { get; set; }
    
        public virtual Meter Meter { get; set; }
    }
}
