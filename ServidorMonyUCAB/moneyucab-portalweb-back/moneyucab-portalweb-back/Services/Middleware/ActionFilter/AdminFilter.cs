using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Services.Middleware.ActionFilter
{
    public class AdminFilter : ActionFilterAttribute
    {
        private readonly string _safelist;

        public AdminFilter(
            string safelist)
        {
            _safelist = safelist;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            /*var remoteIp = context.HttpContext.Connection.RemoteIpAddress;

            string[] ip = _safelist.Split(';');

            var badIp = true;
            foreach (var address in ip)
            {
                try
                {
                    if (remoteIp.IsIPv4MappedToIPv6)
                    {
                        remoteIp = remoteIp.MapToIPv4();
                    }
                    var testIp = IPAddress.Parse(address);
                    if (testIp.Equals(remoteIp))
                    {
                        badIp = false;
                        break;
                    }
                }
                catch (FormatException e)
                {
                    break;
                }
            }

            if (badIp)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

            base.OnActionExecuting(context);*/
        }
    }
}
