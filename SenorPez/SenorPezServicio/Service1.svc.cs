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
        public CARGO Login(CARGO _obj)
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
    }
}
