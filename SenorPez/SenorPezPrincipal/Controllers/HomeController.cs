using SenorPezPrincipal.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace SenorPezPrincipal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Cargo_Empleado"] == null)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.MenuAccesoConsulta = "class = active";
                return View();
            }
        }

        [HttpPost]
        public ActionResult LoadInfo(BE_INFO _Obj)
        {
            Service1Client client = new Service1Client();
            try
            {
                _Obj = client.GET_INFO(_Obj);

            }
            catch (Exception)
            {

            }
            return Json(_Obj, JsonRequestBehavior.AllowGet);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
