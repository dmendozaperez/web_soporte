using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using www.it.bataperu.com.Domain;
using System.Data;
using CapaNegocio;
using CapaEntidades;
//using Page;
using PagedList;

namespace www.it.bataperu.com.Controllers
{
    public class CuponesController : Controller
    {
        // GET: Cupones

        private CuponesBL cuponesBL = new CuponesBL();
        public List<Cupones> Buscar(int pageIndex,string buscar)
        {            
            int pageCount = 0;         
            int pagesize = 10;
            List<Cupones> cupones = cuponesBL.Listar(ref pageIndex, ref pagesize, ref pageCount, buscar);

            ViewBag.PageCount = pageCount;
            ViewBag.PageIndex = pageIndex;
            ViewBag.FilterBuscar = buscar;
            
            return cupones;
        }
        public ActionResult ListCupones(int id = 1, string buscar = "")
        {
            if (Session[Constantes.NameSessionUser] == null)
                return RedirectToAction("Login", "Account");

            return PartialView(Buscar(id, buscar));
        }     
        public ActionResult Index(int id=1,string buscar = "")
        {
            if (Session[Constantes.NameSessionUser] == null)
                return RedirectToAction("Login", "Account");

            ViewBag.FilterBuscar = buscar;            
            return View(Buscar(id, buscar));
            
        }

    }
}