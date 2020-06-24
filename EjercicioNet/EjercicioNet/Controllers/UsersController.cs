using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EjercicioNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EjercicioNet.Controllers
{
    public class UsersController : Controller
    {

        // GET: Login
        public ActionResult Login()
        {

            return View();
        }


        // POST: 
        [HttpPost]
        public async Task<ActionResult> Login(UsersViewModel model)
        {
            if (ModelState.IsValid)
            {
                string Url = "https://localhost:44389/api/Users";
                string result;

                var content = new UsersViewModel { IdUser = 1, Nombre = model.Nombre, Apellido = "", Password = model.Password, Activo = 1 };

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Get, Url))
                {
                    var json = JsonConvert.SerializeObject(content);
                    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        request.Content = stringContent;

                        using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                        {
                            response.EnsureSuccessStatusCode();
                            result = await response.Content.ReadAsStringAsync();

                        }
                    }
                }


                if (result == "1")
                {
                    ViewBag.Result = result;
                    CookieOptions cookie = new CookieOptions();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Append("Logeo", "1", cookie);
                    return RedirectToAction("Index", "Products");             

                }
                else
                {
                    ViewBag.Result = result;
                    ModelState.AddModelError(string.Empty, "Logeo Inválido");
                }


            }

            return View(model);

        }
    }
}