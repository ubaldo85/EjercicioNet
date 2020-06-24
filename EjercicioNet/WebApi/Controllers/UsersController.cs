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
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;
        public UsersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public string Get([FromBody] Users oUsers)
        {
            string bandera = "0";
            var result = context.Users.FirstOrDefault(u => u.Nombre == oUsers.Nombre && u.Password == oUsers.Password);

            bandera = result != null ? "1" : "0";

            return bandera;
        }
    }
}
