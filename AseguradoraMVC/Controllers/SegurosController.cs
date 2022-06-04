using AseguradoraMVC.Models;
using AseguradoraMVC.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AseguradoraMVC.Controllers
{
    public class SegurosController : Controller
    {
        // GET: Seguros
        public ActionResult Index()
        {
            List<SeguroViewmodels> lst;
            using (AseguradoraEntities db = new AseguradoraEntities())
            {
                lst = (from d in db.Seguros
                       select new SeguroViewmodels
                       {
                           Codigo = d.Codigo,
                           Nombre = d.Nombre,
                           Suma = d.Suma,
                           Prima = d.Prima
                       }).ToList();
            }
            return View(lst);
        }

        //public ActionResult Index()
        //{
        //    List<SeguroViewmodels> lst = null;
        //    using (Models.AseguradoraEntities db = new Models.AseguradoraEntities())
        //    {

        //       lst = (from d in db.Seguros
        //               select new SeguroViewmodels
        //               {
        //                   Codigo = d.Codigo,
        //                   Nombre = d.Nombre,
        //                   Suma = d.Suma,
        //                   Prima = d.Prima
        //               }).ToList();
        //    }
        //    List<SelectListItem> items = lst.ConvertAll(d =>
        //    {
        //        return new SelectListItem()
        //        {
        //            Text = d.Nombre.ToString(),
        //            Value = d.Codigo.ToString(),
        //            Selected = false
        //        };
        //    });
        //    ViewBag.item = items;
        //    return View();
        //}

        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Nuevo(AgregarSeguroViewmodels model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (AseguradoraEntities db= new AseguradoraEntities ())
                    {
                        var oTabla = new Seguros();
                        oTabla.Codigo = model.Codigo;
                        oTabla.Nombre = model.Nombre;
                        oTabla.Prima = model.Prima;
                        oTabla.Suma = model.Suma;

                        db.Seguros.Add(oTabla);
                        db.SaveChanges();

                    }
                    return Redirect("~/Seguros");
                }

                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }

        public ActionResult Editar(int Id)
        {
            AgregarSeguroViewmodels model = new AgregarSeguroViewmodels();
            using (AseguradoraEntities db = new AseguradoraEntities())
            {
                var oTabla = db.Seguros.Find(Id);             
                model.Nombre = oTabla.Nombre;
                model.Prima = oTabla.Prima;
                model.Suma = oTabla.Suma;
                model.Codigo = oTabla.Codigo;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(AgregarSeguroViewmodels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (AseguradoraEntities db = new AseguradoraEntities())
                    {
                        var eTabla = db.Seguros.Find(model.Codigo);
                        eTabla.Nombre = model.Nombre;
                        eTabla.Prima = model.Prima;
                        eTabla.Suma = model.Suma;


                        db.Entry(eTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Seguros");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }


        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            AgregarSeguroViewmodels model = new AgregarSeguroViewmodels();
            using (AseguradoraEntities db = new AseguradoraEntities())
            {
                var dTabla = db.Seguros.Find(Id);
                db.Seguros.Remove(dTabla);
                db.SaveChanges();

            }

            return Redirect("~/Seguros");
        }



    }
}