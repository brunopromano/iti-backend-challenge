using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Iti.Challenge.Domain;
using System.Threading.Tasks;
using Iti.Challenge.RestApi.Utils;
using Microsoft.Extensions.Logging;

namespace Iti.Challenge.RestApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly ILogger<PasswordController> _logger;
        private string clientIp;
        
        public PasswordController(ILogger<PasswordController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Check if a password has:
        /// at least 1 digit and
        /// at least 1 uppercase char and
        /// at least 1 lowercase char and
        /// at least 1 special char
        /// <summary>
        /// <remarks>
        /// Request Example:
        /// curl -X POST 'https://localhost:5001/api/password/check' -H "Content-Type: application/json" -d '{"value": "aj5$dh6H3!FY"}' -k 
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("check"), HttpPost]
        public async Task<IActionResult> Check([FromBody] Password password)
        {
            clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            _logger.LogInformation($"[{ DateTime.Now.ToString() }] POST value: { password.Value } api/password/check @ { clientIp }");

            try
            {
                if (password is null || password.Value is null)
                {
                    return BadRequest(new { message = "Seems like you sent an invalid request body. Please, see the docs :)"});
                }
                
                bool response = await ValidatePassword.IsValid(password.Value);
                
                return StatusCode(200, new { valid = response, message = "Processed :)" });
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { message = "Server failed :(" });
            }
        }
    }
}