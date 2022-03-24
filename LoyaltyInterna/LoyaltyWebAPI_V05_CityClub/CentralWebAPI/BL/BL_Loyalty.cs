using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

using WebApplication4.Providers;
using WebApplication4.Tools;
using WebApplication4.Models;

namespace WebApplication4.BL
{
    public class BL_Loyalty
    {
        ProvidersContext context = new ProvidersContext();
        Log_CentralWebAPI logCentral = new Log_CentralWebAPI();

        #region Controller
        public Model_Base BL_TestConn()
        {
            try
            {
                Model_Base ModelBase = new Model_Base();
                ModelBase.Cve_RespCode = "00";
                ModelBase.Desc_MensajeError = "CONNECTION OK";

                return ModelBase;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public CardResponse_Model BL_LinkCard(LinkCard_Req Req)
        {
            try
            {
                CardResponse_Model response = new CardResponse_Model();

                try
                {
                    var ds = new System.Data.DataSet();

                    if (!string.IsNullOrEmpty(Req.LoyaltyAccount))
                    {
                        logCentral.LogWebAPi("---------------INICIO DE ALTA DE USUARIO----------------");

                        response.Cve_RespCode = "00";
                        //response.c = Req.ClientId;  //dsCliente.Tables[0].Rows[0]["id_Num_Cte"].ToString();

                        logCentral.LogWebAPi("---------------INICIO DE ALTA DE USUARIO LEALTAD----------------");
                        logCentral.LogWebAPi("Cliente Id:" + Req.ClientId);

                        //lealtadDBHelper.FillDataSet(DBQuery.LealtadRegister(model), dsLealtad);
                        FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                        List<FmkTools.paramModel> listL1 = new List<FmkTools.paramModel>();

                        FmkTools.paramModel l1 = new FmkTools.paramModel { name = "pId_Cve_CteInet", value = string.IsNullOrEmpty(Req.ClientId) ? "0" : Req.ClientId, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                        listL1.Add(l1); l1 = new FmkTools.paramModel { name = "pId_Num_Cta", value = string.IsNullOrEmpty(Req.LoyaltyAccount) ? "0" : Req.LoyaltyAccount, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                        listL1.Add(l1); l1 = new FmkTools.paramModel { name = "pNom_Cte", value = string.IsNullOrEmpty(Req.Nombre) ? "" : Req.Nombre, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                        listL1.Add(l1); l1 = new FmkTools.paramModel { name = "pApPaterno", value = string.IsNullOrEmpty(Req.Paterno) ? "" : Req.Paterno, direction = ParameterDirection.Input, typeParm = typeof(string) };
                        listL1.Add(l1); l1 = new FmkTools.paramModel { name = "pApMaterno", value = string.IsNullOrEmpty(Req.Materno) ? "" : Req.Materno, direction = ParameterDirection.Input, typeParm = typeof(string) };
                        listL1.Add(l1); l1 = new FmkTools.paramModel { name = "pDesc_CorreoE", value = string.IsNullOrEmpty(Req.Email) ? "" : Req.Email, direction = ParameterDirection.Input, typeParm = typeof(string) };
                        listL1.Add(l1);

                        DataSet dsLealtad = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFAltaCtaAprecio_iuUP", false, listL1);


                        logCentral.LogWebAPi("---------------RESPONSE DE ALTA DE USUARIO----------------");
                        logCentral.LogWebAPi("DATOS:");

                        if (FmkTools.DatosDB.IsNullOrEmptyDataSet(dsLealtad))
                        {
                            logCentral.LogWebAPi("NO HAY DATOS:");
                        }
                        else
                        {
                            if (FmkTools.DatosDB.IsNullOrEmptyDatatable(dsLealtad.Tables[0]))
                            {
                                logCentral.LogWebAPi("NO HAY DATOS:");
                            }
                            else
                            {
                                logCentral.LogWebAPi(FmkTools.DatosDB.ConvertDatatableToXML(dsLealtad.Tables[0]));
                            }
                        }

                        if (Convert.ToBoolean(dsLealtad.Tables[0].Rows[0]["Bit_Error"].ToString()))
                        {
                            response.Cve_RespCode = "099";// dsCliente.Tables[0].Rows[0][0].ToString();
                            response.Desc_MensajeError = "ERROR ALTA DE CUENTA DE LEALTAD - " + dsLealtad.Tables[0].Rows[0][1].ToString();
                        }
                        else
                        {   
                            response.Cve_RespCode = "00";
                            response.Desc_MensajeError = "";
                            response.maskCard = dsLealtad.Tables[0].Rows[0]["Cve_MascaraCta"].ToString();
                            response.tokenCard = dsLealtad.Tables[0].Rows[0]["Id_Cve_TokenCta"].ToString();
                            //response.Id_Num_Cta = dsLealtad.Tables[0].Rows[0]["Id_Num_Cta"].ToString();
                        }
                    }
                    else
                    {
                        logCentral.LogWebAPi("---------------INICIO DE ALTA DE USUARIO----------------");
                     
                        response.Cve_RespCode = "00";
                        //response.clientId = Req.ClientId;

                        logCentral.LogWebAPi("---------------INICIO DE ALTA DE USUARIO LEALTAD----------------");
                        logCentral.LogWebAPi("Cliente Id:" + Req.ClientId);

                        FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                        List<FmkTools.paramModel> listL = new List<FmkTools.paramModel>();

                        FmkTools.paramModel l = new FmkTools.paramModel { name = "pId_Cve_CteInet", value = string.IsNullOrEmpty(Req.ClientId) ? "0" : Req.ClientId, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                        listL.Add(l); l = new FmkTools.paramModel { name = "pId_Num_Cta", value = string.IsNullOrEmpty(Req.LoyaltyAccount) ? "0" : Req.LoyaltyAccount, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                        listL.Add(l); l = new FmkTools.paramModel { name = "pNom_Cte", value = string.IsNullOrEmpty(Req.Nombre) ? "" : Req.Nombre, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                        listL.Add(l); l = new FmkTools.paramModel { name = "pApPaterno", value = string.IsNullOrEmpty(Req.Paterno) ? "" : Req.Paterno, direction = ParameterDirection.Input, typeParm = typeof(string) };
                        listL.Add(l); l = new FmkTools.paramModel { name = "pApMaterno", value = string.IsNullOrEmpty(Req.Materno) ? "" : Req.Materno, direction = ParameterDirection.Input, typeParm = typeof(string) };
                        listL.Add(l); l = new FmkTools.paramModel { name = "pDesc_CorreoE", value = string.IsNullOrEmpty(Req.Email) ? "" : Req.Email, direction = ParameterDirection.Input, typeParm = typeof(string) };
                        listL.Add(l);

                        DataSet dsLealtad = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFAltaCtaAprecio_iUP", false, listL);

                        logCentral.LogWebAPi("---------------RESPONSE DE ALTA DE USUARIO----------------");
                        logCentral.LogWebAPi("DATOS:");

                        if (FmkTools.DatosDB.IsNullOrEmptyDataSet(dsLealtad))
                        {
                            logCentral.LogWebAPi("NO HAY DATOS:");
                        }
                        else
                        {
                            if (FmkTools.DatosDB.IsNullOrEmptyDatatable(dsLealtad.Tables[0]))
                            {
                                logCentral.LogWebAPi("NO HAY DATOS:");
                            }
                            else
                            {
                                logCentral.LogWebAPi(FmkTools.DatosDB.ConvertDatatableToXML(dsLealtad.Tables[0]));
                            }
                        }

                        if (Convert.ToBoolean(dsLealtad.Tables[0].Rows[0]["Bit_Error"].ToString()))
                        {
                            response.Cve_RespCode = "099"; //dsCliente.Tables[0].Rows[0][0].ToString();
                            response.Desc_MensajeError = "ERROR ALTA DE CUENTA DE LEALTAD - " + dsLealtad.Tables[0].Rows[0][1].ToString();
                        }
                        else
                        {
                            response.Cve_RespCode = "00";
                            response.Desc_MensajeError = "";
                            response.maskCard = dsLealtad.Tables[0].Rows[0]["Cve_MascaraCta"].ToString();
                            response.tokenCard = dsLealtad.Tables[0].Rows[0]["Id_Cve_TokenCta"].ToString();
                            //response.Id_Num_Cta = dsLealtad.Tables[0].Rows[0]["Id_Num_Cta"].ToString();
                        }
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    response.Cve_RespCode = "99";
                    response.Desc_MensajeError = ex.Message;
                    logCentral.LogWebAPi("Exception ValidateLogin");
                    logCentral.LogWebAPi("Message : " + ex.Message);

                    return response;
                }
            }
            catch(Exception ex)
            {
                throw ex;            
            }
        } 

        public CardResponse_Model BL_LinkVirtualCard(LinkCard_Req Req)
        {
            CardResponse_Model Response = new CardResponse_Model();

            string ClienteID = string.Empty;

            try
            {
                #region Lealtad
                Response.Cve_RespCode = "00";
                ClienteID = Req.ClientId;

                logCentral.LogWebAPi("---------------INICIO DE ALTA DE USUARIO LEALTAD----------------");

                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                List<FmkTools.paramModel> listL = new List<FmkTools.paramModel>();

                #region Parametros
                FmkTools.paramModel l = new FmkTools.paramModel { name = "pId_Cve_CteInet", value = string.IsNullOrEmpty(Req.ClientId) ? "0" : Req.ClientId, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                listL.Add(l); l = new FmkTools.paramModel { name = "pId_Num_Cta", value = string.IsNullOrEmpty(Req.LoyaltyAccount) ? "0" : Req.LoyaltyAccount, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                listL.Add(l); l = new FmkTools.paramModel { name = "pNom_Cte", value = string.IsNullOrEmpty(Req.Nombre) ? "" : Req.Nombre, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                listL.Add(l); l = new FmkTools.paramModel { name = "pApPaterno", value = string.IsNullOrEmpty(Req.Paterno) ? "" : Req.Paterno, direction = ParameterDirection.Input, typeParm = typeof(string) };
                listL.Add(l); l = new FmkTools.paramModel { name = "pApMaterno", value = string.IsNullOrEmpty(Req.Materno) ? "" : Req.Materno, direction = ParameterDirection.Input, typeParm = typeof(string) };
                listL.Add(l); l = new FmkTools.paramModel { name = "pDesc_CorreoE", value = string.IsNullOrEmpty(Req.Email) ? "" : Req.Email, direction = ParameterDirection.Input, typeParm = typeof(string) };
                listL.Add(l);
                #endregion

                DataSet dsLealtad = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFAltaCtaAprecio_iUP", false, listL);

                #region Validacion Datos
                logCentral.LogWebAPi("---------------RESPONSE DE ALTA DE USUARIO----------------");
                logCentral.LogWebAPi("DATOS:");

                if (FmkTools.DatosDB.IsNullOrEmptyDataSet(dsLealtad))
                {
                    logCentral.LogWebAPi("NO HAY DATOS:");
                }
                else
                {
                    if (FmkTools.DatosDB.IsNullOrEmptyDatatable(dsLealtad.Tables[0]))
                    {
                        logCentral.LogWebAPi("NO HAY DATOS:");
                    }
                    else
                    {
                        logCentral.LogWebAPi(FmkTools.DatosDB.ConvertDatatableToXML(dsLealtad.Tables[0]));
                    }
                }
                #endregion

                if (Convert.ToBoolean(dsLealtad.Tables[0].Rows[0]["Bit_Error"].ToString()))
                {
                    Response.Cve_RespCode = "99"; // dsCliente.Tables[0].Rows[0][0].ToString();
                    Response.Desc_MensajeError = "ERROR ALTA DE CUENTA DE LEALTAD - " + dsLealtad.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    Response.Cve_RespCode = "00";
                    Response.Desc_MensajeError = "";
                    Response.maskCard = dsLealtad.Tables[0].Rows[0]["Cve_MascaraCta"].ToString();
                    Response.tokenCard = dsLealtad.Tables[0].Rows[0]["Id_Cve_TokenCta"].ToString();
                    //Response.Id_Num_Cta = dsLealtad.Tables[0].Rows[0]["Id_Num_Cta"].ToString();
                }
                #endregion

                return Response;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public CardResponse_Model BL_CardReplacement(ReplaceCard_Req Req)
        {
            string strStored = string.Empty;

            try
            {
                DataSet ds = new DataSet();
                DataSet dsLealtad = new DataSet();
                DataSet dsCel = new DataSet();
                ClienteLealtad_Model clienteLealtadReq = new ClienteLealtad_Model();
                CardResponse_Model ResponseClienteLealtad = new CardResponse_Model();
                //ValidacionTarjeta ResponseRelClientre = new ValidacionTarjeta();
                int ErrordNet = 0;
                string TarjetaLealtad = Req.ReplacementLoyaltyAccount;

                #region Validacion Cliente - Tarjeta
                ValidacionTarjeta ResponseRelClientre = BL_ValidaTarjeta(Req.idNumCte, Req.ReplacementLoyaltyAccount);
                #endregion

                if (ResponseRelClientre.Codigo_Error == "00")
                {
                    #region clASAltaCtaAprecio_iuUP
                    if (ErrordNet == 0)
                    {
                        strStored = "clSFAltaCtaAprecio_iuUP"; 
                        FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                        System.Collections.Hashtable parametersAlta = new System.Collections.Hashtable
                        {
                            { "@pId_Cve_CteInet", Req.idNumCte },
                            { "@pId_Num_Cta", TarjetaLealtad },
                            { "@pNom_Cte", clienteLealtadReq.Nom_Cte },
                            { "@pApPaterno",  clienteLealtadReq.Ap_Paterno },
                            { "@pApMaterno" , clienteLealtadReq.Ap_Materno },
                            { "@pDesc_CorreoE", clienteLealtadReq.Id_Email } 
                        };

                        dsLealtad = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFAltaCtaAprecio_iuUP", false, parametersAlta);
                                                                                                    
                        foreach (DataTable dt in dsLealtad.Tables)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["Bit_Error"].ToString() == "False")
                                {
                                    ResponseClienteLealtad.Cve_RespCode = "00";
                                }
                                else
                                {
                                    ResponseClienteLealtad.Cve_RespCode = "97";
                                }

                                ResponseClienteLealtad.Desc_MensajeError = row["Desc_Error"].ToString();
                                ResponseClienteLealtad.tokenCard = row["Id_Cve_TokenCta"].ToString();
                                ResponseClienteLealtad.maskCard = row["Cve_MascaraCta"].ToString();
                            }
                        }
                    }
                    else
                    {
                        ResponseClienteLealtad.Desc_MensajeError = "CENTRALWEBAPI - Error al Autenticar Cliente";
                        ResponseClienteLealtad.tokenCard = "";
                        ResponseClienteLealtad.maskCard = "";
                        ResponseClienteLealtad.Cve_RespCode = "099";
                    }
                    #endregion
                }
                else
                {
                    ResponseClienteLealtad.Cve_RespCode = ResponseRelClientre.Codigo_Error;     //098
                    ResponseClienteLealtad.Desc_MensajeError = ResponseRelClientre.Desc_Error;
                }

                return ResponseClienteLealtad;
            }
            catch (Exception ex)
            {
                logCentral.LogWebAPi("BL_ProgramaLealtad ERROR: SP " + strStored + " - " + ex.Message);

                throw ex;
            }
        }

        public CardResponse_Model BL_ReplacementByTicket(ReplaceCard_Req Req)
        {
            ValidacionTarjeta Response = new ValidacionTarjeta();
            CardResponse_Model ResponseLealtad = new CardResponse_Model();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);

                System.Collections.Hashtable parametersValidacion = new System.Collections.Hashtable
                {
                    { "@pId_Num_Cta", Req.ReplacementLoyaltyAccount },
                    { "@pCve_Ticket", Req.ticketId },
                    { "@pId_Cve_CteInet", Req.idNumCte }
                };

                DataSet ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFValidaCtaTicket_sUP", false, parametersValidacion);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Response.Codigo_Error = row["Cve_RespCode"].ToString();
                        Response.Desc_Error = row["Desc_Error"].ToString();
                    }
                }

                if (Response.Codigo_Error == "00")
                {
                    FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                    System.Collections.Hashtable parametersAlta = new System.Collections.Hashtable
                    {
                        { "@pId_Cve_CteInet", Req.idNumCte },
                        { "@pId_Num_Cta", Req.ReplacementLoyaltyAccount },
                        { "@pNom_Cte", "" },
                        { "@pApPaterno",  "" },
                        { "@pApMaterno" , "" },
                        { "@pDesc_CorreoE", "" }
                    };
                    
                    DataSet dsLealtad = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFAltaCtaAprecio_iuUP", false, parametersAlta);

                    foreach (DataTable dt in dsLealtad.Tables)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if(row["Bit_Error"].ToString() == "False")
                            {
                                ResponseLealtad.Cve_RespCode = "00";
                            }
                            else
                            {
                                ResponseLealtad.Cve_RespCode = "97";
                            }

                            ResponseLealtad.Desc_MensajeError = row["Desc_Error"].ToString();
                            ResponseLealtad.tokenCard = row["Id_Cve_TokenCta"].ToString();
                            ResponseLealtad.maskCard = row["Cve_MascaraCta"].ToString();
                        }
                    }
                }
                else
                {
                    ResponseLealtad.Cve_RespCode = Response.Codigo_Error;
                    ResponseLealtad.Desc_MensajeError = Response.Desc_Error;
                }

                return ResponseLealtad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Balance_Model BL_Balances(LoyaltyReq_Base Req)
        {
            try
            {
                Balance_Model Response = new Balance_Model();
                List<Balances> lstBalances = new List<Balances>();

                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                List<FmkTools.paramModel> listL = new List<FmkTools.paramModel>();

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_TokenCta", Req.tokenCard }
                };

                DataSet dsLealtad = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFConsultaCte_sUP", false, parameters);

                if (FmkTools.DatosDB.IsNullOrEmptyDataSet(dsLealtad) && FmkTools.DatosDB.IsNullOrEmptyDatatable(dsLealtad.Tables[0]))
                {
                    Response.Cve_RespCode = "05";
                    Response.Desc_MensajeError = "TARJETA NO VALIDA PARA ESTA OPERACION";

                    Response.clientName = "";
                    Response.cardName = "";
                    Response.cardType = "";

                    Balances balanceCash = new Balances();
                    lstBalances.Add(balanceCash);

                    Response.lstBalances = lstBalances;
                }
                else
                {
                    if (dsLealtad.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow row in dsLealtad.Tables[0].Rows)
                        {
                            Response.Cve_RespCode = "00";
                            Response.Desc_MensajeError = "";

                            Response.clientName = row["Nom_Cte"].ToString();
                            Response.cardName = row["Desc_TipoCta"].ToString();
                            Response.cardType = row["Id_Num_TipoCta"].ToString();
                            Response.card = row["Id_Num_Cta"].ToString();

                            Balances balanceCash = new Balances();
                            balanceCash.accountType = "cash";
                            balanceCash.balance = FmkTools.Converters.CheckNullOrEmpty(row["Imp_SdoEfvo"]) ? "0.0" : row["Imp_SdoEfvo"].ToString();
                            lstBalances.Add(balanceCash);

                            Balances balanceElec = new Balances();
                            balanceElec.accountType = "electronicmoney";
                            balanceElec.balance = FmkTools.Converters.CheckNullOrEmpty(row["Imp_SdoDE"]) ? "0.0" : row["Imp_SdoDE"].ToString();
                            lstBalances.Add(balanceElec);

                            Balances balancePts = new Balances();
                            balancePts.accountType = "points";
                            balancePts.balance = FmkTools.Converters.CheckNullOrEmpty(row["Cant_SdoPuntos"]) ? "0" : row["Cant_SdoPuntos"].ToString();
                            lstBalances.Add(balancePts);

                            Balances balanceSdoComp = new Balances();
                            balanceSdoComp.accountType = "BalanceComp";
                            balanceSdoComp.balance = FmkTools.Converters.CheckNullOrEmpty(row["Imp_SdoComp"]) ? "0" : row["Imp_SdoComp"].ToString();
                            lstBalances.Add(balanceSdoComp);

                            Response.lstBalances = lstBalances;
                        }
                    }
                    else
                    {
                        Response.Cve_RespCode = "05";
                        Response.Desc_MensajeError = "TARJETA NO VALIDA PARA ESTA OPERACION";

                        Response.clientName = "";
                        Response.cardName = "";
                        Response.cardType = "";

                        Balances balanceCash = new Balances();
                        lstBalances.Add(balanceCash);

                        Response.lstBalances = lstBalances;
                    }               
                }

                return Response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void BL_ReversoBalance()
        {
            try
            {

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public RedencionSaldoResponse_Model BL_RedemptionBalances(RedencionSaldoRequest_Model Req)
        {
            DataSet ds = new DataSet();
            try
            {
                RedencionSaldoResponse_Model Response = new RedencionSaldoResponse_Model();

                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                System.Collections.Hashtable parametersPago = new System.Collections.Hashtable
                {
                    { "@pId_Cve_Orden", Req.Id_Cve_Orden }, 
                    { "@pId_Cve_TokenCta", Req.Id_Cve_CteInet },
                    { "@pCve_Operacion", "COMPRA" },
                    { "@pImp_Vta", Req.Imp_Vta },
                    { "@pCant_Puntos", Req.Cant_Puntos },
                    { "@pImp_Comp", Req.Imp_Comp },
                    { "@pImp_Efvo", Req.Imp_Efvo },
                    { "@pImp_DE", Req.Imp_DE }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFCompMcia_pUP", false, parametersPago);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        Response.Authorization_Code = row["Cve_Autz"].ToString();
                        Response.Cve_RespCode = row["Bit_Error"].ToString();
                        Response.Desc_MensajeError = row["Desc_Error"].ToString();
                    }
                }

                return Response;
            }
            catch (Exception ex)
            {
                throw ex;                                                     
            }
        }
        #endregion

        #region Procesador de Pagos
        public Saldo_Res BL_ProcesadorPagos(Saldo_Req Req)
        {
            DataSet ds = new DataSet();
            string sp_Name = string.Empty;

            try
            {
                Saldo_Res Response = new Saldo_Res();

                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_Orden", Req.Id_Cve_Orden },
                    { "@pId_Cve_GUID", Req.Id_Cve_GUID },
                    { "@pId_Cve_TokenCta", Req.Id_Cve_TokenCta },
                    { "@pCve_Operacion", Req.Cve_Operacion },
                    { "@pImp_Vta", Req.Imp_Vta },
                    { "@pCant_Puntos", Req.Cant_Puntos },
                    { "@pImp_Comp", Req.Imp_Comp },
                    { "@pImp_DE", Req.Imp_DE },
                    { "@pImp_Efvo", Req.Imp_Efvo },
                    { "@pImp_Cred", Req.Imp_Cred }
                };

                if (Req.Cve_Accion == "DISMINUYE")                
                    sp_Name = "clSFDisminuyeSaldo_pUP";
                else if (Req.Cve_Accion == "AUMENTA")
                    sp_Name = "clSFAumentaSaldo_pUP";
               
                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, sp_Name, false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        Response.Cve_Autz = row["Cve_Autz"].ToString();
                        Response.Bit_Error = bool.Parse(row["Bit_Error"].ToString());
                        Response.Desc_Error = row["Desc_Error"].ToString();
                    }
                }

                return Response;
            }
            catch(Exception ex)
            {
                Saldo_Res Response = new Saldo_Res
                {
                    Cve_Autz = "000000",
                    Bit_Error = true,
                    Desc_Error = ex.Message
                };

                return Response;
            }
        }

        public Saldo_Res BL_SaldosOmonel(SaldosOmonel_Req req)
        {
            try
            {
                Saldo_Res Response = new Saldo_Res();
                DataSet ds = new DataSet();
                string sp_name = string.Empty;

                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_Orden", req.Id_Cve_Orden },
                    { "@pId_Cve_GUID", req.Id_Cve_GUID },
                    { "@pId_Num_Cta", req.Id_Num_Cta },
                    { "@pCve_Operacion", req.Cve_Operacion },
                    { "@pImp_Comp", req.Imp_Comp }
                };

                if ((req.Cve_Accion == "DISMINUYE") && (req.Cve_Operacion == "COMPRA"))
                {
                    parameters.Add("@pCve_Acceso", req.Cve_Acceso);
                    sp_name = "clSFDisminuyeSaldoOMONEL_pUP";                   
                }
                else if(req.Cve_Accion == "AUMENTA")
                {
                    sp_name = "clSFAumentaSaldoOMONEL_pUP";
                }

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, sp_name, false, parameters);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Response.Cve_Autz = row["Cve_Autz"].ToString();
                        Response.Bit_Error = bool.Parse(row["Bit_Error"].ToString());
                        Response.Desc_Error = row["Desc_Error"].ToString();
                    }
                }

                return Response;
            }
            catch(Exception ex)
            {
                Saldo_Res Response = new Saldo_Res
                {
                    Cve_Autz = "000000",
                    Bit_Error = true,
                    Desc_Error = ex.Message
                };

                return Response;
            }
        }

        public ConsultaOrdenResponseModel BL_ConsultaOrden(ConsultaOrdenRequestModel Req)
        {
            DataSet ds = new DataSet();
            ConsultaOrdenResponseModel orden = new ConsultaOrdenResponseModel();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_Orden", Req.Id_Cve_Orden },
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFConsultaOrdenCompDet_sUP", false, parameters);

                /*
                 Id_Cve_GUID                          Id_Cve_TokenCta                      Cant_Puntos Imp_Comp              Imp_DE                Imp_Efvo              Imp_Cred
                ------------------------------------ ------------------------------------ ----------- --------------------- --------------------- --------------------- ---------------------
                5fa4a8b3-0371-4c71-ac61-6d0f7a1933b2 2000100601997046                     0           58.40                 0.00                  

                 */

                foreach (DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        orden.Id_Cve_GUID = row["Id_Cve_GUID"].ToString();
                        orden.Id_Cve_TokenCta = row["Id_Cve_TokenCta"].ToString();
                        orden.Cant_Puntos = row["Cant_Puntos"].ToString();
                        orden.Imp_Comp = row["Imp_Comp"].ToString();
                        orden.Imp_DE = row["Imp_DE"].ToString();
                        orden.Imp_Efvo = row["Imp_Efvo"].ToString();
                        orden.Imp_Cred = row["Imp_Cred"].ToString();
                    }
                }
                return orden;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Conciliacion
        public ConciliacionModelResponse BL_Conciliacion(ConciliacionModelRequest Req)
        {
            try
            {
                ConciliacionModelResponse Response = new ConciliacionModelResponse();
                List<DetalleConciliacion> lstDetalleConc = new List<DetalleConciliacion>();

                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                List<FmkTools.paramModel> listL = new List<FmkTools.paramModel>();

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Fecx_Vta", Req.Id_Fecx_Vta },
                    { "@pId_Num_UN", int.Parse(Req.Id_Num_UN) },
                    { "@pId_Num_Cajero", int.Parse(Req.Id_Num_Cajero) },
                    { "@pId_Num_Caja", int.Parse(Req.Id_Num_Caja) },
                    { "@pId_Num_Ticket", int.Parse(Req.Id_Num_Ticket) },
                    { "@pId_Num_OrdenInet", int.Parse(Req.Id_Num_OrdenInet) },
                    { "@pImp_TotOrdenInet", decimal.Parse(Req.Imp_TotOrdenInet) }     
                };

                DataSet ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFTranCtePOSLiqOrdenInet_pUP", false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                   foreach(DataRow row in dt.Rows)
                    {
                        if (dt.TableName == "Table")
                        {
                            Response.Cve_CodResp = row["Cve_CodResp"].ToString();
                            Response.Desc_CodRespMsg = row["Desc_CodRespMsg"].ToString();

                        }
                        else if(dt.TableName == "Table1")
                        {
                            DetalleConciliacion detalle = new DetalleConciliacion();

                            detalle.Id_Num_FormaPago = row["Id_Num_FormaPago"].ToString();
                            detalle.Imp_FormaPago = row["Imp_FormaPago"].ToString();
                            detalle.Cve_FmtoVoucher = row["Cve_FmtoVoucher"].ToString();
                            detalle.Cve_Adquirente = row["Cve_Adquirente"].ToString();
                            detalle.Cve_Autz = row["Cve_Autz"].ToString();
                            detalle.Cve_Ref01 = row["Cve_Ref01"].ToString();
                            detalle.Cve_Ref02 = row["Cve_Ref02"].ToString();

                            lstDetalleConc.Add(detalle);
                        }

                        Response.lstDetalleConciliacion = lstDetalleConc;
                    }         
                }

                return Response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Complementarias                               
        public ValidacionTarjeta BL_ValidaTarjeta(string IdNumCte, string NoTarjeta)
        {
            ValidacionTarjeta Response = new ValidacionTarjeta();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);

                System.Collections.Hashtable parametersValidacion = new System.Collections.Hashtable
                {
                    { "@pId_Cve_CteInet", IdNumCte }, //= 353325
                    { "@pId_Num_Cta",  NoTarjeta } 

                };

                DataSet ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clSFValidaCtaTicket_sUP", false, parametersValidacion);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Response.Desc_Error = row["Desc_Error"].ToString();
                        Response.Codigo_Error = row["Cve_RespCode"].ToString();
                    }
                }

                return Response;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
 
 