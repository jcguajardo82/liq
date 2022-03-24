using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Model_Base
    {
        public string Cve_RespCode { get; set; }
        public string Desc_MensajeError { get; set; }
    }

    public class LoyaltyReq_Base
    {
        public string tokenCard { get; set; }
        //public string tokernCard { get; set; }
        public string ClientId { get; set; }
    }

    public class CardResponse_Model
    {
        public string Cve_RespCode { get; set; }
        public string Desc_MensajeError { get; set; }
        public string tokenCard { get; set; }
        public string maskCard { get; set; }
    }

    public class LinkCard_Req : Client_Req
    {
        public string LoyaltyAccount { get; set; }
        public string ClientId { get; set; }
    }

    public class ReplaceCard_Req
    {
        public string idNumCte { get; set; }
        public string tokenCard { get; set; }  
        public string ReplacementLoyaltyAccount { get; set; }
        public string ticketId { get; set; }
    }

    public class Client_Req
    {
        public string Nombre { get; set; } = "";
        public string Paterno { get; set; } = "";
        public string Materno { get; set; } = "";
        public string Email { get; set; } = "";
    }

    public class ProgramaLealtad_Request
    {
        public string Action { get; set; } = "";
        public string LoyaltyAccount { get; set; } = "";
        public string ClientId { get; set; } = "";
        public string tokenCard { get; set; } = "";
        public string ReplacementLoyaltyAccount { get; set; } = "";
        public string accountType { get; set; } = "";
        public string import { get; set; } = "";
        public string ticketId { get; set; } = "";
    }

    public class Balance_Model
    {
        public string Cve_RespCode { get; set; }
        public string Desc_MensajeError { get; set; }
        public List<Balances> lstBalances { get; set; }
        public string clientName { get; set; }
        public string cardType { get; set; }
        public string cardName { get; set; }
        public string card { get; set; } 
    }

    public class Balances
    {
        public string accountType { get; set; }
        public string balance { get; set; }
    }

    public class RedencionSaldoRequest_Model
    {
        public string Id_Cve_Orden { get; set; }
        public string Id_Cve_CteInet { get; set; }
        public string Cve_Operacion { get; set; }
        public string Imp_Vta { get; set; }
        public string Cant_Puntos { get; set; }
        public string Imp_Comp { get; set; }
        public string Imp_Efvo { get; set; }
        public string Imp_DE { get; set; }
    }

    public class RedencionSaldoResponse_Model
    {
        public string Cve_RespCode { get; set; }
        public string Desc_MensajeError { get; set; }
        public string Authorization_Code { get; set; }
    }

    public class TicketList_Model
    {
        public string Cve_RespCode { get; set; }
        public string Desc_MensajeError { get; set; }
        public List<TicketContain> lstTicket { get; set; }
    }

    public class TicketContain
    {
        public string ticketId { get; set; }
        public string storeId { get; set; }
        public string storeName { get; set; }
        public string ticketDate { get; set; }
        public string ticketHour { get; set; }
        public string ticketTotal { get; set; }
    }

    public class TicketDetail_Model
    {
        public string Cve_RespCode { get; set; }
        public string Desc_MensajeError { get; set; }
        public string UserId { get; set; }
        public string TicketId { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string TicketDate { get; set; }
        public List<TicketLines> TicketLines { get; set; }
        public string TicketAmount { get; set; }
        public string TicketInvoiced { get; set; }
        public string TokenTarjeta { get; set; }
        public string ClienteId { get; set; }
        public string IdTarjeta { get; set; }
        public string TipoTienda { get; set; }
    }

    public class TicketLines
    {
        public string TextAlignment { get; set; }
        public string TextBold { get; set; }
        public string TextDoubleHeight { get; set; }
        public string Text { get; set; }
        public string TicketId { get; set; }
    }

    public class Ticket_Req
    {
        public string tokenCard { get; set; }
        public string ClientId { get; set; }
        public string   ticketId { get; set; }
    }
      
    public class Balance_Req
    {
         public string tokenCard { get; set; }
         public string ClientId { get; set; } 
    }

    #region Procesador de Pagos
    public class Saldo_Req
    {
        public string Id_Cve_Orden { get; set; }
        public string Id_Cve_GUID { get; set; }
        public string Id_Cve_TokenCta { get; set; }
        public string Cve_Operacion { get; set; }
        public decimal Imp_Vta { get; set; } = 0;
        public int Cant_Puntos { get; set; } = 0;
        public decimal Imp_Comp { get; set; } = 0;
        public decimal Imp_DE { get; set; } = 0;
        public decimal Imp_Efvo { get; set; } = 0;
        public decimal Imp_Cred { get; set; } = 0;
        public string Cve_Accion { get; set; }       
    }

    public class Saldo_Res
    {
        public string Cve_Autz { get; set; }
        public bool Bit_Error { get; set; }
        public string Desc_Error { get; set; }
    }
    #endregion

    #region PPS - Omonel 
    public class SaldosOmonel_Req
    {
        public string Id_Cve_Orden { get; set; }
        public string Id_Cve_GUID { get; set; }
        public string Id_Num_Cta { get; set; }
        public string Cve_Acceso { get; set; }
        public string Cve_Operacion { get; set; }
        public string Imp_Comp { get; set; }
        public string Cve_Accion { get; set; }
    }
   #endregion
}


/*@pId_Cve_Orden	varchar	36	No	Orden ID
@pId_Cve_GUID	    varchar	36	Sí	UUID
@pId_Cve_TokenCta	varchar	36	No	Token de tarjeta Programa Lealtad
@pCve_Operacion	    varchar	30	No	Tipo de opoeración: COMPRA, DEVOLUCION, CANCELACION
@pImp_Vta	        money	8	No	Importe de venta total de la orden
@pCant_Puntos	    int	    4	No	Cantidad de Puntos Recompensas
@pImp_Comp	        money	8	No	Importe de Saldo para compras
@pImp_DE	        money	8	No	Importe de Saldo de Dinero electrónico
@pImp_Efvo	        money	8	Sí	Importe de Saldo de Efectivo
@pImp_Cred	        money	8	Sí	Importe de Saldo de Crédito



Nombre Tipo de dato	Longitud	Opcional	Descripción
@pId_Cve_Orden	varchar	36	No	Orden ID
@pId_Cve_GUID	varchar	36	Sí	UUID
@pId_Cve_TokenCta	varchar	36	No	Token de tarjeta Programa Lealtad
@pCve_Operacion	varchar	30	No	Tipo de opoeración: COMPRA, DEVOLUCION, CANCELACION
@pImp_Vta	money	8	No	Importe de venta total de la orden
@pCant_Puntos	int	4	No	Cantidad de Puntos Recompensas
@pImp_Comp	money	8	No	Importe de Saldo para compras
@pImp_DE	money	8	No	Importe de Saldo de Dinero electrónico
@pImp_Efvo	money	8	Sí	Importe de Saldo de Efectivo
@pImp_Cred	money	8	Sí	Importe de Saldo de Crédito */
