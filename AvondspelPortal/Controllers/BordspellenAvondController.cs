using Avondspel.Domain;
using Avondspel.Services;
using Avondspel.Services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Avondspel.Portal.Controllers
{
    public class BordspellenAvondController : Controller
    {
        private readonly IRepositoryBordspellenAvond _repositoryBordspellenAvond;
        private readonly IRepositoryBordspelLijst _repositoryBordspelLijst;
        private readonly IRepositoryBordspellen _repositoryBordspellen;
        private readonly IRepositoryGebruiker _repositoryGebruiker;
        private readonly IRepositoryEten _repositoryEten;

        private readonly IBordspellenAvondDomainService _bordspellenAvondDomainService;

        private readonly UserManager<IdentityUser> _userManager;

        public BordspellenAvondController(IBordspellenAvondDomainService bordspellenAvondDomainService, IRepositoryEten repositoryEten, IRepositoryBordspellenAvond repositoryBordspellenAvond, UserManager<IdentityUser> userManager, IRepositoryBordspelLijst repositoryBordspelLijst, IRepositoryBordspellen repositoryBordspellen, IRepositoryGebruiker repositoryGebruiker)
        {
            _repositoryBordspelLijst = repositoryBordspelLijst;
            _repositoryBordspellenAvond = repositoryBordspellenAvond;
            _repositoryBordspellen = repositoryBordspellen;
            _userManager = userManager;
            _repositoryGebruiker = repositoryGebruiker;
            _repositoryEten = repositoryEten;
            _bordspellenAvondDomainService = bordspellenAvondDomainService;
        }

        //GET : BordspellenAvond
        [Authorize(Policy = "Gebruiker")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                try
                {
                    var emailUser = _bordspellenAvondDomainService.getGebruikerByEmail(user.Email);
                    var bordspellenAvond = _bordspellenAvondDomainService.GetBordspellenAvonden(emailUser);
                    ViewBag.Gebruiker = emailUser;
                    return View(bordspellenAvond);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return View();
        }

        //GET : BordspellenAvond/Gebruiker
        [Authorize(Policy = "Gebruiker")]
        public IActionResult Gebruiker()
        {
            try
            {
                var id = _userManager.GetUserId(User);
                var bordspellenAvond = from BordspellenAvond in _bordspellenAvondDomainService.getBordspellenAvondMetUser(id) select BordspellenAvond;
                return View(bordspellenAvond);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("Index");
        }

        //GET : BordspellenAvond/GebruikerInAvonden
        [Authorize(Policy = "Gebruiker")]
        public async Task<IActionResult> GebruikerInAvonden()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                Gebruiker? gebruiker = _bordspellenAvondDomainService.getGebruikerByEmail(user.Email);
                if (gebruiker == null)
                {
                    throw new Exception("gebruiker is null");
                }
                else
                {
                    var bevattend = _bordspellenAvondDomainService.GetBordspellenAvondMetGebruikerId(gebruiker.Id);
                    var lijstAvondenMetGebruiker = new List<BordspellenAvond>();

                    if (bevattend != null)
                    {
                        if (bevattend.Any())
                        {
                            foreach (var gebruikerIn in bevattend)
                            {
                                if (gebruikerIn != null)
                                {
                                    var avondMetGebruiker = _bordspellenAvondDomainService.getBordspellenAvondMetId(gebruikerIn.Id);
                                    if (avondMetGebruiker != null)
                                    {
                                        lijstAvondenMetGebruiker.Add(gebruikerIn);
                                    }

                                }
                            }
                            ViewBag.lijstAvondenMetGebruiker = lijstAvondenMetGebruiker;
                        }
                        else
                        {
                            ViewBag.lijstAvondenMetGebruiker = null;
                        }
                    }
                    else
                    {
                        ViewBag.lijstAvondenMetGebruiker = null;
                    }

                    return View();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }

        //GET : BordspellenAvond/Details/{?id}
        [Authorize(Policy = "Gebruiker")]
        public async Task<ViewResult> Details(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var gebruiker = _bordspellenAvondDomainService.getGebruikerByEmail(user.Email);
                BordspellenAvond? bordspellenAvond = _bordspellenAvondDomainService.getBordspellenAvondMetId(id);
                var bordspelData = _bordspellenAvondDomainService.GetBordspellenLijstByAvond(id);
                
                bool isEmpty = true;
                bool isOwner = false;
                var lijstBordspel = new List<Bordspel>();

                if (bordspellenAvond != null)
                {
                    if (bordspellenAvond.Gebruikers.Any())
                    {
                        isEmpty = false;
                    }
                    if (user.Id.Equals(bordspellenAvond.GebruikerId))
                    {
                        isOwner = true;
                    }
                }
                if (bordspelData != null)
                {
                    foreach (var bordspel in bordspelData)
                    {
                        var bordspelUitLijst = _repositoryBordspellen.GetBordspelById(bordspel.BordspelId);
                        if (bordspelUitLijst != null)
                        {
                            lijstBordspel.Add(bordspelUitLijst);
                        }
                    }
                }
                if (gebruiker != null)
                {
                    ViewBag.Gebruiker = gebruiker;
                } else
                {
                    Console.WriteLine("Geen gebruiker gevonden");
                }

                ViewBag.isEmpty = isEmpty;
                ViewBag.isOwner = isOwner;
                ViewBag.BordspelLijst = lijstBordspel;

                return View(bordspellenAvond);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }

        //GET : BordspellenAvond/Create
        [Authorize(Policy = "Gebruiker")]
        public IActionResult Create()
        {
            try
            {
                var bordspellenData = _bordspellenAvondDomainService.GetBordspellen();
                var etenData = _bordspellenAvondDomainService.GetEten();
                var lijst = new List<SelectListItem>();
                var lijstEten = new List<SelectListItem>();
                foreach (var bordspel in bordspellenData)
                {
                    lijst.Add(new SelectListItem { Text = bordspel.Naam, Value = bordspel.Id.ToString() });
                }
                foreach (var eten in etenData)
                {
                    lijstEten.Add(new SelectListItem { Text = eten.Name, Value = eten.Id.ToString() });
                }
                if (lijstEten.Count > 0)
                {
                    ViewBag.eten = lijstEten;
                }

                ViewBag.bordspellen = lijst;
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }

        //POST : BordspellenAvond/Create
        [Authorize(Policy = "Gebruiker")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BordspellenAvond bordspellenAvond, List<string> bordspellen, List<string> etenLijst)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                bordspellenAvond.GebruikerId = user.Id;
                ModelState.Remove("GebruikerId");
                var gebruiker = _bordspellenAvondDomainService.getGebruikerByEmail(user.Email);

                if (!etenLijst.Any())
                {
                    bordspellenAvond.PotLuck = true;
                }
                else
                {
                    foreach (var x in etenLijst)
                    {
                        var eten = _bordspellenAvondDomainService.GetEtenById(int.Parse(x));
                        if (eten != null)
                        {
                            bordspellenAvond.EtenLijst.Add(eten);
                        }
                    }
                }

                if (ModelState.IsValid)
                {
                    foreach (var item in bordspellen)
                    {
                        if (item != null)
                        {
                            var bordspel = _bordspellenAvondDomainService.GetBordspelById(int.Parse(item));
                            if (bordspel != null)
                            {
                                if (bordspel.AchtienPlus)
                                {
                                    bordspellenAvond.AchtienPlus = true;
                                }
                            }
                        }
                    }
                    if (gebruiker != null)
                    {
                        _bordspellenAvondDomainService.InsertBordspellenAvond(bordspellenAvond, gebruiker);
                    }
                    else
                    {
                        throw new Exception("gebruiker is null");
                    }

                    foreach (var item in bordspellen)
                    {
                        var bordspellenLijst = new BordspellenLijst();
                        bordspellenLijst.BordspelId = int.Parse(item);
                        bordspellenLijst.SpelAvondId = bordspellenAvond.Id;
                        bordspellenLijst.GebruikerId = user.Id;
                        _repositoryBordspelLijst.InsertInLijst(bordspellenLijst);
                        _repositoryBordspelLijst.save();
                    }

                    await _userManager.AddClaimAsync(user, new Claim("UserType", "organisator"));
                    return RedirectToAction("Gebruiker");

                }
                try
                {
                    var bordspellenData = _bordspellenAvondDomainService.GetBordspellen();
                    var etenData = _bordspellenAvondDomainService.GetEten();
                    var lijst = new List<SelectListItem>();
                    var lijstEten = new List<SelectListItem>();
                    foreach (var bordspel in bordspellenData)
                    {
                        lijst.Add(new SelectListItem { Text = bordspel.Naam, Value = bordspel.Id.ToString() });
                    }
                    foreach (var eten in etenData)
                    {
                        lijstEten.Add(new SelectListItem { Text = eten.Name, Value = eten.Id.ToString() });
                    }
                    if (lijstEten.Count > 0)
                    {
                        ViewBag.eten = lijstEten;
                    }

                    ViewBag.bordspellen = lijst;
                    return View(bordspellenAvond);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View(bordspellenAvond);
        }

        //GET : BordspelAvond/Edit/{?id}
        [Authorize(Policy = "Organisator")]
        public ActionResult Edit(int id)
        {
            try
            {
                BordspellenAvond? bordspellenAvond = _bordspellenAvondDomainService.getBordspellenAvondMetId(id);
                var bordspelData = _bordspellenAvondDomainService.GetBordspellenLijstByAvond(id);
                var lijstBordspel = new List<Bordspel>();
                if (bordspelData != null && bordspelData.Any())
                {
                    foreach (var bordspel in bordspelData)
                    {
                        var bordspelUitLijst = _bordspellenAvondDomainService.GetBordspelById(bordspel.BordspelId);
                        if (bordspelUitLijst != null)
                        {
                            lijstBordspel.Add(bordspelUitLijst);
                        }
                    }
                    ViewBag.bordspellen = lijstBordspel;
                }
                return View(bordspellenAvond);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }

        //POST : BordspellenAvond/Edit/{?id}
        [Authorize(Policy = "Organisator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BordspellenAvond bordspellenAvond)
        {
            try
            {
                var id = _userManager.GetUserId(User);
                var gebruikerId = bordspellenAvond.GebruikerId;
                if (id.Equals(gebruikerId))
                {
                    bordspellenAvond.GebruikerId = id;
                    ModelState.Remove("GebruikerId");
                    if (ModelState.IsValid)
                    {
                        _bordspellenAvondDomainService.UpdateBordspellenAvond(bordspellenAvond);
                        return RedirectToAction("Index");
                    }
                    return View(bordspellenAvond);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Index");
        }

        //DELETE : BordspellenAvond/Delete/{?id}
        [Authorize(Policy = "Organisator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult<BordspellenAvond> DeleteConfirmed(int id)
        {
            try
            {
                var hasJoined = _bordspellenAvondDomainService.getBordspellenAvondMetId(id);
                if (hasJoined != null)
                {
                    if (hasJoined.Gebruikers.Any())
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        _bordspellenAvondDomainService.DeleteBordspellenAvond(id);
                        return RedirectToAction("Gebruiker");
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("Index");
        }

        //DELETE : BordspellenAvond/DeleteBordspel/{?id}
        [Authorize(Policy = "Gebruiker")]
        [HttpPost, ActionName("DeleteBordspel")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBordspel(int bordspelId, int spelavondId)
        {
            try
            {
                _bordspellenAvondDomainService.DeleteUitLijst(bordspelId, spelavondId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("Index");
        }

        //POST : BordspellenAvond/DoeMee/{?id}
        [Authorize(Policy = "Gebruiker")]
        [HttpPost, ActionName("DoeMee")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<BordspellenAvond>> DoeMee(int id)
        {
            if (User.Identity != null)
            {
                var user = await _userManager.GetUserAsync(User);
                try
                {
                    var gebruiker = _bordspellenAvondDomainService.getGebruikerByEmail(user.Email);
                    var avond = _bordspellenAvondDomainService.getBordspellenAvondMetId(id);

                    if (avond != null && gebruiker != null)
                    {
                        _bordspellenAvondDomainService.inschrijvenGebruikerInAvond(avond, gebruiker, user.Id);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult LijstVolError()
        {
            return View();
        }

        //GET : BordspellenAvond/VoegEtenToe/{?id}
        [Authorize(Policy = "Gebruiker")]
        public IActionResult VoegEtenToe(int avondId)
        {
            try
            {
                BordspellenAvond? bordspellenAvond = _repositoryBordspellenAvond.GetBordspellenAvondById(avondId);
                var etenData = _bordspellenAvondDomainService.GetEten();
                var lijstEten = new List<SelectListItem>();

                foreach (var eten in etenData)
                {
                    lijstEten.Add(new SelectListItem { Text = eten.Name, Value = eten.Id.ToString() });
                }

                ViewBag.eten = lijstEten;

                return View(bordspellenAvond);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction("Index");

        }

        //POST : BordspellenAvond/VoegEtenToe/{?id}
        [Authorize(Policy = "Gebruiker")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VoegEtenToe(List<string> etenLijst, BordspellenAvond bordspellenAvond)
        {

            if (User.Identity != null)
            {
                try
                {
                    var user = await _userManager.GetUserAsync(User);
                    var gebruiker = _bordspellenAvondDomainService.getGebruikerByEmail(user.Email);
                    var deelnemendAan = _bordspellenAvondDomainService.getBordspellenAvondMetUser(user.Id);
                    var avond = _bordspellenAvondDomainService.getBordspellenAvondMetId(bordspellenAvond.Id);

                    if (etenLijst.Any())
                    {

                        if (deelnemendAan != null)
                        {
                            if (avond != null)
                            {

                                var datumAvond = avond.Planning.ToString("dd/MM/yyyy");
                                foreach (var x in deelnemendAan)
                                {
                                    string datumPattern = x.Planning.ToString("dd/MM/yyyy");
                                    if (datumPattern == datumAvond)
                                    {
                                        return RedirectToAction("Index");
                                    }

                                }

                            }
                        }

                        foreach (var x in etenLijst)
                        {
                            var eten = _bordspellenAvondDomainService.GetEtenById(int.Parse(x));
                            if (eten != null)
                            {
                                _bordspellenAvondDomainService.InsertEtenInAvond(eten, bordspellenAvond.Id);
                            }
                        }
                        if (avond != null && gebruiker != null)
                        {
                            _bordspellenAvondDomainService.inschrijvenGebruikerInAvond(avond, gebruiker, user.Id);
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        var etenData = _bordspellenAvondDomainService.GetEten();
                        var lijstEten = new List<SelectListItem>();

                        foreach (var eten in etenData)
                        {
                            lijstEten.Add(new SelectListItem { Text = eten.Name, Value = eten.Id.ToString() });
                        }

                        ViewBag.eten = lijstEten;
                        ViewBag.warning = "Je moet iets bijdragen";
                        return View(bordspellenAvond);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return RedirectToAction("Login", "Home", null, null);
        }
        protected override void Dispose(bool disposing)
        {
            _repositoryBordspellenAvond.Dispose();
            base.Dispose(disposing);
        }
    }
}