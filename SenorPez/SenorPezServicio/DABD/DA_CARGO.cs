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
        public List<Cargo> Login(Cargo _Obj)
        {
            List<Cargo> LST = new List<Cargo>();
            Cargo ITEM;         
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
                        using (SqlDataReader DR = cm.ExecuteReader())
                        {
                            while (DR.Read())
                            {
                                ITEM = new Cargo();
                                if (!DR.IsDBNull(DR.GetOrdinal("iCodPerfil")))
                                    ITEM.iCodPerfil = DR.GetInt32(DR.GetOrdinal("iCodPerfil"));
                                if (!DR.IsDBNull(DR.GetOrdinal("iCodEmpleado")))
                                    ITEM.iCodEmpleado = DR.GetInt32(DR.GetOrdinal("iCodEmpleado"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vUsuario")))
                                    ITEM.vUsuario = DR.GetString(DR.GetOrdinal("vUsuario"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vPassword")))
                                    ITEM.vPassword = DR.GetString(DR.GetOrdinal("vPassword"));
                                LST.Add(ITEM);
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception excepcion)
                {
                    throw (excepcion);
                }
                return LST;
            }
        }
    }
}
