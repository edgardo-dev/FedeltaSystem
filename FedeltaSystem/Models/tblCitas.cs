using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblCitas
    {
        [Key]
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public string Paciente { get; set; }

    }
}