using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EjercicioNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioNet.Controllers
{
    public class ProductsController : Controller
    {


        // GET: Producto
        public ActionResult Index()
        {
            var url = "https://localhost:44389/api/Products";

            string logeo = Request.Cookies["Logeo"];
            if (logeo != "1")
            {
                return RedirectToAction("Login", "Users");
            }


            var wc = new System.Net.WebClient();
            var res = wc.DownloadString(url);
            ProductsViewModel[] data = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductsViewModel[]>(res);
            return View(data);
        }


        public ActionResult CerrarSesion()
        {
            if (Request.Cookies["Logeo"] != null)
            {

                Response.Cookies.Delete("Logeo");

                return RedirectToAction("Login", "Users");
            }


            return View();
        }



    }
}