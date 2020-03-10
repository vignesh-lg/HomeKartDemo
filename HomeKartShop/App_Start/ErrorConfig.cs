using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeKartShop.App_Start
{
    public class ErrorConfig : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                string controller = (string)exceptionContext.RouteData.Values["controller"];
                string action = (string)exceptionContext.RouteData.Values["action"];
                Exception customException = new Exception("There may be some issues");
                var model = new HandleErrorInfo(customException, controller, action);
                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/_Error.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = exceptionContext.Controller.TempData
                };
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}