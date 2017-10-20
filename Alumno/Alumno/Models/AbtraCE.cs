using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alumno.Models
{
    public class AbtraCE
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Sexo { get; set; }


    }

    [MetadataType(typeof(AbtraCE))]
    public partial class Abtra
    { 

        public String NomeCompleto { get { return Nome + "  " + Sobrenome; } }
    }

}