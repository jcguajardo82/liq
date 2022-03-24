using System;
using System.Web.Hosting;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Web;

using WebApplication4.Tools;
using WebApplication4.Models;
using WebApplication4.Controllers;
using WebApplication4.Providers;


namespace WebApplication4.BL_API_Soriana_APP
{
    public class BL_SADAM 
    {
        #region Variables Generales
        StringBuilder sb = new StringBuilder();
        StringBuilder errorMessages = new StringBuilder();
        string FechaActual = DateTime.Now.ToString("yyyy-MM-dd"); string FechaHoraActual = DateTime.Now.ToString("yyyy-MM-dd H-mm-ss");
        DateTime DT_FechaActual = DateTime.Today; DateTime DT_FechaError = DateTime.Today;
        string FechaError = "0";
        ProvidersContext context = new ProvidersContext();
        Log_CentralWebAPI logCentral = new Log_CentralWebAPI();
        //private DBHelper mainDBHelper;
        #endregion

        #region  Token
        public DataSet WM_SADAM_GuardarInfoNotifAnonimo(string tokenDispositivo, string nomCiudad)          //int idNumCte -- PENDIENTE
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                logCentral.LogWebAPi("MENSAJE DE REQUEST (WM_SADAM_GuardarInfoNotifAnonimo)");
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_DeviceToken", tokenDispositivo },
                    { "@Nom_Ciudad", nomCiudad }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_GuardarTokenDispositivo_iUp", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                errorMessages.Append("Index #" + 0 + "\n" + Environment.NewLine +
                    "Message: " + ExSql.Errors[0].Message + "\n" + Environment.NewLine +
                    "LineNumber: " + ExSql.Errors[0].LineNumber + "\n" + Environment.NewLine +
                    "Source: " + ExSql.Errors[0].Source + "\n" + Environment.NewLine +
                    "Procedure: " + ExSql.Errors[0].Procedure + "\n" + Environment.NewLine +
                    "Date&Time: " + FechaHoraActual + "\n" + Environment.NewLine +
                    "WebService: " + "WS_SADAM" + "\n" + Environment.NewLine +
                    "Method: " + "WM_SADAM_GuardarInfoNotifAnonimo");
                sb.AppendLine(errorMessages.ToString());
                sb.AppendLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
                FechaError = DateTime.Now.ToString("yyyy-MM-dd");

                return ds;
            }
        }

        public TokenModel WM_SADAM_GuardarRelacionUsuarioTokenDispositivo(string tokenDispositivo, int idNumCte)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            TokenModel TokenResult = new TokenModel();

            DataSet ds = new DataSet();

            try
            {
                logCentral.LogWebAPi("MENSAJE DE REQUEST (WM_SADAM_GuardarRelacionUsuarioTokenDispositivo)");
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_DeviceToken", tokenDispositivo },
                    { "@Id_Num_Cte", idNumCte }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_RelacionarUsuarioTokenDispositivo_sUp", false, parameters);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (dt.TableName == "Table") //ESTATUS
                        {
                            Estatus estatusToken = new Estatus();

                            estatusToken.numError = int.Parse(row["numError"].ToString());
                            estatusToken.descError = row["descError"].ToString();
                            estatusToken.descErrorCte = row["descErrorCte"].ToString();

                            TokenResult.Estatus = estatusToken;
                        }
                        else if (dt.TableName == "Table1")
                        {
                            Control controlToken = new Control();

                            controlToken.idNumCte = int.Parse(row["idNumCte"].ToString());
                            controlToken.tokenDispositivo = row["tokenDispositivo"].ToString();

                            TokenResult.Control = controlToken;
                        }
                    }
                }
                return TokenResult;
            }
            catch (SqlException ExSql)
            {
                errorMessages.Append("Index #" + 0 + "\n" + Environment.NewLine +
                    "Message: " + ExSql.Errors[0].Message + "\n" + Environment.NewLine +
                    "LineNumber: " + ExSql.Errors[0].LineNumber + "\n" + Environment.NewLine +
                    "Source: " + ExSql.Errors[0].Source + "\n" + Environment.NewLine +
                    "Procedure: " + ExSql.Errors[0].Procedure + "\n" + Environment.NewLine +
                    "Date&Time: " + FechaHoraActual + "\n" + Environment.NewLine +
                    "WebService: " + "WS_SADAM" + "\n" + Environment.NewLine +
                    "Method: " + "WM_SADAM_GuardarRelacionUsuarioTokenDispositivo");
                sb.AppendLine(errorMessages.ToString());
                sb.AppendLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
                FechaError = DateTime.Now.ToString("yyyy-MM-dd");

                return TokenResult;
            }
        }

        public Class_Login WM_SADAM_ValidarCliente(string correo, string clave, int ClienteId)              // string tokenDispositivo
        {
            Class_Login Result = new Class_Login();
            //InfoClienteModel obj_ClienteModel = new InfoClienteModel();          
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();
            int idNumCte = 0; int idTipoConsulta = 2; int idNumVisita = 0;

            try
            {
                logCentral.LogWebAPi("MENSAJE DE REQUEST (ObtenerInfoCliente) " + " CORREO " +  correo + " PASS " + clave + " Formato " + ClienteId.ToString());

                if (ClienteId != 5)                                                                      // SORIANA
                    FmkTools.SqlHelper.connection_Name(context.MainConnectionString);
                else if(ClienteId == 5)
                    FmkTools.SqlHelper.connection_Name(context.CityClubConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@NumTipoConsulta ", idTipoConsulta },                                            //int idTipoConsulta = 2;
                    { "@Id_Num_Cte", idNumCte },                                                        //int idNumCte = 0;
                    { "@EmailCte", correo },
                    { "@ClaveCte", clave },
                    { "@Id_Num_Visita", idNumVisita }                                                   //int idNumVisita = 0;
                };

                //DATOS DEL PRIMER MODELO SORIANA SUPER
                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_Login_sUp", false, parameters);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        if (dt.TableName == "Table") //ESTATUS
                        {
                            Result.numError = int.Parse(row["numError"].ToString());
                            Result.descError = row["descError"].ToString();
                            Result.descErrorCte = row["descErrorCte"].ToString();
                        }
                        else if (dt.TableName == "Table1")
                        {
                            Datos_Cliente datosCte = new Datos_Cliente();
                            datosCte.Id_Num_Cte = row["Id_Num_Cte"].ToString();
                            datosCte.Nom_Cte = row["Nom_Cte"].ToString();
                            datosCte.Ap_Paterno = row["Ap_Paterno"].ToString();
                            datosCte.Ap_Materno = row["Ap_Materno"].ToString();
                            datosCte.Pregunta = row["Pregunta"].ToString();
                            datosCte.Cve_Respuesta = row["Cve_Respuesta"].ToString();
                            datosCte.Fec_Movto = row["Fec_Movto"].ToString();
                            datosCte.Cve_IdCte = row["Cve_IdCte"].ToString();

                            Result.Cliente = datosCte;
                        }
                    }
                }
                return Result;               
            }
            catch (SqlException ExSql)
            {
                errorMessages.Append("Index #" + 0 + "\n" + Environment.NewLine +
                    "Message: " + ExSql.Errors[0].Message + "\n" + Environment.NewLine +
                    "LineNumber: " + ExSql.Errors[0].LineNumber + "\n" + Environment.NewLine +
                    "Source: " + ExSql.Errors[0].Source + "\n" + Environment.NewLine +
                    "Procedure: " + ExSql.Errors[0].Procedure + "\n" + Environment.NewLine +
                    "Date&Time: " + FechaHoraActual + "\n" + Environment.NewLine +
                    "WebService: " + "WS_SADAM" + "\n" + Environment.NewLine +
                    "Method: " + "WM_SADAM_ValidarCliente");
                sb.AppendLine(errorMessages.ToString());
                sb.AppendLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
                FechaError = DateTime.Now.ToString("yyyy-MM-dd");

                return Result;
            }
        }

        public DataSet WM_SADAM_GuardarClientIDRefreshToken(int idNumCte, string ClientID, string RefreshToken, string FechaInicial, string FechaFinal, string json)
        {
            //InfoClienteModel obj_ClienteModel = new InfoClienteModel();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                logCentral.LogWebAPi( "MENSAJE DE REQUEST (ObtenerInfoCliente)");

                //if (ClienteId != 5)                                                                      // SORIANA
                //    FmkTools.SqlHelper.connection_Name(context.MainConnectionString);
                //else if (ClienteId == 5)
                //    FmkTools.SqlHelper.connection_Name(context.CityClubConnectionString);
                //else
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_Num_Cte", idNumCte },
                    { "@Desc_SOMovil", ClientID },
                    { "@RefreshToken", RefreshToken },
                    { "@FEV", FechaInicial },
                    { "@FSV", FechaFinal },
                    { "@json", json }
                };

                //DATOS DEL PRIMER MODELO SORIANA SUPER
                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_GuardarClientIDRefreshToken_iUp_v02", false, parameters);       //SADAM_GuardarClientIDRefreshToken_iUp

                return ds;
            }
            catch (SqlException ExSql)
            {
                errorMessages.Append("Index #" + 0 + "\n" + Environment.NewLine +
                    "Message: " + ExSql.Errors[0].Message + "\n" + Environment.NewLine +
                    "LineNumber: " + ExSql.Errors[0].LineNumber + "\n" + Environment.NewLine +
                    "Source: " + ExSql.Errors[0].Source + "\n" + Environment.NewLine +
                    "Procedure: " + ExSql.Errors[0].Procedure + "\n" + Environment.NewLine +
                    "Date&Time: " + FechaHoraActual + "\n" + Environment.NewLine +
                    "WebService: " + "WS_SADAM" + "\n" + Environment.NewLine +
                    "Method: " + "WM_SADAM_GuardarClientIDRefreshToken");
                sb.AppendLine(errorMessages.ToString());
                sb.AppendLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
                FechaError = DateTime.Now.ToString("yyyy-MM-dd");
                
                return ds;
            }
        }

        public Token_Refresh WM_SADAM_ValidarRefreshToken(string RefreshToken) //int idNumCte, string ClientID, 
        {
            Token_Refresh refresh = new Token_Refresh();
            //InfoClienteModel obj_ClienteModel = new InfoClienteModel();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                logCentral.LogWebAPi("MENSAJE DE REQUEST (ObtenerInfoCliente)");
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@RefreshToken", RefreshToken }
                };

                //DATOS DEL PRIMER MODELO SORIANA SUPER
                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ValidarRefreshToken_sUP_v02", false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        if (dt.TableName == "Table") //ESTATUS
                        {
                            refresh.numError = int.Parse(row["numError"].ToString());
                            refresh.descError = row["descError"].ToString();
                        }
                        else if (dt.TableName == "Table1")
                        {
                            refresh.Refresh_Token.Id_Num_Cte = row["Id_Num_Cte"].ToString();
                            refresh.Refresh_Token.Desc_SOMovil = row["Desc_SOMovil"].ToString();
                            refresh.Refresh_Token.RefreshToken = row["RefreshToken"].ToString();
                            refresh.Refresh_Token.FEV = row["FEV"].ToString();
                            refresh.Refresh_Token.FSV = row["FSV"].ToString();
                            refresh.Refresh_Token.Json = row["Json"].ToString();
                        }
                    }
                }

                return refresh;
            }
            catch (SqlException ExSql)
            {
                errorMessages.Append("Index #" + 0 + "\n" + Environment.NewLine +
                    "Message: " + ExSql.Errors[0].Message + "\n" + Environment.NewLine +
                    "LineNumber: " + ExSql.Errors[0].LineNumber + "\n" + Environment.NewLine +
                    "Source: " + ExSql.Errors[0].Source + "\n" + Environment.NewLine +
                    "Procedure: " + ExSql.Errors[0].Procedure + "\n" + Environment.NewLine +
                    "Date&Time: " + FechaHoraActual + "\n" + Environment.NewLine +
                    "WebService: " + "WS_SADAM" + "\n" + Environment.NewLine +
                    "Method: " + "WM_SADAM_ValidarRefreshToken");
                sb.AppendLine(errorMessages.ToString());
                sb.AppendLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
                FechaError = DateTime.Now.ToString("yyyy-MM-dd");

                return refresh;
            }
        }
        #endregion

        #region Cliente
       

        public List<LoyaltyAccountViewModel> GetUserAccount(string IdNumCte)
        {
            try
            {
                List<LoyaltyAccountViewModel> LstCuentas = new List<LoyaltyAccountViewModel>();

                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                List<FmkTools.paramModel> listL = new List<FmkTools.paramModel>();

                FmkTools.paramModel l = new FmkTools.paramModel { name = "pId_Num_CteInet", value = IdNumCte, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                listL.Add(l);

                DataSet dsLealtad = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clASConsultaCte_sUP", false, listL);

                if (FmkTools.DatosDB.IsNullOrEmptyDataSet(dsLealtad) && FmkTools.DatosDB.IsNullOrEmptyDatatable(dsLealtad.Tables[0]))
                {
                    //c.Saldos = new BalanceAccountModel();
                    //u.Cuentas.Add(c);
                }
                else
                {
                    foreach (DataRow row in dsLealtad.Tables[0].Rows)
                    {
                        LoyaltyAccountViewModel c = new LoyaltyAccountViewModel();

                        c.AccountMask = FmkTools.Converters.CheckNullOrEmpty(row["Cve_MascaraCta"]) ? "0" : row["Cve_MascaraCta"].ToString();
                        c.AccountToken = FmkTools.Converters.CheckNullOrEmpty(row["Id_Cve_TokenCta"]) ? "0" : row["Id_Cve_TokenCta"].ToString();
                        c.UserId = IdNumCte;
                        c.Saldos = new BalanceAccountModel();
                        c.Saldos.SaldoPuntos = FmkTools.Converters.CheckNullOrEmpty(row["Cant_SdoPuntos"]) ? "0" : row["Cant_SdoPuntos"].ToString();
                        c.Saldos.SaldoDineroElectronico = FmkTools.Converters.CheckNullOrEmpty(row["Imp_SdoDE"]) ? "0.0" : row["Imp_SdoDE"].ToString();
                        c.Saldos.SaldoEfectivo = FmkTools.Converters.CheckNullOrEmpty(row["Imp_SdoEfvo"]) ? "0.0" : row["Imp_SdoEfvo"].ToString();
                        c.Saldos.Saldo = FmkTools.Converters.CheckNullOrEmpty(row["Imp_SdoComp"]) ? "0.0" : row["Imp_SdoComp"].ToString();

                        LstCuentas.Add(c);    
                    }                   
                }

                return LstCuentas;
            }
            catch (Exception ex)
            {
                //FmkTools.Log.WriteToLogFile(logFilePath, "Exception ValidateLogin");
                //FmkTools.Log.WriteToLogFile(logFilePath, "Datos Entrada - User: " + hsid);
                //FmkTools.Log.WriteToLogFile(logFilePath, "Message : " + ex.Message);
                throw ex;
            }
        }

        public List<DatosFiscalesModels> GetUserFiscal(string IdNumCte)
        {
            try
            {
                List<DatosFiscalesModels> lstDatosFisc = new List<DatosFiscalesModels>();
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);         
                List<FmkTools.paramModel> listL = new List<FmkTools.paramModel>();

                FmkTools.paramModel l = new FmkTools.paramModel { name = "pId_Num_CteInet", value = IdNumCte, direction = ParameterDirection.Input, typeParm = typeof(Int32) };
                listL.Add(l);

                DataSet dsfiscales = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "fft_ASConsultaCteRFC_sUP ", false, listL);

                if (FmkTools.DatosDB.IsNullOrEmptyDataSet(dsfiscales) && FmkTools.DatosDB.IsNullOrEmptyDatatable(dsfiscales.Tables[0]))
                {
                     DatosFiscalesModels d = new DatosFiscalesModels();

                    // u.DatosFiscales.Add(d);
                }
                else
                {
                     foreach (DataRow rf in dsfiscales.Tables[0].Rows)
                     {
                         DatosFiscalesModels d = new DatosFiscalesModels();

                         d.Id_Cnsc_CteRfc = rf["Id_Cnsc_CteRfc"].ToString();
                         d.Id_Cve_RFC = rf["Id_Cve_RFC"].ToString();
                         d.RazonSocial = rf["RazonSocial"].ToString();
                         d.Id_Num_CP = rf["Id_Num_CP"].ToString();
                         d.Id_Cve_TipoUsoCFDI = rf["Id_Cve_TipoUsoCFDI"].ToString();

                        lstDatosFisc.Add(d);  
                     }
                 }

                return lstDatosFisc; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     

    

        public DataSet WM_SADAM_ObtenerTiposCliente()
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ObtenerTiposCliente_sUp", false);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (WM_SADAM_ObtenerTiposCliente) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet WM_SADAM_ValidarDatosPersCte(string Correo, string numTarjeta)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_Email", Correo },
                    { "@Num_Tarjeta", numTarjeta }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ValidarDatosPersCte_sUp", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (WM_SADAM_ValidarDatosPersCte) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet WM_SADAM_CambiarClaveCliente(int idNumCte, string claveActual, string claveNueva, string confClaveNueva)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_Num_Cte", idNumCte },
                    { "@CveActual", claveActual },
                    { "@CveNueva", claveNueva },
                    { "@ConfCveNueva", confClaveNueva }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_CambiarClaveCliente_uUp", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (WM_SADAM_CambiarClaveCliente) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet WM_SADAM_ActualizarPropiedadesCliente(int idNumCte, int aplClientID, int idNumVisita, int? idCnscDirCte, int? idTienda)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@id_Num_Cte", idNumCte },
                    { "@ID_Num_Apl", aplClientID },
                    { "@ID_Num_Visita", idNumVisita },
                    { "@Id_Cnsc_DirCte", idCnscDirCte },
                    { "@Id_Num_Un", idTienda }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ActualizarPropiedadesCliente_uUp", false);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (SADAM_ActualizarPropiedadesCliente_uUp) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet WM_SADAM_RecuperarContrasena(string correoCte)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {  
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_Email", correoCte }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_RecuperarClave_sUp", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (SADAM_RecuperarClave_sUp) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet WM_SADAM_ActualizarDatosEnTienda(int idNumCte, int tipoCliente, string telOficina, string extOficina)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_Num_Cte", idNumCte },
                    { "@TipoUs", tipoCliente },
                    { "@TelOficina", telOficina },
                    { "@ExtOficina", extOficina }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ActualizarDatosEnTienda_uUp", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (SADAM_ActualizarDatosEnTienda_uUp) " + ExSql.Message);

                return ds;
            }
        }

        public ClienteLealtad_Res BL_ProgramaLealtad(int idNumCte, string TarjetaLealtad, string TelCelular)
        {
            string strStored = string.Empty;

            try
            {
                DataSet ds = new DataSet();
                DataSet dsLealtad = new DataSet();
                DataSet dsCel = new DataSet();
                ClienteLealtad_Model clienteLealtadReq = new ClienteLealtad_Model();
                ClienteLealtad_Res ResponseClienteLealtad = new ClienteLealtad_Res();
                int ErrordNet = 0;
               
                #region Validacion Cliente x Telefono Celular
                strStored = "clASValidaCteCuestCta_sUP";
                FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Num_Cta", TarjetaLealtad },
                    { "@pNum_TelCel", TelCelular }
                };

                dsCel = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clASValidaCteCuestCta_sUP", false, parameters);
                #endregion

                if (!Convert.ToBoolean(dsCel.Tables[0].Rows[0][0].ToString()))
                {
                    #region dNet_eCliente_sUP
                    strStored = "dNet_eCliente_sUP";
                    FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                    System.Collections.Hashtable parametersValidacion = new System.Collections.Hashtable
                    {
                        { "@NumTipoConsulta", 1 },
                        { "@id_num_cte", idNumCte }
                    };

                    ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "dNet_eCliente_sUP", false, parametersValidacion);

                    foreach (DataTable dt in ds.Tables)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (dt.TableName == "Table")
                            {
                                ErrordNet = int.Parse(row["Error"].ToString());
                            }
                            else if (dt.TableName == "Table1")
                            {
                                clienteLealtadReq.Nom_Cte = row["Nom_Cte"].ToString();
                                clienteLealtadReq.Ap_Paterno = row["Ap_Paterno"].ToString();
                                clienteLealtadReq.Ap_Materno = row["Ap_Materno"].ToString();
                                clienteLealtadReq.Id_Email = row["Id_Email"].ToString();
                            }
                        }
                    }
                    #endregion

                    #region clASAltaCtaAprecio_iuUP
                    if (ErrordNet == 0)
                    {
                        strStored = "clASAltaCtaAprecio_iuUP";
                        FmkTools.SqlHelper.connection_Name(context.AccountLealtadConnectionString);
                        System.Collections.Hashtable parametersAlta = new System.Collections.Hashtable
                        {
                            { "@pId_Num_CteInet", idNumCte },
                            { "@pId_Num_Cta", TarjetaLealtad },
                            { "@pNom_Cte", clienteLealtadReq.Nom_Cte },
                            { "@pApPaterno",  clienteLealtadReq.Ap_Paterno },
                            { "@pApMaterno" , clienteLealtadReq.Ap_Materno },
                            { "@pDesc_CorreoE", clienteLealtadReq.Id_Email }
                        };

                        dsLealtad = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "clASAltaCtaAprecio_iuUP", false, parametersAlta);

                        foreach (DataTable dt in dsLealtad.Tables)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                ResponseClienteLealtad.Bit_Error = bool.Parse(row["Bit_Error"].ToString());
                                ResponseClienteLealtad.Desc_Error = row["Desc_Error"].ToString();
                                ResponseClienteLealtad.Id_Cve_TokenCta = row["Id_Cve_TokenCta"].ToString();
                                ResponseClienteLealtad.Cve_MascaraCta = row["Cve_MascaraCta"].ToString();
                            }
                        }

                        #region Actualiza Tarjeta
                        var resultadoActTarjet = ActualizaTarjetaIdentificacion(idNumCte, 1, TarjetaLealtad);
                        #endregion
                    }
                    else
                    {
                        ResponseClienteLealtad.Bit_Error = true;
                        ResponseClienteLealtad.Desc_Error = "CENTRALWEBAPI - Error al Autenticar Cliente";
                        ResponseClienteLealtad.Id_Cve_TokenCta = "";
                        ResponseClienteLealtad.Cve_MascaraCta = "";
                    }
                    #endregion
                }
                else
                {
                    ResponseClienteLealtad.Bit_Error = true;
                    ResponseClienteLealtad.Desc_Error = dsCel.Tables[0].Rows[0][1].ToString(); 
                    ResponseClienteLealtad.Id_Cve_TokenCta = "";
                    ResponseClienteLealtad.Cve_MascaraCta = "";
                }

                return ResponseClienteLealtad;
            }
            catch (Exception ex)
            {
                logCentral.LogWebAPi("BL_ProgramaLealtad ERROR: SP " + strStored + " - "  + ex.Message);

                throw ex;
            }
        }
        #endregion

        #region Terminos y Condiciones
        public string BL_ObtenerTerminosCondiciones()
        {
            DataSet ds = new DataSet();

            try
            {
                string path = HttpContext.Current.Server.MapPath("/CentralWebAPI/TerminosCondiciones/TerminosycondicionesSorianaApp.md");               
                string Teminos_txt = System.IO.File.ReadAllText(path);

                return Teminos_txt;
            }
            catch(Exception ExSql)
            {
                logCentral.LogWebAPi("ERROR (BL_ObtenerTerminosCondiciones) " + ExSql.Message);

                return "";
            }
        }

        public TerminosEstatus_Res BL_AceptarTerminosCondiciones(int Id_Num_Cte)
        {
            DataSet ds = new DataSet();
            TerminosEstatus_Res result = new TerminosEstatus_Res();
            try
            {              
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Num_Cte ", Id_Num_Cte }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "[Cte_AceptaTermCond_d_iUP]", false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        result.Bit_Error = bool.Parse(row["Bit_Error"].ToString());
                        result.Desc_Error = row["Desc_Error"].ToString();
                    }
                }
                return result;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (Cte_AceptaTermCond_d_iUP) " + ExSql.Message);

                return result;
            }
        }
        #endregion

        #region Visita
        public DataSet WM_SADAM_CrearVisita(int idNumCte, int? idCarrito)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();
            DataSet dsMail = new DataSet();
            string SessionID = "SADAM"; string Num_DirIp = ""; string Nom_Browser = ""; string Nom_BrowserVer = ""; string Nom_PagOrig = "";

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                if (idCarrito == null)
                    idCarrito = 0;

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_Num_Cte", idNumCte },
                    { "@SessionID", SessionID },
                    { "@Num_DirIp", Num_DirIp },
                    { "@Nom_Browser", Nom_Browser },
                    { "@Nom_BrowserVer", Nom_BrowserVer },
                    { "@Nom_PagOrig", Nom_PagOrig },
                    { "@Id_Num_Car", idCarrito }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_CrearVisita_sUp", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (WM_SADAM_CrearVisita) " + ExSql.Message);

                return ds;
            }
        }

        public VisitaUpd_Res WM_SADAM_ActualizarVisita(int idNumVisita, int idNumCte)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            VisitaUpd_Res Resultado = new VisitaUpd_Res();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_Num_Visita", idNumVisita },
                    { "@Id_Num_Cte", idNumCte }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ActualizarVisita_sUp", false, parameters);
                                                                                  
                foreach (DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        if (dt.TableName == "Table") //ESTATUS
                        {
                            Resultado.numError = int.Parse(row["numError"].ToString());
                            Resultado.descError = row["descError"].ToString();
                            Resultado.descErrorCte = row["descErrorCte"].ToString();
                        }
                        else if(dt.TableName == "Table1")
                        {
                            Resultado.idNumVisita = row["idNumVisita"].ToString();
                        }
                    }
                }

                return Resultado;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (WM_SADAM_ActualizarVisita) " + ExSql.Message);

                return Resultado;
            }
        }
        #endregion

        #region Direccion Cliente
        public DataSet WM_SADAM_ValidarCodigoPostal(string codigoPostal)
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@codigoPostal", codigoPostal }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ValidarCodigoPostal_sUp", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (WM_SADAM_ValidarCodigoPostal) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet WM_SADAM_ActualizarDirCliente(int idNumCte, int idTienda, int? idCnscDirCte, string nomDirCte,
        int? idTipoDomCte, string nomRecibeCte, int? idEstadoCte, string nomCiudadCte, string nomColoniaCte, string nomCalleCte, string numExtCalleCte,
        string numIntCalleCte, string CPCte, string telefonoCte, string Latitud, string Longitud) // string nomCteOtraPersDir_Opc string nomCte
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();
            int idNumDirTipo = 1;

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@id_Num_Cte", idNumCte },
                    { "@Id_Num_Un", idTienda },
                    { "@id_Cnsc_Dir", idCnscDirCte },
                    { "@Nom_Dir", nomDirCte },
                    { "@Id_Num_TipoCte", idTipoDomCte },
                    { "@NombreRecibe", nomRecibeCte },
                    { "@Ids_Num_Edo", idEstadoCte },
                    { "@Ciudad", nomCiudadCte },
                    { "@Colonia", nomColoniaCte },
                    { "@Calle", nomCalleCte },
                    { "@Num_Ext", numExtCalleCte },
                    { "@Num_Int", numIntCalleCte },
                    { "@CodigoP", CPCte },
                    { "@Tel", telefonoCte },
                    { "@Id_Num_DirTipo", idNumDirTipo }, //int idNumDirTipo = 1;
                    { "@Latitud" , Latitud },
                    { "@Longitud", Longitud }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ActualizarDirCliente_uUp", false, parameters);

                #region Parametros comentados
                //parameters.Add("@Nombre", nomCte); PENDIENTE QUITARLO DEL SP
                //cmd.Parameters.AddWithValue("@NombreOtraPersona", nomCteOtraPersDir_Opc);
                //cmd.Parameters.AddWithValue("@Id_Num_UN", Id_Num_UN);
                //cmd.Parameters.AddWithValue("@TelCasa", Tel_Casa);
                //cmd.Parameters.AddWithValue("@TelCelular", Tel_Celular);
                //cmd.Parameters.AddWithValue("@TelOficina", Tel_Oficina);
                //cmd.Parameters.AddWithValue("@ExtOficina", Ext_Oficina);  
                #endregion

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (SADAM_ActualizarDirCliente_uUp) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet WM_SADAM_ObtenerDireccionCliente(int idNumCte, int? idCnscDirCte) // int? idCnscDirCte
        {
            ProvidersContext context = new ProvidersContext();
            //List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@id_Num_Cte", idNumCte },
                    { "@Id_Cnsc_DirCte", idCnscDirCte }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_ObtenerDirCliente_sUp", false, parameters);
              
                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (SADAM_ObtenerDirCliente_sUp) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet WM_SADAM_BorrarDireccionCliente(int idNumCte, int idCnscDirCte)
        {
            ProvidersContext context = new ProvidersContext();
            List<InfoDireccionClienteModel> lstDireccionModel = new List<InfoDireccionClienteModel>();
            DataSet ds = new DataSet();

            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@id_Num_Cte", idNumCte },
                    { "@Id_Cnsc_DirCte", idCnscDirCte }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "SADAM_BorrarDireccionCliente_dUp", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (SADAM_BorrarDireccionCliente_dUp) " + ExSql.Message);

                return ds;
            }
        }

        public DataSet BL_ObtenerDetallePoblaciones(string Id_Num_CP)
        {
            DataSet ds = new DataSet();
            try
            {
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@Id_Num_Colonia", 0 },
                    { "@Id_Num_CP", Id_Num_CP },

                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "fft_Colonia_Sup", false, parameters);

                return ds;
            }
            catch (SqlException ExSql)
            {
                logCentral.LogWebAPi("ERROR (fft_Colonia_Sup) " + ExSql.Message);

                return ds;
            }
        }
        #endregion

        #region Funciones
        public ActTarjeta_Res ActualizaTarjetaIdentificacion(int Id_Num_Cte, int Id_Num_IdCteTipo, string Cve_IdCte)
        {
            try
            {
                ActTarjeta_Res result = new ActTarjeta_Res();
                DataSet ds = new DataSet();
                FmkTools.SqlHelper.connection_Name(context.MainConnectionString);

                System.Collections.Hashtable parameters = new System.Collections.Hashtable
                {
                    { "@pId_Num_Cte", Id_Num_Cte },
                    { "@pId_Num_IdCteTipo", Id_Num_IdCteTipo },
                    { "@pCve_IdCte", Cve_IdCte }
                };

                ds = FmkTools.SqlHelper.ExecuteDataSet(CommandType.StoredProcedure, "IdCte_iuP", false, parameters);

                foreach(DataTable dt in ds.Tables)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        result.Error = int.Parse(row["Error"].ToString());
                        result.DescError = row["DescError"].ToString();
                    }
                }

                return result;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}


