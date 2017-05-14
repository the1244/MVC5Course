using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ShowMessageAttribute : ActionFilterAttribute
    {
        public string MyMessage { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = this.MyMessage;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

    }
}