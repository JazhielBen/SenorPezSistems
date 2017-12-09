using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SenorPezServicio.DataMember
{
    public class EMPRESA
    {
        [DataContract]
        public class Cargo
        {
            [DataMember]
            public Int32 iCodEmpresa { get; set; }
            [DataMember]
            public String vNombreEmpresa { get; set; }
            [DataMember]
            public String vLogoEmpresa { get; set; }
            [DataMember]
            public String vTelefonoEmpresa { get; set; }
            [DataMember]
            public String vDireccionEmpresa { get; set; }
            [DataMember]
            public String vRucEmpresa { get; set; }
            [DataMember]
            public String vDniRepresentante { get; set; }
            [DataMember]
            public String cEstado { get; set; }
            [DataMember]
            public Boolean bActivo { get; set; }
        }
    }
}