using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblExpedientes
    {
        [Key]
        public int IdExpediente { get; set; }
        public int NumExpediente { get; set; }
        public DateTime FechaCreacion { get; set; }

        //Relacion Pacientes
        public int IdPaciente { get; set; }
        public virtual tblPacientes Paciente { get; set; }


    }
}