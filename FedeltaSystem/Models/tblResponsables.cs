using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FedeltaSystem.Models
{
    public class tblResponsables
    {
        [Key]
        public int IdResponsable { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    [Display(Name = "Nombre Responsable")]
    public string NombreResponsable { get; set; }

    /*------------------------------------------------------------------*/
    [Required(ErrorMessage = "Este campo es obligatorio!")]
    [Display(Name = "Apellido Responsable")]
    public string ApellidoResponsable { get; set; }


    /*------------------------------------------------------------------*/
    [DataType(DataType.MultilineText)]
    public string Direccion { get; set; }


    /*------------------------------------------------------------------*/
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage ="Este campo es obligatorio!")]
    public string Telefono { get; set; }

    }
}