using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreAngular.API.DAL.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreAngular.API.Shared
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //var resultContext = await next();
            //var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //var repo = resultContext.HttpContext.RequestServices.GetService(typeof(IUserRepository));
            //var user = await repo.GetUser(userId);
            //user.LastActive = DateTime.Now;
            //await repo.SaveAll();
        }
    }
}
