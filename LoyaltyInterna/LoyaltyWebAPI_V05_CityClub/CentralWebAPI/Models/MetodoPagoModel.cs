using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class MetodoPagoModel
    {

    }

    public class DatosURL_Req
    {
        //Requeridos por el usuario cliente
        public int Id_Num_Aplicacion{ get; set;}
        public string Id_Num_Orden { get; set; }
        public string importe { get; set; }
        public int Csc_MetodoPago { get; set; }  
    }

    public class DatosURL_Mem 
    {
        public string Id_Num_Cte { get; set; }
        public string Id_Num_Aplicacion { get; set; }
        public string Id_Num_Orden { get; set; }
        public string importe { get; set; }
        public string Csc_MetodoPago { get; set; }
    }

    public class DatosURL_Res
    {
        public int Id_Num_Transaccion { get; set; }
        public string URL { get; set; }
    }

    public class Tran_Autenticacion_Req : DatosURL_Req
    {
        public int Num_Cliente { get; set; }
        public string Nom_Cliente{ get; set;} = "";
        public int puntos { get; set; } = 0;
        public string Cardsecuritycode{ get; set;}
        public int id_num_adq{ get; set;}
        public string Num_tarj{ get; set; } = "";
        public string anio{ get; set; } = "";
        public string mes{ get; set; } = "";
        public string Banco{ get; set;} = "";
        public string TipoTarjeta{ get; set; } = "";
        public string FormatoTienda{ get; set; } = "";
        public string Num_tarj_enc{ get; set; } = "";
        public string vencimiento_enc{ get; set; } = "";
        public string anio_enc{ get; set; } = "";
        public string mes_enc{ get; set; } = "";
        public string Cardsecuritycode_enc{ get; set; } = "";
        public string IdKey{ get; set; } = "";
        public string Num_tarj_des{ get; set; } = "";
        public string Cardsecuritycode_des{ get; set; } = "";
        public string anio_des{ get; set; } = "";
        public string mes_des{ get; set; } = "";
        //public object pipeSesion { get; set; }
    }

    public class eFormaPagoCte_Res
    {
        public int Id_Num_Cte { get; set; } = 0;
        public int Id_Cnsc_FormaPagoCte_d { get; set; } = 0;
        public int Id_Num_FormaPago { get; set; } = 0;
        public string Cuenta { get; set; } = "";
        public string Vec { get; set; } = "";
        public string Cuenta_enc { get; set; } = "";
        public string Vec_enc { get; set; } = "";
        public string Nip_enc { get; set; } = "";
        public string IdKey { get; set; } = "";
        public decimal Bit_FormaEliminada { get; set; } = decimal.Parse("0.0");
        public string Nip { get; set; } = "";
        public string Banco { get; set; } = "";
        public string Num_Cheque { get; set; } = "";
        public string Nombre_Cliente { get; set; } = "";
        public string TipoTarj { get; set; } = "";
        public string MES { get; set; } = "";
        public string ANIO { get; set; } = "";
    }

    public class DatosTarjeta_Req
    {
        public int Tipo_Metodo_Pago { get; set; }
        public string Id_Num_FormaPago { get; set; }
        public string Cuenta { get; set; }
        public string Venc { get; set; }
        public string Nip { get; set; }
        public string Banco { get; set; }
        public string NombreTitTarjeta { get; set; }
        public string Tipo_Tarjeta { get; set; }
    }

    public class ActMetodoPago_Req
    {
        public int Opcion { get; set; }
        public int Cnsc { get; set; }
    }

    public class MetodoPagoModel_Res
    {
        public int Id_Cnsc_FormaPagoCte_d { get; set; }
        public string TipoTarj { get; set; }
        public string Id_Num_FormaPago { get; set; }
        public string Desc_FormaPago { get; set; }
        public string Cuenta { get; set; }
    }

    public class AutenticacionRespuesta_Req
    {
        public int Id_Num_Transaccion { get; set; }
    }

    public class AutenticacionRespuesta_Res
    {
        public string Cve_ResponseCode { get; set; }
        public string Desc_ResponseCode { get; set; }
        public string Cve_RefTran { get; set; }
        public string Cve_Autz { get; set; }
        public string Imp_Trans { get; set; }
    }

    public class xmlSantander
    {
        public string id_company { get; set; }
        public string id_branch { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
        public string reference { get; set; }
        public string amount { get; set; }
        public string moneda { get; set; }
        public string canal { get; set; }
        public string omitir_notif_default { get; set; }
        public string st_correo { get; set; }
        public string fh_vigencia { get; set; }
        public string mail_cliente { get; set; }
        public string st_cr { get; set; }
        public string DatosAdic_Id { get; set; }
        public string DatosAdic_Label { get; set; }
        public string DatosAdic_ClienteId { get; set; }
    }

    public class PreAutorizacionModel
    {
        public int Id_Num_Transaccion { get; set; }
        public string MerchTxnRef { get; set; }
        public string Desc_RespCode { get; set; }
        public string Cve_FolCPagos { get; set; }
        public string Cve_Autz { get; set; }
        public string Cve_RespCode { get; set; }
        public string Cve_CdError { get; set; }
        public string Desc_NbError { get; set; }
        public string Cve_Hora { get; set; }
        public string Cve_Fecha { get; set; }
        public string Desc_NbEmp { get; set; }
        public string Desc_NbMerchant { get; set; }
        public string Cve_TipoFP { get; set; }
        public string Desc_TpOper { get; set; }
        public string Desc_CcNomFP { get; set; }
        public int Num_FP { get; set; }
        public decimal Importe { get; set; }
        public string Cve_IdURL { get; set; }
        public string Cve_TokenFP { get; set; }
        public string Cve_eMailCte { get; set; }
    }

    public class EnvioPreAutorizacionModel
    {
        public int Id_Num_Transaccion { get; set; }
        public string MerchTxnRef { get; set; }
        public int Orden_Info { get; set; }
        public string Cve_Moneda { get; set; }
        public decimal Importe  { get; set; }
        public string FSV_PreAutz { get; set; }
        public string MerchId { get; set; }
    }

    public class Mensaje_RespuestaDB
    {
        public bool Bit_Error { get; set; }
        public string Desc_MensajeError { get; set; }
    }

    public class CierrePreAutorizacionModel
    {
        public int Id_Num_Transaccion { get; set; } = 0;
        public string id_company { get; set; } = "";
		public string id_branch { get; set; } = "";
        public string country { get; set; } = "";
        public string user { get; set; } = "";
        public string pwd { get; set; } = "";
        public string amount { get; set; } = "";
        public string no_operacion { get; set; } = "";
        public string usrtransacction { get; set; } = "";
        public string crypto { get; set; } = "";
        public string propina { get; set; } = "";
        public string version { get; set; } = "";
        public string Numero_Orden { get; set; } = "";
        public string type { get; set; } = "";
        public string Cve_DataComercio { get; set; } = "";
        public string RespuestaCargoCompl { get; set; } = "";
        public string FormatoTienda { get; set; } = "";
    }

    public class SegundoCobroModel
    {
        public int Id_Num_Transaccion { get; set; }
        public string amount { get; set; }
        public string merchant { get; set; }
        public string reference { get; set; }
        public string tp_operation { get; set; }
        public string crypto { get; set; }
        public string type { get; set; }
        public string number_tkn { get; set; }
        public string expmonth { get; set; }
        public string expyear { get; set; }
        public string id_company { get; set; }
        public string id_branch { get; set; }
        public string country { get; set; }
        public string user { get; set; }
        public string pwd { get; set; }
        public string currency { get; set; }
        public string Cve_DataComercio { get; set; }
        public string NoOrden { get; set; }
        public string FormatoTienda { get; set; }
    }

    public class EnvioAutCierrePreAutorizacion_Req
    {
        public int Id_Num_Transaccion { get; set; }
        public string MerchTxnRef { get; set; }
        public string Cve_FolCPagos { get; set; }
        public decimal Importe { get; set; }
        public string Cve_Cripto { get; set; }
        public string Cve_Version { get; set; }
        public string FormatoTienda { get; set; }
    }

    public class CierrePreAutorizacionModel_Res
    {
        public int Id_Num_Transaccion { get; set; }
        public string MerchTxnRef { get; set; } = "";
        public string Desc_RespCode { get; set; } = "";
        public string Cve_FolCPagos { get; set; } = "";
        public string Cve_Autz { get; set; } = "";
        public string Cve_RespCode { get; set; } = "";
        public string Cve_CdError { get; set; } = "";
        public string Desc_NbError { get; set; } = "";
        public string Cve_Hora { get; set; } = "";
        public string Cve_Fecha { get; set; } = "";
        public string Nom_Cte { get; set; } = "";
        public string Nom_Calle { get; set; } = "";
        public string Cve_NumTjta { get; set; } = "";
        public string Cve_MesExp { get; set; } = "";
        public string Cve_AnioExp { get; set; } = "";
        public string Importe { get; set; } = "0.00";
        public string voucher { get; set; } = "";
        public string voucher_comercio { get; set; } = "";
        public string voucher_cliente{ get; set; } = "";
        public string Date { get; set; } = "";
        public string company { get; set; } = "";
        public string merchant { get; set; } = "";
        public string type { get; set; } = "";
        public string operation { get; set; } = "";
        public string amount { get; set; } = "";

    }

    public class EnvioCargoComplementario_Req
    {
        public int Id_Num_Transaccion { get; set; }
        public string MerchTxnRef { get; set; }
        public string MerchId { get; set; }
        public string Cve_TipoOper { get; set; }
        public string Cve_RefTran { get; set; }
        public string Cve_Cripto { get; set; }
        public string Cve_TipoTjta { get; set; }
        public string Cve_TokenFP { get; set; }
        public string Cve_MesExp { get; set; }
        public string Cve_AnioExp { get; set; }
        public string Cve_Moneda { get; set; }
        public decimal Importe { get; set; }
        public string FormatoTienda { get; set; }
    }

    public class CargoComplementarioModel_Res
    {
        public int Id_Num_Transaccion { get; set; } = 0;
        public string MerchTxnRef { get; set; } = "";
        public string Desc_RespCode { get; set; } = "";
        public string Cve_FolCPagos { get; set; } = "";
        public string Cve_Autz { get; set; } = "";
        public string Cve_RespCode { get; set; } = "";
        public string Cve_CdError { get; set; } = "";
        public string Desc_NbError { get; set; } = "";
        public string Cve_Hora { get; set; } = "";
        public string Cve_Fecha { get; set; } = "";
        public string Desc_NbEmp { get; set; } = "";
        public string Desc_NbMerchant { get; set; } = "";
        public string Nom_Calle { get; set; } = "";
        public string Desc_TipoTjta { get; set; } = "";
        public string Desc_TipoOper { get; set; } = "";
        public string Nom_Cte { get; set; } = "";
        public string Cve_NumTjta { get; set; } = "";
        public string Cve_MesExp { get; set; } = "";
        public string Cve_AnioExp { get; set; } = "";
        public string Importe { get; set; } = "";
        public string Desc_Voucher { get; set; } = "";
    }

    public class RespuestaCargoComplementario
    {
        public string Response { get; set; } = "";
        public string CdError_CC { get; set; } = "";
        public string Dsc_NbError_CC { get; set; } = "";
    }

    public class CierreVentaModel
    {
        public int Id_Num_Transaccion { get; set; }
        public string amount { get; set; }
        public string Numero_Orden { get; set; }
    }

    public class CierreCeroModel : CierreVentaModel
    {
        public string FolioPago { get; set; }
    }

    public class ValidaTotalOrden_Res
    {
        public bool Bit_Error { get; set; }
        public string Desc_MensajeError { get; set; }
        public bool Bit_ReqCobroCompl { get; set; }
        public decimal Imp_CobroCompl { get; set; }
        public string Cve_FolCPagos { get; set; }
        public decimal Imp_PreAutz { get; set; }
        public string Cve_MerchID { get; set; }
        public string Cve_RefTran { get; set; }
        public string Cve_TipoOperCAI { get; set; }
        public string Cve_CryptoCAI { get; set; }
        public string Cve_TipoFP { get; set; }
        public string Cve_Token { get; set; }
        public string Cve_MesExp { get; set; }
        public string Cve_AnioExp { get; set; }
        public string Cve_UsrTransaction { get; set; }
        public string Cve_VerCierrePreAutz { get; set; }
        public string Cve_CompaniaID { get; set; }
        public string Cve_BranchID { get; set; }
        public string Cve_DataComercio { get; set; }
    }

    public class Respuesta_XML
    {
        public string NumError { get; set; }
        public string DescEror { get; set; }
        public string merchId { get; set; }
        public string tipotarjeta{ get; set; }
        public string NumeroTarjetadeCredito { get; set; }
        public string Orden { get; set; }
        public string TransaccionSoriana { get; set; }
        public string NumTransaccion { get; set; }
        public string IdAutorizacion { get; set; }
        public string merchTxnRef { get; set; }
        public string qsiResponseCode { get; set; }
        public string ResultadoTransaccion { get; set; }
        public string CSC { get; set; }
        public string importe { get; set; }
        public string receiptNo { get; set; }
        public string acqResponseCode { get; set; }
        public string batchNo { get; set; }
    }

    public class CierreTransaccion_Res
    {
        public string xml { get; set; }
    }

    public class GeneraTokenCityClub_Req
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}