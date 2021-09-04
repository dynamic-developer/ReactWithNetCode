using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactWithNetCode.ActionFilter
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes

            object param;
            if (context.ActionArguments.TryGetValue("param", out param))
                context.ActionArguments["param"] = param.ToString().ToUpper();
            else
                context.ActionArguments.Add("param", "I come from action filter");


            
            //if (!context.ModelState.IsValid)
            //{
            //    context.Result = new BadRequestObjectResult(context.ModelState);
            //}
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}
