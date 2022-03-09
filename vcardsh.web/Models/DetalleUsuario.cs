using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vcardsh.web.Models
{
    public class DetalleUsuario
    {
        public int Id { get; set; }
        public string Acerca { get; set; }
        public string Descripcion { get; set; }
        public string OtraDescripcion { get; set; }
        public string Fotografia1 { get; set; }
        public string Fotografia2 { get; set; }
        public string Fotografia3 { get; set; }
        public string UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public ApplicationUser Usuario { get; set; }
    }
}