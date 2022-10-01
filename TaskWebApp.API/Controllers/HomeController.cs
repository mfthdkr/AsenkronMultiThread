using System;
using System.Diagnostics.CodeAnalysis;
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

                await Task.Delay(3000, token);
                var myTask = new HttpClient().GetStringAsync("https://www.google.com");

                // başka işlemler

                var data = await myTask;
                _logger.LogInformation("İstek bitti");

                return Ok(data);
            }
            catch (Exception ex)
            {
               _logger.LogInformation("istek iptal edildi." +ex.Message);
               return BadRequest();
            }
            


        }
    }
}
  