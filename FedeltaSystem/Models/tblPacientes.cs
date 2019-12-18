using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblPacientes
    {

        [Key]
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        //public string Foto { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string Raza { get; set; }
        public string Especie { get; set; }

        //Relaciones Responsable
        public int IdResponsable { get; set; }
        public virtual tblResponsables Responsable{ get; set; }


    }
}