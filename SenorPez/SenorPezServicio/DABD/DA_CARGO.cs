using SenorPezServicio.DataMember;
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
        public CARGO Login(CARGO _Obj)
        {
            CARGO ITEM = new CARGO();    
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
                               
                                if (!DR.IsDBNull(DR.GetOrdinal("iCodPerfil")))ITEM.iCodPerfil = DR.GetInt32(DR.GetOrdinal("iCodPerfil"));
                                if (!DR.IsDBNull(DR.GetOrdinal("iCodEmpleado")))ITEM.iCodEmpleado = DR.GetInt32(DR.GetOrdinal("iCodEmpleado"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vUsuario")))ITEM.vUsuario = DR.GetString(DR.GetOrdinal("vUsuario"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vPassword"))) ITEM.vPassword = DR.GetString(DR.GetOrdinal("vPassword"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vNombreEmpresa"))) ITEM.vNombreEmpresa = DR.GetString(DR.GetOrdinal("vNombreEmpresa"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vRucEmpresa"))) ITEM.vRucEmpresa = DR.GetString(DR.GetOrdinal("vRucEmpresa"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vDireccionEmpresa"))) ITEM.vDireccionEmpresa = DR.GetString(DR.GetOrdinal("vDireccionEmpresa"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vLogoEmpresa"))) ITEM.vLogoEmpresa = DR.GetString(DR.GetOrdinal("vLogoEmpresa"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vTelefonoEmpresa"))) ITEM.vTelefonoEmpresa = DR.GetString(DR.GetOrdinal("vTelefonoEmpresa"));
                                if (!DR.IsDBNull(DR.GetOrdinal("iCodEmpresa"))) ITEM.iCodEmpresa = DR.GetInt32(DR.GetOrdinal("iCodEmpresa"));
                               
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception excepcion)
                {
                    throw (excepcion);
                }
                return ITEM;
            }
        }

        public BE_INFO GET_INFO(BE_INFO _Obj)
        {
            BE_INFO ITEM = new BE_INFO();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnBDAl4k0"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("[dbo].[SP_LOGIN]", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@vUsuario", _Obj.iCodEmpresa);
                        using (SqlDataReader DR = cm.ExecuteReader())
                        {
                            while (DR.Read())
                            {
                                if (!DR.IsDBNull(DR.GetOrdinal("iTotal"))) ITEM.iTotal = DR.GetDecimal(DR.GetOrdinal("iTotal"));   
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception excepcion)
                {
                    throw (excepcion);
                }
                return ITEM;
            }
        }
    }
}
