using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AseguradoraMVC.Models.Viewmodels
{
    public class AgregarSeguroViewmodels
    {

        [Display(Name = "Código")]
        public int Codigo { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[A-Za-zÁÉÍÓÚáéíóúñÑ0-9 ]*$", ErrorMessage = " No se permiten caracteres especiales")]
        public string Nombre { get; set; }
        [Display(Name = "Suma")]
        [Required(ErrorMessage = "La Suma  es obligatorio")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Cantidad no es válida")]
        public string Suma { get; set; }
        [Display(Name = "Prima")]
        [Required(ErrorMessage = "Prima es obligatorio")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Cantidad no es válida")]
        public string Prima { get; set; }

    }
}