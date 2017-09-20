using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SenorPezServicio
{
  
    [DataContract]
    public class Cargo
    {
        [DataMember]
        public Int32  iCodCargo         { get; set; }        
        [DataMember]
        public String vNombreCargo      { get; set; }
        [DataMember]
        public String vPassword         { get; set; }
        [DataMember]
        public Int32  iAcceso           { get; set; }
        [DataMember]
        public Int32  iCodEmpleado      { get; set; }
        [DataMember]
        public Int32  dtFechaRegistro   { get; set; }
        [DataMember]
        public Int32  bActivo           { get; set; }
    }
}
