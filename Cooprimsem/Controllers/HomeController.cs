using Cooprimsem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cooprimsem.Controllers
{
    public class HomeController : Controller
    {

        PredioEntities cnx;
        public HomeController() {

            cnx = new PredioEntities();
        }
        public ActionResult Formulario()
        {

            List<Vacas> listado = cnx.Vacas.ToList();
            return View();
        }

        public ActionResult Listado()
        {
            cnx.Database.Connection.Open();

            List<Vacas> listado = cnx.Vacas.ToList();
            cnx.Database.Connection.Close();

            return View();
        }

        public ActionResult Guardar(Int32 Diio, string nombre, string sexo, string raza, int edad, string tipo)
        {

            return View("Listado");
        }

        public ActionResult Ficha(Int32 Diio, string nombre, string sexo, string raza, int edad, string tipo)
        {
            Vacas listado = new Vacas()
            {
                Diio = Diio,
                nombre = nombre,
                sexo = sexo,
                raza = raza,
                edad = edad,
                tipo = tipo
            };

            cnx.Vacas.Add(listado);
            cnx.SaveChanges();

            return View(listado);
        }

        public ActionResult Ver(Int32 Diio)
        {

            return View("Ficha", null);
        }

    }
}