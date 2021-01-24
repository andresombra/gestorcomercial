using Gestor.Web.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Gestor.Web.Filters
{
    public class AutorizacaoActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string nomeController = ((Microsoft.AspNetCore.Mvc.ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
            
            context.HttpContext.Session.SetAutorizacao("userId", "1"); //Temporariamente para desenvolvimento

            //Caso nao seja pagina de login verificar autorizacao do usuario
            //if (nomeController!="Login" && context.HttpContext.Session.GetAutorizacao("user")==false) 
            //context.HttpContext.Response.Redirect("Login"); Redirecionar caso sem autorizacao
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
        }
    }
}
