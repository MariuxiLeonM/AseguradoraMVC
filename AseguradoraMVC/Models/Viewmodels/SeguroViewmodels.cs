using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AseguradoraMVC.Models.Viewmodels
{
    public class SeguroViewmodels
    {

        [Display(Name = "CODIGO")]
        public int Codigo { get; set; }
        [Display(Name = "NOMBRE")]
        public string Nombre { get; set; }
        [Display(Name = "SUMA")]
        public string Suma { get; set; }
        [Display(Name = "PRIMA")]
        public string Prima { get; set; }

    }
}