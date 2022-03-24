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
    public class BL_Membresias
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ValidateMemberModelResponse BL_Vinculacion(ValidateMemberModelRequest validateMemberModelRequest)
        {
            DataSet ds = new DataSet();
            ValidateMemberModelResponse Response = new ValidateMemberModelResponse();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MembresiasConnectionString);
                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_CteInet", validateMemberModelRequest.clientId },
                    { "@pId_Num_CtaMemb", decimal.Parse(validateMemberModelRequest.membershipID) }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "cpSFVinculaCteInetMemb_pUP", false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        Response.cve_RespCode = row["Cve_RespCode"].ToString();
                        Response.desc_MensajeError = row["Desc_MensajeError"].ToString();
                        Response.membershipToken = row["Cve_TokenMemb"].ToString();
                    }
                }

                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Action 2
        public SFValidaMembResponse BL_ValidateSFMemb(SFValidaMembRequest sFValidaMembRequest)
        {
            DataSet ds = new DataSet();
            SFValidaMembResponse Response = new SFValidaMembResponse();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MembresiasConnectionString);
                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_CteInet", sFValidaMembRequest.Id_Cve_CteInet },
                    { "@pId_Num_CtaMemb", decimal.Parse(sFValidaMembRequest.Id_Num_CtaMemb) },
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "cpSFValidaMemb_sUP", false, parameters);


                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Response.Cve_RespCode = row["Cve_RespCode"].ToString();
                        Response.Desc_MensajeError = row["Desc_MensajeError"].ToString();
                        Response.Cve_TokenMemb = row["Cve_TokenMemb"].ToString();
                    }
                }

                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetMembershipModelResponse BL_GetMembership(ValidateMemberModelRequest validateMemberModelRequest)
        {
            DataSet ds = new DataSet();
            ValidateMembEstatusResponse estatusResponse = new ValidateMembEstatusResponse();
            GetMembershipModelResponse Membership = new GetMembershipModelResponse();
            MembershipAddress membershipAddress = new MembershipAddress();
            List<AdditionalMemberships> lstAdditional = new List<AdditionalMemberships>();
           
            List<Balance> lstBalances = new List<Balance>();
            LoyaltyBalance loyalty = new LoyaltyBalance();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MembresiasConnectionString);
                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_CteInet", validateMemberModelRequest.clientId },
                    { "@pId_Cve_TokenMemb",  validateMemberModelRequest.membershipID}
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "cpSFObtieneDetMemb_sUP", false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        if(dt.TableName == "Table")
                        {
                            Membership.cve_RespCode = row["Cve_RespCode"].ToString();
                            Membership.desc_MensajeError = row["Desc_MensajeError"].ToString();
                        }

                        if (dt.TableName == "Table1")
                        {
                            Membership.membershipID = row["Id_Num_CtaMemb"].ToString();
                            Membership.clientName = row["Nom_Cte"].ToString();
                            Membership.clientEmail = row["Email"].ToString();
                            Membership.membershipType = row["Cve_TipoMemb"].ToString();
                            Membership.membershipExpirationDate = row["FSV_Memb"].ToString();
                            membershipAddress.postalCode = row["Cve_CP"].ToString();
                            membershipAddress.state = row["Nom_Estado"].ToString();
                            membershipAddress.city = row["Nom_Ciudad"].ToString();
                            membershipAddress.streetName = row["Nom_Calle"].ToString();
                            membershipAddress.streetNumber = row["Num_Exterior"].ToString();
                            membershipAddress.buildingNumber = row["Num_Interior"].ToString();
                            membershipAddress.details = row["Cve_DetDomic"].ToString();
                            membershipAddress.colonia = row["Nom_Colonia"].ToString();
                        }
                        else if (dt.TableName == "Table2")
                        {
                            AdditionalMemberships additional = new AdditionalMemberships
                            {
                                clientName = row["Nom_Cte"].ToString(),
                                clientEmail = row["Email"].ToString(),
                                membershipID = row["Id_Cve_TokenMemb"].ToString(),
                                membershipType = row["Cve_TipoMemb"].ToString(),
                                membershipExpirationDate = row["FSV_Memb"].ToString()
                            };

                            lstAdditional.Add(additional);
                        }
                        else if (dt.TableName == "Table3")
                        {
                            loyalty.Cant_SdoPuntos = row["Cant_SdoPuntos"].ToString();
                            loyalty.Imp_SdoComp = row["Imp_SdoComp"].ToString();
                            loyalty.Imp_SdoDE = row["Imp_SdoDE"].ToString();
                            loyalty.Imp_SdoEfvo = row["Imp_SdoEfvo"].ToString();
                            loyalty.Imp_SdoCred = row["Imp_SdoCred"].ToString();
                        }                   
                    }
                }

                Membership.membershipAddress = membershipAddress;
                Membership.additionalMemberships = lstAdditional;

                #region Balances
                Balance Cash = new Balance
                {
                    accountType = "cash",
                    balance = loyalty.Imp_SdoEfvo
                };

                Balance electronic = new Balance
                {
                    accountType = "electronicmoney",
                    balance = loyalty.Imp_SdoDE
                };

                Balance points = new Balance
                {
                    accountType = "puntos",
                    balance = loyalty.Cant_SdoPuntos
                };

                lstBalances.Add(Cash);
                lstBalances.Add(electronic);
                lstBalances.Add(points);
                #endregion

                Membership.balances = lstBalances;

                return Membership;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Action 3
        public ValidateMembEstatusResponse BL_ValidaAltaRenovacion(ValidaAltaRenovacion validaAltaRenovacionRequest)
        {
            DataSet ds = new DataSet();
            ValidateMembEstatusResponse Response = new ValidateMembEstatusResponse();
            try
            {
                FmkTools.SqlHelper.connection_Name(context.MembresiasConnectionString);
                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_CteInet", validaAltaRenovacionRequest.Id_Cve_CteInet },
                    { "@pId_Cve_TipoMemb", validaAltaRenovacionRequest.Id_Cve_TipoMemb },
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "cpSFValidaAltaRenovacionMemb_sUP", false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        Response.Cve_RespCode = row["Cve_RespCode"].ToString();
                        Response.Desc_MensajeError = row["Desc_MensajeError"].ToString();
                    }
                }

                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GenerateMembershipModelResponseBase BL_GenerateMembership(GenerateMembershipModelRequest generateMembershipModelRequest)
        {
            DataSet ds = new DataSet();

            GenerateMembershipModelResponseBase generateMembershipModelResponseBase = new GenerateMembershipModelResponseBase();
            try
            {        
               
                FmkTools.SqlHelper.connection_Name(context.MembresiasConnectionString);
                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Cve_CteInet", generateMembershipModelRequest.clientId },
                    { "@pNom_Socio", generateMembershipModelRequest.clientName },
                    { "@pDesc_Email", generateMembershipModelRequest.clientEmail },
                    { "@pId_Cve_OrdenInet", generateMembershipModelRequest.orderId },                   
                    { "@pId_Cve_TipoMemb", generateMembershipModelRequest.memberships.membershipType },
                    { "@pCve_CP", generateMembershipModelRequest.memberships.membershipAddress.postalCode},
                    { "@pNom_Estado", generateMembershipModelRequest.memberships.membershipAddress.state},
                    { "@pNom_Ciudad", generateMembershipModelRequest.memberships.membershipAddress.city},
                    { "@pNom_Calle", generateMembershipModelRequest.memberships.membershipAddress.streetName},
                    { "@pNum_Exterior", generateMembershipModelRequest.memberships.membershipAddress.streetNumber},
                    { "@pNum_Interior", generateMembershipModelRequest.memberships.membershipAddress.buildingNumber},
                    { "@pCve_DetDomic", generateMembershipModelRequest.memberships.membershipAddress.details},
                    { "@pNom_Colonia", generateMembershipModelRequest.memberships.membershipAddress.colonia }
                };

                if (generateMembershipModelRequest.membershipID == "")
                {
                    parameters.Add("@pId_Num_CtaMemb", DBNull.Value);
                }
                else
                {
                    parameters.Add("@pId_Num_CtaMemb", generateMembershipModelRequest.membershipID);
                }

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "cpSFAltaRenovacionMemb_pUP", false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        if(dt.TableName == "Table")
                        {
                            generateMembershipModelResponseBase.cve_RespCode = row["Cve_RespCode"].ToString();
                            generateMembershipModelResponseBase.desc_MensajeError = row["Desc_MensajeError"].ToString();
                        }
                        if(dt.TableName == "Table1")
                        {
                            generateMembershipModelResponseBase.membershipType = row["Id_Cve_TipoMemb"].ToString();
                            generateMembershipModelResponseBase.membershipID = row["Id_Num_CtaMemb"].ToString();
                            generateMembershipModelResponseBase.membershipToken = row["Id_Cve_TokenMemb"].ToString();
                            generateMembershipModelResponseBase.membershipText = row["Desc_MembText"].ToString();
                        }
                    }
                }

                return generateMembershipModelResponseBase;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
    }
}