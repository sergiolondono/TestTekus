//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TekusTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PaisesPorServicio
    {
        public int Id { get; set; }
        public Nullable<int> IdPais { get; set; }
        public Nullable<int> IdServicio { get; set; }
    
        public virtual Paises Paises { get; set; }
        public virtual Servicios Servicios { get; set; }
    }
}
