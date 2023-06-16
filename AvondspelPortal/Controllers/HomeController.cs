using Avondspel.Domain;
using Avondspel.Portal.Models;
using Avondspel.Services.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Avondspel.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRepositoryGebruiker _repositoryGebruiker;
        private readonly IRepositoryBordspellenAvond _repositoryBordspellenAvond;

        //Constructor
        public HomeController(IRepositoryBordspellenAvond repositoryBordspellenAvond, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IRepositoryGebruiker repositoryGebruiker)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repositoryGebruiker = repositoryGebruiker;
            _repositoryBordspellenAvond = repositoryBordspellenAvond;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.gebruiker = _userManager.GetUserName(User) + " ^_^";
            }
            else
            {
            }

            return View();
        }

        public IActionResult LeeftijdError()
        {
            return View();
        }

        //GET : Home/Profiel
        public async Task<IActionResult> Profiel()
        {
            if (User != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var email = user.Email;
                    Gebruiker gebruiker = _repositoryGebruiker.GetGebruikerByEmail(email);

                    var gebruikersAvonden = _repositoryBordspellenAvond.GetBordspellenAvondByUser(user.Id);
                    var bevattend = _repositoryBordspellenAvond.GetBordspellenAvondMetGebruiker(gebruiker.Id);
                    var lijstAvonden = new List<BordspellenAvond>();
                    var lijstAvondenMetGebruiker = new List<BordspellenAvond>();

                    if (bevattend != null)
                    {
                        if (bevattend.Any())
                        {
                            foreach (var gebruikerIn in bevattend)
                            {
                                if (gebruikerIn != null)
                                {
                                    var avondMetGebruiker = _repositoryBordspellenAvond.GetBordspellenAvondById(gebruikerIn.Id);
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
                            ViewBag.lijstMetGebruiker = null;
                        }
                    }
                    else
                    {
                        ViewBag.lijstMetGebruiker = null;
                    }



                    if (gebruikersAvonden != null)
                    {
                        if (gebruikersAvonden.Any())
                        {
                            foreach (var item in gebruikersAvonden)
                            {
                                lijstAvonden.Add(item);
                            }
                            ViewBag.lijstAvonden = lijstAvonden;
                        }
                        else
                        {
                            ViewBag.lijstAvonden = null;
                        }

                    }
                    return View("Profiel", gebruiker);
                }
            }
            return View("Index");

        }

        //GET : Home/Login
        public IActionResult Login()
        {
            if (User != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    return View("Profiel");
                }

            }
            return View();
        }

        //POST : Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Gender");
            ModelState.Remove("Birthday");
            ModelState.Remove("Street");
            ModelState.Remove("City");
            ModelState.Remove("HouseNumber");
            if (ModelState.IsValid)
            {
                //Login functionality
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (user != null)
                {
                    //Sign in
                    //IsPersistent moet je de gebruiker vertellen dat de cookie heel lang in je browser blijft.
                    if ((await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                }
            }
            return View(loginViewModel);
        }

        //GET : Home/Registreren
        public IActionResult Registreren()
        {
            return View();
        }

        //Post : Home/Registreren
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registreren(LoginViewModel loginViewModel)
        {

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                ModelState.AddModelError("", "Already signed in.");
            }
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = new IdentityUser(loginViewModel.Name);
            user.Email = loginViewModel.Email;
            var result = await _userManager.CreateAsync(user, loginViewModel.Password);
            if (result.Succeeded)
            {
                bool AchtienJaNee = CheckOuderDanAchtien(loginViewModel.Birthday);
                Gebruiker gebruiker = new Gebruiker
                {
                    Name = loginViewModel.Name,
                    Email = loginViewModel.Email,
                    Gender = loginViewModel.Gender,
                    Birthday = loginViewModel.Birthday,
                    Street = loginViewModel.Street,
                    City = loginViewModel.City,
                    HouseNumber = loginViewModel.HouseNumber,
                    OuderDanAchtien = AchtienJaNee,
                    Lactose = loginViewModel.Lactose,
                    Notenallergie = loginViewModel.Notenallergie,
                    Vega = loginViewModel.Vega,
                    Alcohol = loginViewModel.Alcohol,
                };
                _repositoryGebruiker.InsertGebruiker(gebruiker);
                _repositoryGebruiker.save();
                await _userManager.AddClaimAsync(user, new Claim("UserType", "gebruiker"));
                var signInResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        public bool CheckOuderDanAchtien(DateTime leeftijd)
        {
            DateTime date;
            bool parsed = DateTime.TryParse(leeftijd.ToString(), out date);
            if (!parsed)
            {
                return false;
            }
            else
            {
                var min = DateTime.Now.AddYears(-18);
                if (date < min)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
