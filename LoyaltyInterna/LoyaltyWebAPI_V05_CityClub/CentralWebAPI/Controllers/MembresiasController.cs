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
    [RoutePrefix("api/Membresia")]
    public class MembresiasController : ApiController
    {
        BL_Membresias Membresias_BL = new BL_Membresias();

        [Route("TestConnection")]
        [HttpPost]
        public HttpResponseMessage TestConnection()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var testConn = Membresias_BL.BL_TestConn();
                response = Request.CreateResponse(HttpStatusCode.OK, testConn);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("Vinculacion")]
        [HttpPost]
        public HttpResponseMessage Vinculacion(ValidateMemberModelRequest validateMemberModelRequest)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var MembresiaValidate = Membresias_BL.BL_Vinculacion(validateMemberModelRequest);
                response = Request.CreateResponse(HttpStatusCode.OK, MembresiaValidate);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("ValidateSFMemebresia")]
        [HttpPost]
        public HttpResponseMessage ValidateSFMemb(SFValidaMembRequest validateMemberModelRequest)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var MembresiaValidate = Membresias_BL.BL_ValidateSFMemb(validateMemberModelRequest);
                response = Request.CreateResponse(HttpStatusCode.OK, MembresiaValidate);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("GetMembership")]
        [HttpPost]
        public HttpResponseMessage GetMembership(ValidateMemberModelRequest validateMemberModelRequest)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var MembresiaGet = Membresias_BL.BL_GetMembership(validateMemberModelRequest);
                response = Request.CreateResponse(HttpStatusCode.OK, MembresiaGet);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }


        [Route("ValidateAtaRenovacion")]
        [HttpPost]
        public HttpResponseMessage ValidateAtaRenovacion(ValidaAltaRenovacion validateMemberModelRequest)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var MembresiaValidate = Membresias_BL.BL_ValidaAltaRenovacion(validateMemberModelRequest);
                response = Request.CreateResponse(HttpStatusCode.OK, MembresiaValidate);

                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [Route("GenerateMembership")]
        [HttpPost]
        public HttpResponseMessage GetMembership(GenerateMembershipModelRequest generateMembershipModelRequest)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var Membership = Membresias_BL.BL_GenerateMembership(generateMembershipModelRequest);
                response = Request.CreateResponse(HttpStatusCode.OK, Membership);

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