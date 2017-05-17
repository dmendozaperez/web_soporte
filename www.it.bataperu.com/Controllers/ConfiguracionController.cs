using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using www.it.bataperu.com.Domain;
using CapaEntidades;
using CapaNegocio;
namespace www.it.bataperu.com.Controllers
{
    public class ConfiguracionController : Controller
    {


        private TiendaBL tiendabl = new TiendaBL();
        // GET: Configuracion
        [Route("Config")]
        public ActionResult Index()
        {
            if (Session[Constantes.NameSessionUser] == null)
                return RedirectToAction("Login", "Account");


            List<Tienda> list = tiendabl.Listar();
            //Tiendas drop_tiendas = new Tiendas();
            ViewBag.tiendas = list;//  drop_tiendas._get_tiendas();
            return View();
        }
        [HttpPost]
        public ActionResult getconfigtda(string codtda)
        {
            //var config_tda = new Tiendas();
            //var config=config_tda._get_correlativoTDA(codtda);
            var config = tiendabl.Get(codtda);

            if (config!=null)
            { 
                string _codigo_interno = config.CODIGO_INTERNO;
                string _boleta = config.BOLETA;
                string _factura = config.FACTURA;
                string _nc_boleta = config.NCBOLETA;
                string _nc_factura = config.NCFACTURA;

                return Json(new { estado = "1", interno = _codigo_interno,
                                  boleta=_boleta,factura=_factura,
                                  ncboleta=_nc_boleta,ncfactura=_nc_factura  });
            }
            else
            {
                return Json(new
                {
                    estado = "-1",
                    desmsg="Error con el servidor"

                });
            }
        }
    }
}