using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Qaliwarma.Maestros.BE
{
    [DataContract]
    public class BE_VENTA
    {
        [DataMember]
        public int iTipo { get; set; }
        [DataMember]
        public int iCodVenta { get; set; }
        [DataMember]
        public DateTime dtFechaVenta { get; set; }
        [DataMember]
        public int iCodEmpleadoTrabajador { get; set; }
        [DataMember]
        public int iCodCliente { get; set; }
        [DataMember]
        public int iTipoVenta { get; set; }
        [DataMember]
        public int iIGV { get; set; }
        [DataMember]
        public Decimal nTotalVenta { get; set; }
        [DataMember]
        public Boolean bDescuento { get; set; }
        [DataMember]
        public Boolean bDescuentoCantidad { get; set; }
        [DataMember]
        public int iCodEmpleado { get; set; }
        [DataMember]
        public DateTime dtFechaRegistro { get; set; }
        [DataMember]
        public Boolean bActivo { get; set; }
        [DataMember]
        public String vNombreTerminal { get; set; }
        [DataMember]
        public String vIpTerminal { get; set; }
    }
}
