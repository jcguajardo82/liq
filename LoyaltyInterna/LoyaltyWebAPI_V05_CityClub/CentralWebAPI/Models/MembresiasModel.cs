using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ValidateMemberModelRequest
    {
        public string membershipID { get; set; }
        public string clientId { get; set; }
    }

    public class ValidateMemberModelResponse
    {
        public string cve_RespCode { get; set; }
        public string desc_MensajeError { get; set; }
        public string membershipToken { get; set; }
    }

    public class SFValidaMembResponse
    {
        public string Cve_RespCode { get; set; }
        public string Desc_MensajeError { get; set; }
        public string Cve_TokenMemb { get; set; }
    }

    public class SFValidaMembRequest
    {
        public string Id_Cve_CteInet { get; set; }
        public string Id_Num_CtaMemb { get; set; } = "";
        public string Id_Cve_TokenMemb { get; set; } = "";
    }

    public class GetMembershipModelResponse
    {
        public string cve_RespCode { get; set; }
        public string desc_MensajeError { get; set; }
        public string clientName { get; set; }
        public string clientEmail { get; set; }
        public string membershipID { get; set; }
        public string membershipType { get; set; }
        public string membershipExpirationDate { get; set; }
        public MembershipAddress membershipAddress { get; set; }
        public List<AdditionalMemberships> additionalMemberships { get; set; }
        public List<Balance> balances { get; set; }
    }

    public class MembershipAddress
    {
        public string postalCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string buildingNumber { get; set; }
        public string details { get; set; }
        public string colonia { get; set; }
    }
      
     public class AdditionalMemberships 
     {
        public string clientName { get; set; }
        public string clientEmail { get; set; }
        public string membershipID { get; set; }
        public string membershipType { get; set; }
        public string membershipExpirationDate { get; set; }
    }

    public class Balance
    {
        public string accountType { get; set; }
        public string balance { get; set; }
    }

    public class GenerateMembershipModelRequest
    {
        public string action { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string clientEmail { get; set; }
        public string orderId { get; set; }
        public string membershipID { get; set; }
        public Memberships memberships { get; set; }
    }

    public class Memberships
    {
        public string membershipOwnerName { get; set; }
        public string membershipOwnerEmail { get; set; }
        public string membershipType { get; set; }
        public MembershipAddress membershipAddress { get; set; }
    }

    public class GenerateMembershipModelResponseBase : MembershipDetailModel
    {
        public string cve_RespCode { get; set; }
        public string desc_MensajeError { get; set; }
    }

    public class MembershipDetailModel
    {
        public string membershipType { get; set; }
        public string membershipID { get; set; }
        public string membershipToken { get; set; }
        public string membershipText { get; set; }
    }

    public class ValidateMembEstatusResponse
    {
        public string Cve_RespCode { get; set; }
        public string Desc_MensajeError { get; set; }
    }

    public class LoyaltyBalance
    {
        public string Cant_SdoPuntos { get; set; }
        public string Imp_SdoComp { get; set; }
        public string Imp_SdoDE { get; set; }
        public string Imp_SdoEfvo { get; set; }
        public string Imp_SdoCred { get; set; }
    }

    public class ValidaAltaRenovacion
    {
        public string Id_Cve_CteInet { get; set; }
        public string Id_Cve_TipoMemb { get; set; }
    }
}