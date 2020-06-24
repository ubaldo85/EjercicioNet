using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext context;


        public ProductsController(AppDbContext context)
        {
            this.context = context;
        }

        // Se recuperan los productos de la tabla
        [HttpGet]
        public IEnumerable<Products> Get()
        {

            return context.Products.ToList();
        }
    }
}
