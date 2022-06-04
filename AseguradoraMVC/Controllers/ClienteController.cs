using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AseguradoraMVC.Models;
using AseguradoraMVC.Models.Viewmodels;

namespace AseguradoraMVC.Controllers
{
    public class ClienteController : Controller
    {

        public ActionResult Index()
        {
            List<AgregarClienteViewmodels> lst;
            using (AseguradoraEntities db= new AseguradoraEntities())
            {
                 lst = (from d in db.Cliente
                           select new AgregarClienteViewmodels
                           {
                               IdCliente = d.IdCliente,
                               Cedula = d.Cedula,
                               Nombre = d.Nombre,
                               Telefono = d.Telefono,
                               Edad = d.Edad,
                               Codigoseguro = d.Codigoseguro
                           }).ToList();
            }

            return View(lst);
        }

        public ActionResult Nuevo()
        {

            return View();
        }


        [HttpPost]

        public ActionResult Nuevo(AgregarClienteViewmodels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (AseguradoraEntities db = new AseguradoraEntities())
                    {
                        var cTabla = new Cliente();
                        cTabla.IdCliente = model.IdCliente;
                        cTabla.Cedula = model.Cedula;
                        cTabla.Nombre = model.Nombre;
                        cTabla.Edad = model.Edad;
                        cTabla.Telefono = model.Telefono;
                        cTabla.Codigoseguro = model.Codigoseguro;

                        db.Cliente.Add(cTabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Cliente");
                }

                return View(model);
            }
            catch (Exception)
            {
                throw new Exception("ERRORRRR");

            }


        }

        public ActionResult Editar(int Id)
        {
            AgregarClienteViewmodels model = new AgregarClienteViewmodels();
            using (AseguradoraEntities db = new AseguradoraEntities())
            {
                var oTabla = db.Cliente.Find(Id);
                model.Cedula = oTabla.Cedula;
                model.Nombre = oTabla.Nombre;
                model.Edad = oTabla.Edad;
                model.Telefono = oTabla.Telefono;
                model.Codigoseguro = oTabla.Codigoseguro;
                model.IdCliente = oTabla.IdCliente;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AgregarClienteViewmodels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (AseguradoraEntities db = new AseguradoraEntities())
                    {
                        var eTabla = db.Cliente.Find(model.IdCliente);
                        eTabla.Cedula = model.Cedula;
                        eTabla.Nombre = model.Nombre;
                        eTabla.Edad = model.Edad;
                        eTabla.Telefono = model.Telefono;
                        eTabla.Codigoseguro = model.Codigoseguro;

                        db.Entry(eTabla).State= System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Cliente");
                }

                return View(model);
            }
            catch (Exception)
            {
                throw new Exception("ERRORRRR");

            }


        }


        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            AgregarClienteViewmodels model = new AgregarClienteViewmodels();
            using (AseguradoraEntities db = new AseguradoraEntities())
            {
                var dTabla = db.Cliente.Find(Id);
                db.Cliente.Remove(dTabla);
                db.SaveChanges();
               
            }

            return Redirect("~/Cliente");
        }




    }
}