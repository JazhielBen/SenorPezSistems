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
        CARGO Login(CARGO _Obj);
        [OperationContract]
        BE_INFO GET_INFO(BE_INFO _Obj);
    }
}
