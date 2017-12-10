using SenorPezPrincipal.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenorPezPrincipal.Controllers
{
    public class MantenimientoController : Controller
    {
        //
        // GET: /Mantenimiento/

        public ActionResult Index()
        {
            return View();
        }

        #region LISTAR_PERSONAL
        public ActionResult LISTAR_PERSONAL(BE_CARGO obj)
        {
            List<BE_CARGO> oLista = new List<BE_CARGO>();
            Service1Client Servicio = new Service1Client();

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            string filter = Request.Form.GetValues("search[value]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            SenorPezPrincipal.ServiceReference1.BE_CARGO Obj = (SenorPezPrincipal.ServiceReference1.BE_CARGO)Session["Cargo_Empleado"];
            obj.iCodEmpresa = Obj.iCodEmpresa;
            try
            {
                oLista = Servicio.LISTAR_PERSONAL(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Servicio.Close();
            recordsTotal = oLista.Count();
            var data = oLista.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet); ;
        }
        #endregion


    }
}
