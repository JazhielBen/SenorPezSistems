using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SenorPezServicio.DataMember
{
    [DataContract]
    public class BE_INFO
    {
        [DataMember]
        public Decimal iTotal { get; set; }
        [DataMember]
        public int iCodEmpresa { get; set; }
        
    }
}