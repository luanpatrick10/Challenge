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

        [HttpGet("obter-repositorio/{posicao}")]
        public async Task<IActionResult> ObterUltimosRepositorios(int posicao)
        {
            try
            {
                var resultado = await _challengeService.ObterRepositorioPorPosicao(posicao);
                return Ok(resultado);
            }
            catch
            (Exception)
            {
                return BadRequest();
            }
        }
    }
}
