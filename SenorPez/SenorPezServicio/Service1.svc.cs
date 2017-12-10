using Qaliwarma.Maestros.BE;
using SenorPezServicio.DataMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SenorPezServicio
{
    public class Service1 : IService1
    {
        public BE_CARGO Login(BE_CARGO _obj)
        {
            DA_CARGO DA = new DA_CARGO();
            try
            {
                return DA.Login(_obj);
            }
            catch (Exception excepcion)
            {
                throw (excepcion);
            }
        }
        public BE_INFO GET_INFO(BE_INFO _obj)
        {
            DA_CARGO DA = new DA_CARGO();
            try
            {
                return DA.GET_INFO(_obj);
            }
            catch (Exception excepcion)
            {
                throw (excepcion);
            }
        }
        public List<BE_TBL_MENU> LISTAR_MENU(BE_TBL_MENU _obj)
        {
            DA_CARGO DA = new DA_CARGO();
            try
            {
                return DA.LISTAR_MENU(_obj);
            }
            catch (Exception excepcion)
            {
                throw (excepcion);
            }
        }
        public List<BE_CARGO> LISTAR_PERSONAL(BE_CARGO _obj)
        {
            DA_CARGO DA = new DA_CARGO();
            try
            {
                return DA.LISTAR_PERSONAL(_obj);
            }
            catch (Exception excepcion)
            {
                throw (excepcion);
            }
        }
    }
}
