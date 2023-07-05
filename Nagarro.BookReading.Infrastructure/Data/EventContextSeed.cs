using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Infrastructure.Data
{
    public class EventContextSeed
    {

        public static async Task SeedAsync(EventContext eventContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

                try
            {
                eventContext.Database.Migrate();
                eventContext.Database.EnsureCreated();


            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<EventContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(eventContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

    }
}
