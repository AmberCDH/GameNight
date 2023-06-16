using Avondspel.Domain;
using Avondspel.Services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Avondspel.Portal.Controllers
{
    public class BordspelController : Controller
    {
        private readonly IRepositoryBordspellen repositoryBordspellen;
        private readonly UserManager<IdentityUser> _userManager;

        public BordspelController(IRepositoryBordspellen _repositoryBordspellen, UserManager<IdentityUser> userManager)
        {
            repositoryBordspellen = _repositoryBordspellen;
            _userManager = userManager;
        }

        public Bordspel imageConverter(Bordspel bordspelModel, IFormFile imageFile)
        {
            using (var ms = new MemoryStream())
            {
                imageFile.CopyTo(ms);
                var fileInBytes = ms.ToArray();
                string imageString = Convert.ToBase64String(fileInBytes);
                bordspelModel.foto = imageString;
            }
            return bordspelModel;
        }

        //GET: Bordspel
        public ViewResult Index()
        {
            var bordspellen = repositoryBordspellen.GetBordspellen();
            return View(bordspellen);

        }

        //GET: Bordspel/Details/{?id}
        public ViewResult Details(int id)
        {
            Bordspel? bordspel = repositoryBordspellen.GetBordspelById(id);
            return View(bordspel);
        }

        //GET: Bordspel/Create
        [Authorize(Policy = "Gebruiker")]
        public IActionResult Create()
        {
            return View();
        }

        //POST: Bordspel/Create
        [Authorize(Policy = "Gebruiker")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bordspel bordspelModel, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                imageConverter(bordspelModel, imageFile);
                Task.Delay(1000);
            }
            var id = _userManager.GetUserId(User);
            bordspelModel.GebruikerId = id;
            ModelState.Remove("imageFile");
            ModelState.Remove("GebruikerId");
            if (ModelState.IsValid)
            {
                repositoryBordspellen.InsertBordspel(bordspelModel);
                repositoryBordspellen.save();
                return RedirectToAction("Index");
            }
            return View(bordspelModel);
        }

        //GET: Bordspel/Edit/{?id}
        [Authorize(Policy = "Gebruiker")]
        public ActionResult Edit(int id)
        {
            Bordspel? bordspel = repositoryBordspellen.GetBordspelById(id);
            return View(bordspel);
        }

        //POST: Bordspel/Edit/{?id}
        [Authorize(Policy = "Gebruiker")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bordspel bordspelModel, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                imageConverter(bordspelModel, imageFile);
                Task.Delay(1000);
            }
            var id = _userManager.GetUserId(User);
            bordspelModel.GebruikerId = id;
            ModelState.Remove("imageFile");
            ModelState.Remove("GebruikerId");
            if (ModelState.IsValid)
            {
                repositoryBordspellen.UpdateBordspel(bordspelModel);
                repositoryBordspellen.save();
                return RedirectToAction("Index");
            }
            return View(bordspelModel);
        }



        //DELETE: Bordspel/Delete/{?id}
        [Authorize(Policy = "Gebruiker")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult<Bordspel> DeleteConfirmed(int id)
        {
            repositoryBordspellen.DeleteBordspel(id);
            repositoryBordspellen.save();
            return RedirectToAction(nameof(Index));

        }

        protected override void Dispose(bool disposing)
        {
            repositoryBordspellen.Dispose();
            base.Dispose(disposing);
        }
    }
}
