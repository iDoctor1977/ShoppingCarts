﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingCarts.Shared.Core.Models;

namespace ShoppingCarts.Shared.Core.Filters
{
    public class ApiLogActionFilterAsync : IAsyncActionFilter
    {
        private readonly ILogger<ApiLogActionFilterAsync> _logger;

        public ApiLogActionFilterAsync(IServiceProvider service)
        {
            _logger = service.GetRequiredService<ILogger<ApiLogActionFilterAsync>>();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Do something before the action executes.
            var logApiModel = new LogApiModel
            {
                LogTime = DateTime.Now,
                IpAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Request = context.HttpContext.Request.ToString(),
                Body = context.HttpContext.Request.Body.ToString()
            };

            _logger.LogInformation($"StorageRoom API call STARTED - {JsonConvert.SerializeObject(logApiModel)}");
            
            await next();
        }
    }
}
