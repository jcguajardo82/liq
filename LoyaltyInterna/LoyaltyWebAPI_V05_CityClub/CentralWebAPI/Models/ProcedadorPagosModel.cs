using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ConsultaOrdenResponseModel
    {
        public string Id_Cve_GUID { get; set; }
        public string Id_Cve_TokenCta { get; set; }
        public string Cant_Puntos { get; set; }
        public string Imp_Comp { get; set; }
        public string Imp_DE { get; set; }
        public string Imp_Efvo { get; set; }
        public string Imp_Cred { get; set; }
    }

    public class ConsultaOrdenRequestModel
    {
        public string Id_Cve_Orden { get; set; }
    }
}