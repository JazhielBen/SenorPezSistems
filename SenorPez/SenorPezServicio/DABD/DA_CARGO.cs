using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace SenorPezServicio
{
    public class DA_CARGO
    {
        public Int32 Login(Cargo _Obj)
        {
            Int32 Resultado = 0;
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnBDAl4k0"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("[dbo].[SP_LOGIN]", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@vUsuario", _Obj.vNombreCargo);
                        cm.Parameters.AddWithValue("@vPassword", _Obj.vPassword);
                        Resultado = Convert.ToInt32(cm.ExecuteScalar());
                    }
                    cn.Close();
                }
                catch (Exception excepcion)
                {
                    throw (excepcion);
                }
                return Resultado;
            }
        }
    }
}
