using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class TokenModel
    {
        public Estatus Estatus { get; set; }
        public Control Control { get; set; }
    }

    public class Estatus
    {
        public int numError { get; set; }
        public string descError { get; set; }
        public string descErrorCte { get; set; }

    }

    public class Control
    {
       public int idNumCte { get; set; }
       public string tokenDispositivo { get; set; }  
    }

    public class Class_Login
    {
        public Datos_Cliente Cliente { get; set; }
        public int numError { get; set; }
        public string descError { get; set; }
        public string descErrorCte { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int IdNumCte { get; set; }

    }

    public class Datos_Cliente
    {
        public string Id_Num_Cte { get; set; }
        public string  Nom_Cte { get; set; }
        public string Ap_Paterno { get; set; }
        public string Ap_Materno { get; set; }
        public string Pregunta { get; set; }
        public string Cve_Respuesta { get; set; }
        public string Fec_Movto { get; set; }
        public string Cve_IdCte { get; set; }
    }

    public class Token_Refresh
    {
        public Refresh Refresh_Token { get; set; }
        public int numError { get; set; }
        public string descError { get; set; }
    }


    public class Refresh
    {
        public string Id_Num_Cte { get; set; }
        public string Desc_SOMovil { get; set; }
        public string RefreshToken { get; set; }
        public string FEV { get; set; }
        public string FSV { get; set; }
        public string Json { get; set; }
    }
}