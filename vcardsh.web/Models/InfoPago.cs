using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace vcardsh.web.Models
{
    public class InfoPago
    {
        public int Id { get; set; }
        public DateTime? FechaPago { get; set; }
        public string EmailCobro { get; set; }
        public string UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public ApplicationUser Usuario { get; set; }
    }
}