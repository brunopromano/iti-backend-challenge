using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Iti.Challenge.Domain;
using System.Threading.Tasks;

namespace Iti.Challenge.RestApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/api/[controller]")]
    public class PasswordController : ControllerBase
    {
        [Route("check"), HttpPost]
        public async Task<IActionResult> Check([FromBody] Password password)
        {
            try
            {
                Console.WriteLine(password.Value);
                return StatusCode(200, new { mensagem = "Requisição efetuada com sucesso =)" });
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Falha no backend!");
            }
        }
    }
}