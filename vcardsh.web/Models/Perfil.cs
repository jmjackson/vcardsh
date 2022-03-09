using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vcardsh.web.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Web { get; set; }
        public string Direccion { get; set; }
        public string QRTelefono { get; set; }
        public string QRSitioWeb { get; set; }
        public string UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public ApplicationUser Usuario { get; set; }
    }
}