using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Parametros
    {
        // ************************************ GENERALES *************************************
        public string SecretKey { get; set; }
        // AQUELLOS QUE SE REPITEN EN DISTINTOS SERVICIOS
        public string nomCte { get; set; }
        public string telefonoCte { get; set; }
        public int? idCnscDirCte_Opc { get; set; }
        public string correoCte { get; set; }
        public int idEstadoCte { get; set; }
        public int? idEstadoCte_Opc { get; set; }
        public int idCiudad { get; set; }
        public int? idCiudad_Opc { get; set; }
        public string nomCiudad { get; set; }
        public string claveCte { get; set; }
        public string CPCte { get; set; }
        public int? idEstado_Opc { get; set; }
        public int? idCarrito_Opc { get; set; }
        public int idTienda { get; set; }
        public short short_idTienda { get; set; }
        public int? Pagina_Opc { get; set; }
        public int? idMarca1_Opc { get; set; }
        public int? idMarca2_Opc { get; set; }
        public int? idMarca3_Opc { get; set; }
        public int? idOrdenamiento_Opc { get; set; }
        public int idNumCte { get; set; }
        public int? idLista_Opc { get; set; }
        public int idArticulo { get; set; }
        public string descripLista_Opc { get; set; }
        public int idNumVisita { get; set; }
        public int idLista { get; set; }
        public string descComentario { get; set; }
        public string nombreLista { get; set; }
        public int numOrden { get; set; }
        public string idNombReceta { get; set; }
        public string claveConfCte { get; set; }
        public int idCategCupon { get; set; }
        public string numTarjeta_Opc { get; set; }
        public int? bitPromocion_Opc { get; set; }
        public int idComent { get; set; }
        public string TelOficina_Opc { get; set; }
        public int idCnscDirCte { get; set; }
        public int idTipoDomCte { get; set; }

        // ************************************** CLIENTE **************************************
        // ***** GuardarInfoNotifAnonimo *****
        public string tokenDispositivo { get; set; }

        // ***** ValidarCorreoCte *****
        public string Correo { get; set; }

        // ***** ValidarCodigoPostal *****
        public string celularCte_Opc { get; set; }
        public string nomDirCte_Opc { get; set; }               // GENERAL
        public string nomCteDir_Opc { get; set; }               // GENERAL
        public int? idTipoDomCte_Opc { get; set; }              // GENERAL
        public string nomRecibeCte_Opc { get; set; }
        public string nomCiudadCte_Opc { get; set; }            // GENERAL
        public string nomColoniaCte_Opc { get; set; }           // GENERAL
        public string nomCalleCte_Opc { get; set; }             // GENERAL
        public string numExtCalleCte_Opc { get; set; }          // GENERAL
        public string numIntCalleCte_Opc { get; set; }
        public string CPCte_Opc { get; set; }                   // GENERAL
        public string telefonoCteTda_Opc { get; set; }          // GENERAL
        public string telefonoExtCteTda_Opc { get; set; }

        // ***** ActualizarInfoCliente *****
        public string apPaternoCte { get; set; }
        public string apMaternoCte { get; set; }
        public string numTarjCteLealtad_Opc { get; set; }

        // ***** CambiarClaveCliente *****
        public string claveActual { get; set; }
        public string claveNueva { get; set; }
        public string confClaveNueva { get; set; }

        // ***** ActualizarDatosEnTienda *****
        public string TelOficina { get; set; }
        public string ExtOficina_Opc { get; set; }

        // ***** ActualizarDirCliente *****
        public string nomDirCte { get; set; }
        public string nomRecibeCte { get; set; }
        public string nomCiudadCte { get; set; }
        public string nomColoniaCte { get; set; }
        public string nomCalleCte { get; set; }
        public string numExtCalleCte { get; set; }
        public string numIntCalleCte { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        // ***** ActualizarPropiedadesCliente *****
        public int? idTienda_Opc { get; set; }

        // ************************************** TIENDA ***************************************
        // ***** ObtenerTiendasActivas_SAD *****
        public int? bitSAD_Opc { get; set; }

        // ***** ObtenerTiendasActivas_TDA *****
        public int idEstado { get; set; }

        // ************************************* ARTICULO **************************************
        // ***** ObtenerArticulosPorCategoria *****
        public int idCategoria { get; set; }

        // ***** ObtenerArticulosBuscador *****
        public string descripArt { get; set; }

        // ***** ObtenerArticulosBuscador *****
        public string strAutoComp { get; set; }

        // ***** GuardarComentariosArticulo *****
        public string descComentario_Opc { get; set; }

        // ***** ObtenerArticulosMasComprados *****
        public int idPeriodo { get; set; }


        // ************************************** CARRITO **************************************        
        // ***** GuardarTodosArtCarrito *****
        public int aplClientID { get; set; }
        public string Codigos { get; set; }

        // ***** GuardarArticulosCarrito *****
        public int? aplClientID_Opc { get; set; }
        public decimal cantArt { get; set; }
        public int idTipoUniCompra { get; set; }
        public string descArticulo { get; set; }

        // ***** ModificarComentarioCarrito *****
        public string descripComent { get; set; }

        // ***** GuardarArticulosListaCompras *****
        public decimal cantArticulo { get; set; }
        public string descripArticulo { get; set; }

        // ***** CambiarNombreListaCompras *****
        public string nombreLista_Opc { get; set; }
        public string descLista_Opc { get; set; }

        // ************************************* COMERCIAL *************************************
        // ***** ObtenerBannerPublicitario *****
        public int idSeccion { get; set; }

        // ***** ObtenerRecetasPorCategoria *****
        public string idCategReceta { get; set; }
 
        // ************************************* ORDENES ***************************************
        // ***** ObtenerTipoEntrega *****
        public int idTipoEntrega { get; set; }        
        
        // ***** ObtenerTicketsPorDia *****
        public string fechaOrigenTicket { get; set; }

        // ***** ObtenerComprasAnterioresPorDia *****
        public string fechaOrigenOrden { get; set; }

        // ***** CrearOrden *****
        public string fechaEntrega { get; set; }
        public int? bitExpress_Opc { get; set; }
        public int? idFormaPago_Opc { get; set; }
        public decimal? montoEfevo_Opc { get; set; }
        public decimal? montoVales_Opc { get; set; }
        public string vigenciaTarjeta_Opc { get; set; }
        public string nipTarjeta_Opc { get; set; }
        public string bancoTarjeta_Opc { get; set; }

        // ***** ObtenerDetalleTicket *****
        public string numTicket { get; set; }
        public string fechaTicket { get; set; }

        // ***** ObtenerOrdenesEnProceso *****
        public int Articulo { get; set; }
        public int Cantidad { get; set; }
        public int unidadMedida { get; set; }

        // ***** ValidarTarjetaBonomatic *****
        public string numTarjeta { get; set; }

        // ************************************* DATOS FISCALES ***************************************
        public DatosFiscalesModels datosFiscales { get; set; }
    }

    public class ClienteLealtad_Model
    {
        public string Nom_Cte { get; set; }
        public string Ap_Paterno { get; set; }
        public string Ap_Materno { get; set; }
        public string Id_Email { get; set; }
    }

    public class ClienteLealtad_Res
    {
        public bool Bit_Error { get; set; }
        public string Desc_Error { get; set; }
        public string Id_Cve_TokenCta { get; set; }
        public string Cve_MascaraCta { get; set; }
    } 

    public class ActTarjeta_Res
    {
        public int Error { get; set; }
        public string DescError { get; set; }
    }

    public class Lealtad_Req
    {
        public string TarjetaLealtad { get; set; }
        public string TelefonoCelular { get; set; }
    }

    public class CancelaOrden_Req
    {
        public string Id_Num_Orden { get; set; }
        public string Ind_Accion { get; set; }
    }

    public class MisPedidos_Req
    {
        public string Id_Estatus { get; set; }
    }

    public class Flete_Req
    {
        public string idCnscDirCte { get; set; }
    }

    public class ComentarioArt_Req
    {
        public string idArticulo { get; set; }
        public string descComentario_Opc { get; set; }
    }

    public class EndpointProvider_MBSWebAPI
    {
        public string DoSearch { get; set; } = "DoSearch";
        public string GetSessionsInfo { get; set; } = "GetSessionsInfo";
   }
}