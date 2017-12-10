using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Qaliwarma.Maestros.BE
{
    [DataContract]
    public class BE_TBL_MENU 
    {
        [DataMember]
        public int iTipo { get; set; }
        [DataMember]
        public int iCodMenuItem { get; set; }
        [DataMember]
        public int iCodEmpresa { get; set; }
        [DataMember]
        public int iCodEmpleado { get; set; }
        [DataMember]
        public int iCodPerfil { get; set; }
        [DataMember]
        public String vNombreMenu { get; set; }
        [DataMember]
        public String vNombreAction { get; set; }
        [DataMember]
        public String vNombreControlador { get; set; }
        [DataMember]
        public Boolean bActivo { get; set; }
        [DataMember]
        public String vNombreTerminal { get; set; }
        [DataMember]
        public String vIpTerminal { get; set; }
        [DataMember]
        public String vIconMaterialize { get; set; }
    }
}
