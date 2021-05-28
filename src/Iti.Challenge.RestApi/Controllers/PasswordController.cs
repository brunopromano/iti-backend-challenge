using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Iti.Challenge.Domain;
using System.Threading.Tasks;
using Iti.Challenge.RestApi.Utils;

namespace Iti.Challenge.RestApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class PasswordController : ControllerBase
    {
        /// <summary>
        /// Check if a password has:
        /// at least 1 digit and
        /// at least 1 uppercase char and
        /// at least 1 lowercase char and
        /// at least 1 special char
        /// <summary>
        [Route("check"), HttpPost]
        public async Task<IActionResult> Check([FromBody] Password password)
        {
            try
            {
                if (password is null)
                {
                    return BadRequest(new { response = "Seems like you sent an invalid request body. Please, see the docs :)"});
                }

                bool response = await ValidatePassword.IsValid(password.ToString());
                
                return StatusCode(200, new { valid = response });
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Server failed =(");
            }
        }
    }
}