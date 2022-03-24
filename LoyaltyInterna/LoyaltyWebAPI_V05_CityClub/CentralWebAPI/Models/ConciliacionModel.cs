using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ConciliacionModelRequest
    {
        public string Id_Fecx_Vta { get; set; }
        public string Id_Num_UN { get; set; }
        public string Id_Num_Cajero { get; set; }
        public string Id_Num_Caja { get; set; }
        public string Id_Num_Ticket { get; set; }
        public string Id_Num_OrdenInet { get; set; }
        public string Imp_TotOrdenInet { get; set; }
    }

    public class ConciliacionModelResponse
    {
        public string Cve_CodResp { get; set; }
        public string Desc_CodRespMsg { get; set; }    
        public List<DetalleConciliacion> lstDetalleConciliacion { get; set; }
        
    }

    public class DetalleConciliacion
    {
        public string Id_Num_FormaPago { get; set; }
        public string Imp_FormaPago { get; set; }
        public string Cve_FmtoVoucher { get; set; }
        public string Cve_Adquirente { get; set; }
        public string Cve_Autz { get; set; }
        public string Cve_Ref01 { get; set; }
        public string Cve_Ref02 { get; set; }
    }
}
 