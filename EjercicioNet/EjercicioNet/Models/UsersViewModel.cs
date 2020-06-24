using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioNet.Models
{
    public class UsersViewModel
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        [Required(ErrorMessage = "El password es requerido.")]
        public string Password { get; set; }

        public int Activo { get; set; }


    }
}
