//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AseguradoraMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public int Edad { get; set; }
        public int Codigoseguro { get; set; }
    
        public virtual Seguros Seguros { get; set; }
    }
}

