using SenorPezPrincipal.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenorPezPrincipal.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        Service1Client client = new Service1Client();
        public ActionResult Index()
        {
            return View();
        }

        #region Login
        [HttpPost]
        public ActionResult LoginProcedure(Cargo obj)
        {
            string data = "", msg = "";
            int resultazado = 0;
            try
            {
                resultazado = client.Login(obj);
                if (resultazado > 0)
                {
                    data = "OK";
                    msg = "Bienvenido";
                }else{
                    data = "ER";
                    msg = "OCURRIO UN ERROR";
                }
            }
            catch (Exception ex)
            {
                data = "ER";
                msg = ex.Message;
            }
            return Json(new { data = data, msg = msg });
        }
        #endregion
    }
}
