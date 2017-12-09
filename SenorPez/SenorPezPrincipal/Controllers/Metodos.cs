using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SenorPezPrincipal.Controllers
{
    public class Metodos
    {
        #region GetStringWebConfig
        public static String GetStringConfig(String _text) { return ConfigurationManager.AppSettings[_text].ToString(); }
        #endregion

        #region GetSession
        internal static String GetSessionString(object p) { return p.ToString(); }
        #endregion

    }
}