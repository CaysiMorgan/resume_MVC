//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace resume_MVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Education
    {
        public int IDEdu { get; set; }
        public int IdPers { get; set; }
        public int InstituteUniveristy { get; set; }
        public string TitleOfDiploma { get; set; }
        public string Degree { get; set; }
        public System.DateTime FromYear { get; set; }
        public System.DateTime ToYear { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
