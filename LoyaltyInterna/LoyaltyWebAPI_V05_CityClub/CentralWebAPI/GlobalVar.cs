using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralWebApi
{
    public static class GlobalVariables
    {
        public static int GenerarToken_IdNumCte { get; set; }
        public static string GV_Client_ID { get; set; }
        public static int GV_IdNumCte { get; set; }
        public static int GV_bitValidaCte { get; set; }
        public static int GV_IdNumCte_Nuevo { get; set; }
        public static string GV_Refresh_Token { get; set; }
        public static string GV_refreshTokenTicket { get; set; }

        public static int GV_aplClientID { get; set; } // Se refiere al Apl de la base de datos

        public static string URLShortener_result { get; set; }
        public static string URLShort_result { get; set; }

        // readonly variable
        public static string Foo
        {
            get
            {
                return "foo";
            }
        }

        // read-write variable
        public static bool ErrorFlag
        {
            get
            {
                return HttpContext.Current.Application["ErrorFlag"] != null ? (bool)HttpContext.Current.Application["ErrorFlag"] : false;
            }
            set
            {
                HttpContext.Current.Application["ErrorFlag"] = value;
            }
        }

        // Variables de encriptación de datos
        public static string GlobalVars_strIdKey_valida { get; set; }
        public static string GlobalVars_strCuenta_enc_valida { get; set; }
        public static string GlobalVars_strVenc_enc_valida { get; set; }
        public static string GlobalVars_strNip_enc_valida { get; set; }

        public static int GlobalVars_IdOrden { get; set; }

        public static string ErrorMessage
        {
            get
            {
                return HttpContext.Current.Application["ErrorMessage"] as string;
            }
            set
            {
                HttpContext.Current.Application["ErrorMessage"] = value;
            }
        }
    }
}