//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuoteSystemDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quote
    {
        public int Id { get; set; }
        public string QuoteNumber { get; set; }
        public string RiskState { get; set; }
        public double Premium { get; set; }
        public string AgentId { get; set; }
    
        public virtual PolicyTerm PolicyTerm { get; set; }
        public virtual Prospect Prospect { get; set; }
    }
}