using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Models.Seguridad;

namespace Web.Controllers.Security
{
    public class BaseController : Controller
    {
        public UserLogueado UsuarioLogueado => User.Identity.Name;

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.UsuarioLogueado = UsuarioLogueado;
            }
            await next();
        }
        
    }
}
