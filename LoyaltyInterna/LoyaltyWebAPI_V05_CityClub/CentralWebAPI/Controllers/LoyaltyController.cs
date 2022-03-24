using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

using WebApplication4.BL;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [RoutePrefix("api/Loyalty")]
    public class LoyaltyController : ApiController
    {
        BL_Loyalty Loyalty = new BL_Loyalty();

        [Route("TestConnection")]
        [HttpPost]
        public HttpResponseMessage TestConnection()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var BL_Response = Loyalty.BL_TestConn();
                response = Request.CreateResponse(HttpStatusCode.OK, BL_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("LinkCard")]
        [HttpPost]
        public HttpResponseMessage LinkCard(LinkCard_Req Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var BL_Response = Loyalty.BL_LinkCard(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, BL_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("LinkVirtualCard")]
        [HttpPost]
        public HttpResponseMessage LinkVirtualCard(LinkCard_Req Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var BL_Response = Loyalty.BL_LinkVirtualCard(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, BL_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("CardReplacement")]
        [HttpPost]
        public HttpResponseMessage CardReplacement(ReplaceCard_Req Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var BL_Response = Loyalty.BL_CardReplacement(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, BL_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("Balances")]
        [HttpPost]
        public HttpResponseMessage Balances(LoyaltyReq_Base Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var BL_Response = Loyalty.BL_Balances(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, BL_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("ReversoBalance")] 
        [HttpPost]
        public HttpResponseMessage ReversoBalance(LoyaltyReq_Base Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var BL_Response = Loyalty.BL_Balances(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, BL_Response);

                return response;
            }
            catch(Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("RedemptionBalances")]
        [HttpPost]
        public HttpResponseMessage RedemptionBalances(RedencionSaldoRequest_Model Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var BL_Response = Loyalty.BL_RedemptionBalances(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, BL_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("ReplacementByTicket")]
        [HttpPost]
        public HttpResponseMessage ReplacementByTicket(ReplaceCard_Req Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var BL_Response = Loyalty.BL_ReplacementByTicket(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, BL_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("ProcesadorPagosSaldo")]
        [HttpPost]
        public HttpResponseMessage ProcesadorPagosSaldo(Saldo_Req Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var Bl_Response = Loyalty.BL_ProcesadorPagos(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, Bl_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("SaldosOmonel")]
        [HttpPost]
        public HttpResponseMessage SaldosOmonel(SaldosOmonel_Req Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var Bl_Response = Loyalty.BL_SaldosOmonel(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, Bl_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("ConsultaOrden")]
        [HttpPost]
        public HttpResponseMessage ConsultaOrden(ConsultaOrdenRequestModel Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var Bl_Response = Loyalty.BL_ConsultaOrden(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, Bl_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("Conciliacion")]
        [HttpPost]
        public HttpResponseMessage Conciliacion(ConciliacionModelRequest Req)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var Bl_Response = Loyalty.BL_Conciliacion(Req);
                response = Request.CreateResponse(HttpStatusCode.OK, Bl_Response);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }
    }
}