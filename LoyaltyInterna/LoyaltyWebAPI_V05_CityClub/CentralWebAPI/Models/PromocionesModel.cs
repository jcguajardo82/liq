using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class PromocionesModel
    {
        public int Id_Num_TipoPromoDcto { get; set; }
        public string FEV_TipoPromoDcto { get; set; }
        public string FSV_TipoPromoDcto { get; set; }
        public string Desc_TipoPromoDcto { get; set; }
        public string Desc_TipoPromoDctoDetAS { get; set; }
        public string Desc_TipoPromoDctoAdicAS { get; set; }
        public string Desc_TipoPromoDctoCondAS { get; set; }
        public bool Bit_PromoElegibleCte { get; set; }
        public string Cve_Usuario { get; set; }
        public byte[] Img_TipoPromoDctoAS { get; set; }
    }

    public class ActivacionPromocionesRes
    {
        public bool Bit_Error { get; set; }
        public string Desc_MsgError { get; set; }
    }

    public class ActivacionReq
    {
        public int Id_Num_CteInet { get; set; } 
         public int Id_Num_TipoPromoDcto { get; set; } 
    }

    public class PromocionReq
    {
        public string Id_Num_TipoPromoDcto { get; set; }
    }
}