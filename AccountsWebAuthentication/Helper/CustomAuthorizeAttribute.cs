using AccountsFunction;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountsWebAuthentication.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private bool AllowAnonymous;
        private string RedirectController;
        private string RedirectMethod;

        public CustomAuthorizeAttribute(bool allowAnonymous)
        {
            AllowAnonymous = allowAnonymous;
            RedirectController = string.Empty;
            RedirectMethod = string.Empty;
            AllowedRoles = new string[0];
        }

        public CustomAuthorizeAttribute(bool allowAnonymous, string[] allowedRoles)
        {
            AllowAnonymous = allowAnonymous;
            AllowedRoles = allowedRoles;
            RedirectController = string.Empty;
            RedirectMethod = string.Empty;
        }

        public CustomAuthorizeAttribute(bool allowAnonymous, string redirectController, string redirectMethod)
        {
            AllowAnonymous = allowAnonymous;
            RedirectController = redirectController;
            RedirectMethod = redirectMethod;
            AllowedRoles = new string[0];
        }

        public CustomAuthorizeAttribute(bool allowAnonymous, string redirectController, string redirectMethod, string[] allowedRoles)
        {
            AllowAnonymous = allowAnonymous;
            AllowedRoles = allowedRoles;
            RedirectController = redirectController;
            RedirectMethod = redirectMethod;
        }

        private IFUser _iFUser;

        public CustomAuthorizeAttribute()
        {
            _iFUser = new FUser();
        }

        public string[] AllowedRoles { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string currentUserlogged = WindowsUser.Username;
            try
            {
                return _iFUser.IsMethodAccessible(currentUserlogged, AllowedRoles.ToList());
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}