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

    /*------------------------------------------------------------------*/
    [Display(Name = "Paciente")]
    public int IdPaciente { get; set; }

        /*------------------------------------------------------------------*/
    [Required(ErrorMessage ="Este campo es obligatorio!")]
    [Display(Name ="Nombre Paciente")]
        public string NombrePaciente { get; set; }

        //public string Foto { get; set; }
    
      /*------------------------------------------------------------------*/
    [Required(ErrorMessage ="Este campo es obligatorio!")]
    //[RegularExpression("^[0-9]+$", ErrorMessage ="Solo se permiten números")]
        public int Edad { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    public string Sexo { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    public string Raza { get; set; }

    /*------------------------------------------------------------------*/

    public string Especie { get; set; }

        //Relaciones Responsable
        [Display(Name ="Responsable")]
        [Required(ErrorMessage ="Este campo es obligatorio!")]
        public int IdResponsable { get; set; }
        public virtual tblResponsables Responsable{ get; set; }


    }
}