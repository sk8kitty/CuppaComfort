using CuppaComfort.Data;
using CuppaComfort.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace CuppaComfort.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _identityContext;
        private readonly CuppaDbContext _cuppaContext;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext identityContext, CuppaDbContext cuppaContext, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _identityContext = identityContext;
            _cuppaContext = cuppaContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }




        public IActionResult Feedback()
        {
            List<Feedback> feedbacks = _cuppaContext.Feedbacks.ToList();
            return View(feedbacks);
        }


        [HttpPost]
        public async Task<IActionResult> FeedbackCreate(Feedback f)
        {
            // verifies that feedback will not be displayed on the home page (Index.cshtml) by default
            f.DisplayApproved = false;

            f.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _cuppaContext.Feedbacks.Add(f);
            await _cuppaContext.SaveChangesAsync();

            TempData["Message"] = "Feedback submitted successfully!";
            return RedirectToAction("Feedback");
        }


        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> FeedbackDisplay(int id)
        {
            Feedback? f = await _cuppaContext.Feedbacks.FindAsync(id);

            if (f == null)
            {
                return NotFound();
            }

            // toggling attribute
            f.DisplayApproved = !f.DisplayApproved;

            await _cuppaContext.SaveChangesAsync();

            return RedirectToAction("Feedback");
        }


        [Authorize(Roles = "admin")]
        public async Task<IActionResult> FeedbackDelete(int id)
        {
            Feedback? fbToDelete = await _cuppaContext.Feedbacks.FindAsync(id);

            if (fbToDelete == null)
            {
                return NotFound();
            }

            return View(fbToDelete);
        }


        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("FeedbackDelete")]
        public async Task<IActionResult> FeedbackDeleteConfirmed(int id)
        {
            Feedback? fbToDelete = await _cuppaContext.Feedbacks.FindAsync(id);

            if (fbToDelete != null)
            {
                _cuppaContext.Feedbacks.Remove(fbToDelete);
                await _cuppaContext.SaveChangesAsync();

                TempData["Message"] = "Feedback was deleted successfully!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This feedback was already deleted.";
            return RedirectToAction("Index");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}