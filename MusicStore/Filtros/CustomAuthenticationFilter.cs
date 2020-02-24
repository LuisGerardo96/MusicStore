using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace MusicStore.Filtros
{
    public class CustomAuthenticationFilter : ActionFilterAttribute
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserId"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
       
    }
}