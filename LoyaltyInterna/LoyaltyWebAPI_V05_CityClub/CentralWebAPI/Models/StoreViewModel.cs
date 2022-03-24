using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class StoreViewModel : LocalidadViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public byte[] image { get; set; }
        public int Id_Num_Logo { get; set; }
        public bool Bit_Serv { get; set; } = true;
        public bool Bit_Reco { get; set; } = true;
        public string Horario { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Region { get; set; }
    }


    public class LocalidadViewModel
    {
        public int Ids_Num_Poblacion { get; set; }
        public int Id_Num_Pais { get; set; }
        public int Id_Num_Estado { get; set; }
        public int Id_Num_Poblacion { get; set; }
        public string Nom_Pais { get; set; }
        public string Nom_Estado { get; set; }
        public string Nom_Poblacion { get; set; }
    }

    public class StoreReq
    {
        public int idEstado { get; set; }
        public int idCiudad { get; set; }
        public string CPCte_Opc { get; set; }
        public int bitSAD_Opc { get; set; }
    }
}