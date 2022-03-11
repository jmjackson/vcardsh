using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vcardsh.web.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
    }


}