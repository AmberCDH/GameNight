using Avondspel.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Avondspel.API.Controllers
{
    public interface IBordspelAvondController
    {
        Task<IActionResult> GetAvond(int? id);
        Task<ActionResult<IEnumerable<BordspellenAvond>>> GetAvonden();
        Task<IActionResult> PostAanmeldenVoorAvond(int avondId);
    }
}