//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aluno
    {
        public int AlunoID { get; set; }
        public string AlunoNome { get; set; }
        public int DepartamentoID { get; set; }
        public int AssuntoID { get; set; }
    
        public virtual Assunto Assunto { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
