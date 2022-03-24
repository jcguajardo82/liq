using System;
using System.Collections.Generic;

namespace WebApplication4.Models
{
    // Models returned by AccountController actions.

    public enum MailType {

        CodigoVerificacion,
        Puntos,
        Ticket,
        Promocion
    }

    public class RegisterViewModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string clientId { get; set; }
        public string tokernCard { get; set; }
        public string maskCard { get; set; }
    }

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }
        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public List<LoyaltyAccountViewModel> Cuentas { get; set; }
        public List<DatosFiscalesModels> DatosFiscales { get; set; }
    }

    public class BalanceAccountModel
    {
        public string SaldoPuntos { get; set; } = "0";
        public string SaldoDineroElectronico { get; set; } = "0.0";
        public string SaldoEfectivo { get; set; } = "0.0";
        public string Saldo { get; set; } = "0.0";
    }

    public class DatosFiscalesModels
    {
        public string Id_Cnsc_CteRfc { get; set; }
        public string Id_Cve_RFC { get; set; }
        public string RazonSocial { get; set; }
        public string Id_Cve_TipoUsoCFDI { get; set; }
        public string Id_Num_CP { get; set; }
    }

    public class LoyaltyAccountViewModel
    {
        public string UserId { get; set; } = "";
        public string AccountMask { get; set; } = "";
        public string AccountToken { get; set; } = "";
        public string AccountImagePath { get; set; } = "";
        public string AccountName { get; set; } = "";
        public bool BalanceActive { get; set; } = false;
        public BalanceAccountModel Saldos { get; set; }
    }

    public class LoyaltyAccountListViewModel
    {
        public string UserId { get; set; }
        public int ActualPage { get; set; }
        public int TotalPages { get; set; }
        public int ItemsByPage { get; set; }
        public int TotalItems { get; set; }
        public LoyaltyAccountViewModel[] Accounts { get; set; } = { };
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }


    public class MailVieModels
    {
        public MailType BrokerMail { get; set; }
        public string Id_Num_TipoEnvio { get; set; }
        public List<string> Receptores { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public string Cve_CodSeg { get; set; }
    }

    public class InfoClienteModel
    {
        public EstatusClienteModel Estatus { get; set; }
        public PersonaClienteModel Persona { get; set; }
        public List<InfoDireccionClienteModel> Direccion { get; set; }
        public List<LoyaltyAccountViewModel> Cuentas { get; set; }
        public List<DatosFiscalesModels> DatosFiscales { get; set; }
        public infopAppConfigClienteModel AppConfig { get; set; }
        public TerminosCondiciones TerminosCond { get; set; }
    }

    public class InfoDireccionClienteModel
    {
        public int idCnscDirCte { get; set; }
        public string nomDirCte { get; set; }
        public string nomRecibeCte { get; set; }
        public int idEstado { get; set; }
        public string nomEstadoCte { get; set; }
        public int idCiudad { get; set; }
        public string nomCiudadCte { get; set; }
        public string nomColoniaCte { get; set; }
        public string nomCalleCte { get; set; }
        public string numExtDirCte { get; set; }
        public string numIntDirCte { get; set; }
        public string CPCte { get; set; }
        public string telefonoDomCte { get; set; }
        public string idtipoDirCte { get; set; }
        public int IdDirDefault { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }

    public class infopAppConfigClienteModel
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string tokenDispositivo { get; set; }
        public int idTipoEntrega { get; set; }
        public string nomTipoEntrega { get; set; }
        public int idTienda { get; set; }
        public string nomTienda { get; set; }
        public int idEstado { get; set; }
        public string nomEstadoTienda { get; set; }
        public int idCiudad { get; set; }
        public string nomCiudadTienda { get; set; }
    }

    public class EstatusClienteModel
    {
        public int numError { get; set; }
        public string descError { get; set; }
        public string descErrorCte { get; set; }
    }

    public class PersonaClienteModel
    {
        public string nomCte { get; set; }
        public string apPaternoCte { get; set; }
        public string apMaternoCte { get; set; }
        public string telefonoCtev { get; set; }
        public string celularCtev { get; set; }
        public string numTarjCteLealtad { get; set; }
        public string telOficina { get; set; }
        public string extOficina { get; set; }
        public string eMail { get; set; }
        public string idCte { get; set; }
        public string bitActivado { get; set; }
    }

    public class InvoiceResponseModels
    {
        public string code { get; set; } = "00";
        public string message { get; set; } = string.Empty;
    }

    public class InvoiceRegisterModel
    {
        public string Identificador { get; set; } = string.Empty;
        public string RFC { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string UsoCFDI { get; set; } = string.Empty;
        public string Fact { get; set; } = string.Empty;
        public string CP { get; set; } = string.Empty;
        public bool Bit_FactAut { get; set; } = true;
    }

    public class InvoiceRegisterResponseModel
    {
        public string Id_Fiscal { get; set; } = string.Empty;
        public string RFC { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Clave_UsoCFDI { get; set; } = string.Empty;
        public string CP { get; set; } = string.Empty;
    }

    public class InsDatosCliente
    {
        public string idNumCte { get; set; }
        public EstatusClienteModel Estatus { get; set; }
        public List<InvoiceRegisterResponseModel> DatosFiscales { get; set; }
    }

    public class ActDatosCliente
    {
        public EstatusClienteModel Estatus { get; set; }
        public string nomCte { get; set; }
        public string apPaternoCte { get; set; }
        public string apMaternoCte { get; set; }
        public string telefonoCte { get; set; }
        public string celularCte { get; set; }
        public string numTarjCteLealtad { get; set; }
        public List<InvoiceRegisterResponseModel> DatosFiscales { get; set; }
    }

    public class TerminosCondiciones
    {
        public string Fec_AceptaTermCond { get; set; }
    }

    public class TerminosEstatus_Res
    {
        public bool Bit_Error { get; set; }
        public string Desc_Error { get; set; }
    }

    public class VisitaUpd_Res
    {
        public int numError { get; set; }
        public string descError { get; set; }
        public string descErrorCte { get; set; }
        public string idNumVisita { get; set; }
    }
}
