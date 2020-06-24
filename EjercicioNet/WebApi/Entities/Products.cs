using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Products
    {
        [Key]
        public int IdProduct { get; set; }

        public string Nombre { get; set; }

        public string Costo { get; set; }

        public string CantidadInventario { get; set; }
    }
}
