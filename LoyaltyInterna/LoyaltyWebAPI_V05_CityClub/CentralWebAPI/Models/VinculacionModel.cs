using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class VinculacionModel
    {       
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string FechaNacimiento { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string LoyaltyAccount { get; set; }
        public string CveAcceso { get; set; }
        public string CveRegistro { get; set; }
        public string TarjetaActual { get; set; }
        public string TarjetaNueva { get; set; }
        public string Ticket { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Cve_Accion { get; set; }
    }

    public class VinculacionModel_Response
    {
        public string Nombre { get; set; } = "Nombre";
        public string Paterno { get; set; } = "Paterno";
        public string Materno { get; set; } = "Materno";
        public string Mail { get; set; } = "prueba@soriana.com.mx";
        public string Telefono { get; set; } = "8129756166";
        public string CveAcceso { get; set; } = "CVEACCESO";
        public string CveRegistro { get; set; } = "CVERegistro";
        public string TarjetaActual { get; set; } = "12345678912345";
        public string TarjetaNueva { get; set; } = "9876543212345";
        public string Ticket { get; set; } = "234256772899265420";
        public string Error { get; set; } = "";
    }

    public class Encabezado
    {
       public bool Bit_Error { get; set; }
       public string Desc_Error { get; set; }
    }

    public class ValidacionTarjeta : Encabezado
    {
       public string Codigo_Error { get; set; }
    }

    public class ClienteLealtadVinculacion_Res : ValidacionTarjeta
    {
        //public bool Bit_Error { get; set; }
        //public string Desc_Error { get; set; }
        //public string Codigo_Error { get; set; }
        public string Id_Cve_TokenCta { get; set; }
        public string Cve_MascaraCta { get; set; }
    }
}