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
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        BE_CARGO Login(BE_CARGO _Obj);
        [OperationContract]
        BE_INFO GET_INFO(BE_INFO _Obj);
        [OperationContract]
        List<BE_TBL_MENU> LISTAR_MENU(BE_TBL_MENU _Obj);
        [OperationContract]
        List<BE_CARGO> LISTAR_PERSONAL(BE_CARGO _Obj);
    }
}
