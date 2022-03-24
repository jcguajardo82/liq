using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class IdentityResult : Microsoft.AspNet.Identity.IdentityResult
    {
        private static IdentityResult _Success = new IdentityResult(true);

        private static IdentityResult _RegisterEmailPasswordError = new IdentityResult("Al registrar, el email y/o clave de acceso no son correctos");

        private static IdentityResult _LoyaltyAccountAndTicketError = new IdentityResult("La cuenta de recompensas no corresponde al ticket");

        private static IdentityResult _EmailPasswordError = new IdentityResult("El email y/o clave de acceso no son correctos");

        private static IdentityResult _SessionError = new IdentityResult("La clave de la sesión no corresponde al cliente");

        public IdentityResult(string error) : base(error) { }

        public IdentityResult(bool success) : base(success) { }

        public static IdentityResult EmailPasswordError
        {
            get
            {
                return _EmailPasswordError;
            }
        }

        public static IdentityResult SessionError
        {
            get
            {
                return _SessionError;
            }
        }

        public static IdentityResult LoyaltyAccountAndTicketError
        { get
            {
                return _LoyaltyAccountAndTicketError;
            }
        }

        public static IdentityResult RegisterEmailPasswordError 
        {
            get
            {

                return _RegisterEmailPasswordError;

            }
        }

        public static new IdentityResult Success
        {
            get
            {
                return _Success;
            }
        }

        public static IdentityResult ChangePasswordError
        {
            get
            {
                return _SessionError;
            }
        }

        public static IdentityResult InvoiceError
        {
            get
            {
                return _SessionError;
            }
        }

    }
}