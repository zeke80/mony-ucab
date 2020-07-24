using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Services.Middleware
{
    public class AdminBlackListMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _safelist;

        public AdminBlackListMiddleware(
            RequestDelegate next,
            ILogger<AdminBlackListMiddleware> logger,
            string safelist)
        {
            _safelist = safelist;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method != HttpMethod.Get.Method)
            {
                var remoteIp = context.Connection.RemoteIpAddress;

                string[] ip = _safelist.Split(';');

                var bytes = remoteIp.GetAddressBytes();
                var badIp = false;
                foreach (var address in ip)
                {
                    var testIp = IPAddress.Parse(address);
                    if (testIp.GetAddressBytes().SequenceEqual(bytes))
                    {
                        badIp = true;
                        break;
                    }
                }

                if (badIp)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }
}
