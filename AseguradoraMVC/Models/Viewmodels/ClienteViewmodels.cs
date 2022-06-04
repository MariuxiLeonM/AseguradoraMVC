using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AseguradoraMVC.Models.Viewmodels
{
    public class ClienteViewmodels
    {


        [Display(Name = "ID")]
        public int IdCliente { get; set; }
        [Display(Name = "Cédula")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "El campo Cédula debe ser un número.")]
        [Required(ErrorMessage = "Cédula es requerido")]
        [StringLength(10, ErrorMessage = "Cédula del cliente no puede exceder de 10 caracteres")]
        public string Cedula { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre del nivel es obligatorio")]
        [RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage = "Números y caracteres especiales no permitidos")]
        public string Nombre { get; set; }
        [Display(Name = "Teléfono")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "El campo teléfono debe ser un número.")]
        [Required(ErrorMessage = "Teléfono es requerido")]
        //[MaxLength(10, ErrorMessage = "Teléfono del cliente no puede exceder de 10 caracteres")]
        public int Telefono { get; set; }
        [Display(Name = "Edad")]
        [Required(ErrorMessage = "Edad es obligatoria")]
        [Range(1, 120, ErrorMessage = "La Edad ingresada es incorrecta"), DataType(DataType.Currency)]
        public int Edad { get; set; }
        [Display(Name = "Seguro")]
        public int Codigoseguro { get; set; }
    }
}