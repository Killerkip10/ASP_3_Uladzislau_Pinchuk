using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Memory;
using Site.Services;
using ConsoleApp2.Models;

namespace Site.Middleware
{
    public class CacheMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache _memoryCache;

        public CacheMiddleware(RequestDelegate next, IMemoryCache memoryCache)
        {
            _next = next;
            _memoryCache = memoryCache;
        }

        public async Task Invoke(HttpContext context, DbService dbService)
        {
            List<Customer> customersList;
            List<AdditionalService> additionalServiceList;
            List<Nationality> nationalitiesList;
            List<ZodiacSign> zodiacSignsList;

            if (!_memoryCache.TryGetValue("customers", out customersList))
            {
                customersList = dbService.GetCustomers();

                _memoryCache.Set(
                    "customers",
                    customersList,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(2 * 7 + 240))
                );
            }
            if (!_memoryCache.TryGetValue("services", out additionalServiceList))
            {
                additionalServiceList = dbService.GetAdditionalServices();

                _memoryCache.Set(
                    "services",
                    additionalServiceList,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(2 * 7 + 240))
                );
            }
            if (!_memoryCache.TryGetValue("zodiacs", out zodiacSignsList))
            {
                zodiacSignsList = dbService.GetZodiacSigns();

                _memoryCache.Set(
                    "zodiacs",
                    zodiacSignsList,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(2 * 7 + 240))
                );
            }

            await _next.Invoke(context);
        }
    }

    public static class CacheMiddlewareExtensions
    {
        public static IApplicationBuilder UseCache(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CacheMiddleware>();
        }
    }
}
