using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblConsultas
    {
        [Key]
        public int IdConsulta { get; set; }
        //Relaciones
        public int IdPaciente { get; set; }
        public virtual tblPacientes Paciente { get; set; }
        public DateTime FechaConsulta { get; set; }
        public double Peso { get; set; }
        public double Temperatura { get; set; }
        public string Diagnostico { get; set; }
        public string Observaciones { get; set; }


    }
}