using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaskWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {   
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {

            try
            {
                _logger.LogInformation("İstek başladı");

                Enumerable.Range(1,5).ToList().ForEach(x =>
                {
                    Thread.Sleep(1000);
                    token.ThrowIfCancellationRequested();
                });
               
                _logger.LogInformation("İstek bitti");

                return Ok("işlemler bitti");
            }
            catch (Exception ex)
            {
               _logger.LogInformation("istek iptal edildi." +ex.Message);
               return BadRequest();
            }
            


        }
    }
}
  