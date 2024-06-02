using Data.DataContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Functions.Worker.Http;

namespace UserProvider.Functions
{
    public class SubscribeProvider
    {
        private readonly ILogger<SubscribeProvider> _logger;
        private readonly DataContext _context;

        public SubscribeProvider(ILogger<SubscribeProvider> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Function("GetSubscribers")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            var subscribers = await _context.NotificationsEntities.ToListAsync();
            return new OkObjectResult(subscribers);
        }
    }
}
