using Avondspel.API.Services;
using Avondspel.Domain;
using Avondspel.Services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Avondspel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BordspelAvondController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private readonly IRepositoryBordspellenAvond _repositoryBordspellenAvond;
        private readonly IRepositoryGebruiker _repositoryGebruiker;
        private readonly ITokenService tokenService;

        public BordspelAvondController(IRepositoryBordspellenAvond repositoryBordspellenAvond, UserManager<IdentityUser> userManager, IRepositoryGebruiker repositoryGebruiker, IAuthorizationService authorizationService, ITokenService tokenService)
        {
            _repositoryBordspellenAvond = repositoryBordspellenAvond;
            _userManager = userManager;
            _repositoryGebruiker = repositoryGebruiker;
            this.tokenService = tokenService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BordspellenAvond>>> GetAvonden()
        {
            var token = await tokenService.GetToken();
            var email = token.Claims.First(c => c.Type == ClaimTypes.Email).Value;

            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                var gebruiker = _repositoryGebruiker.GetGebruikerByEmail(user.Email);
                var avonden = _repositoryBordspellenAvond.GetBordspellenAvonden(gebruiker);
                return Ok(avonden);
            }
            return BadRequest("Slechte Vibe Check");
        }

        [HttpPost("{avondId}")]
        public async Task<IActionResult> PostAanmeldenVoorAvond(int avondId)
        {
            var token = await tokenService.GetToken();
            var email = token.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                var gebruiker = _repositoryGebruiker.GetGebruikerByEmail(user.Email);
                var avonden = _repositoryBordspellenAvond.GetBordspellenAvondById(avondId);
                var aanmelding = _repositoryBordspellenAvond.InsertGebruikerInAvond(gebruiker, avondId);
                if(aanmelding != null)
                {
                    return Ok(aanmelding);
                }
                return BadRequest("Something went wrong");

            }


            return BadRequest("Slechte Vibe Check");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAvond(int? id)
        {
            var avond = _repositoryBordspellenAvond.GetBordspellenAvondById(id);
            if (avond != null)
            {
                return Ok(avond);
            }
            return BadRequest("Geen Avond gevonden");
        }
    }
}
