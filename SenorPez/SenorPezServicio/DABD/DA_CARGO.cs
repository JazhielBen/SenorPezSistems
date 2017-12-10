using Qaliwarma.Maestros.BE;
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
        public BE_CARGO Login(BE_CARGO _Obj)
        {
            BE_CARGO ITEM = new BE_CARGO();    
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
        public List<BE_TBL_MENU> LISTAR_MENU(BE_TBL_MENU _Obj)
        {
            BE_TBL_MENU ITEM ;
            List<BE_TBL_MENU> List = new List<BE_TBL_MENU>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnBDAl4k0"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("[dbo].[SP_CARGA_MENU]", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@iCodEmpresa", _Obj.iCodEmpresa);
                        cm.Parameters.AddWithValue("@iCodPerfil", _Obj.iCodPerfil);
                        cm.Parameters.AddWithValue("@iCodEmpleado", _Obj.iCodEmpleado);
                        using (SqlDataReader DR = cm.ExecuteReader())
                        {
                            while (DR.Read())
                            {
                                ITEM = new BE_TBL_MENU();
                                if (!DR.IsDBNull(DR.GetOrdinal("vIconMaterialize"))) ITEM.vIconMaterialize = DR.GetString(DR.GetOrdinal("vIconMaterialize"));                               
                                if (!DR.IsDBNull(DR.GetOrdinal("vNombreMenu"))) ITEM.vNombreMenu = DR.GetString(DR.GetOrdinal("vNombreMenu"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vNombreAction"))) ITEM.vNombreAction = DR.GetString(DR.GetOrdinal("vNombreAction"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vNombreControlador"))) ITEM.vNombreControlador = DR.GetString(DR.GetOrdinal("vNombreControlador"));
                                List.Add(ITEM);
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception excepcion)
                {
                    throw (excepcion);
                }
                return List;
            }
        }
        public List<BE_CARGO> LISTAR_PERSONAL(BE_CARGO _Obj)
        {
            BE_CARGO ITEM;
            List<BE_CARGO> List = new List<BE_CARGO>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnBDAl4k0"].ConnectionString))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("[dbo].[SP_LISTAR_PERSONAL]", cn))
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@iCodEmpresa", _Obj.iCodEmpresa);
                        using (SqlDataReader DR = cm.ExecuteReader())
                        {
                            while (DR.Read())
                            {
                                ITEM = new BE_CARGO();
                                if (!DR.IsDBNull(DR.GetOrdinal("iCodEmpleado"))) ITEM.iCodEmpleado = DR.GetInt32(DR.GetOrdinal("iCodEmpleado"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vUsuario"))) ITEM.vUsuario = DR.GetString(DR.GetOrdinal("vUsuario"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vNombre"))) ITEM.vNombre = DR.GetString(DR.GetOrdinal("vNombre"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vApellido"))) ITEM.vApellido = DR.GetString(DR.GetOrdinal("vApellido"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vTelefono"))) ITEM.vTelefono = DR.GetString(DR.GetOrdinal("vTelefono"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vMail"))) ITEM.vMail = DR.GetString(DR.GetOrdinal("vMail"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vDocPersona"))) ITEM.vDocPersona = DR.GetString(DR.GetOrdinal("vDocPersona"));
                                if (!DR.IsDBNull(DR.GetOrdinal("vNombrePerfil"))) ITEM.vNombrePerfil = DR.GetString(DR.GetOrdinal("vNombrePerfil"));
                                List.Add(ITEM);
                            }
                        }
                    }
                    cn.Close();
                }
                catch (Exception excepcion)
                {
                    throw (excepcion);
                }
                return List;
            }
        }
    }
}
