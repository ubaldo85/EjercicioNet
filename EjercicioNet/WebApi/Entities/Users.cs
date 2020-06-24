using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Users
    {
        [Key]
        public int IdUser { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Password { get; set; }

        public int Activo { get; set; }
    }
}
