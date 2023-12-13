using Challenge.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallangeService _challengeService;
        public ChallengeController(IChallangeService challangeService)
        {
            _challengeService = challangeService;
        }

        [HttpGet("obter-ultimos-repositorios")]
        public IActionResult ObterUltimosRepositorios()
        {
            try
            {
                return Ok(_challengeService.ObterUltimosCincoRepositorios());
            }
            catch
            (Exception)
            {
                return BadRequest();
            }
        }
    }
}
