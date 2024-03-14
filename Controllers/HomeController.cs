using CuppaComfort.Data;
using CuppaComfort.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;

namespace CuppaComfort.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _identityContext;
        private readonly CuppaDbContext _cuppaContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext identityContext, CuppaDbContext cuppaContext, UserManager<IdentityUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _identityContext = identityContext;
            _cuppaContext = cuppaContext;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            List<Feedback> feedbacks = _cuppaContext.Feedbacks.Where(f => f.DisplayApproved).ToList();
            return View(feedbacks);
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
                return RedirectToAction("Feedback");
            }

            TempData["Message"] = "This feedback was already deleted.";
            return RedirectToAction("Feedback");
        }




        public IActionResult Careers()
        {
            List<Position> positions = _cuppaContext.Positions.ToList();
            return View(positions);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult PositionCreate() 
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> PositionCreate(Position p)
        {
            p.IsOpen = true; 

            if (ModelState.IsValid)
            {
                _cuppaContext.Positions.Add(p);
                await _cuppaContext.SaveChangesAsync();

                TempData["Message"] = $"'{p.Title}' has been added!";
                return RedirectToAction("Careers");
            }

            return View(p);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> PositionEdit(int id)
        {
            Position? positionToEdit = await _cuppaContext.Positions.FindAsync(id);

            if (positionToEdit == null)
            {
                return NotFound();
            }

            return View(positionToEdit);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> PositionEdit(Position p)
        {
            if (ModelState.IsValid)
            {
                _cuppaContext.Positions.Update(p);
                await _cuppaContext.SaveChangesAsync();

                TempData["Message"] = $"'{p.Title}' has been updated!";
                return RedirectToAction("Careers");
            }

            return View(p);
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> PositionDelete(int id)
        {
            Position? positionToDelete = await _cuppaContext.Positions.FindAsync(id);

            if (positionToDelete == null)
            {
                return NotFound();
            }

            return View(positionToDelete);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("PositionDelete")]
        public async Task<IActionResult> PositionDeleteConfirmed(int id)
        {
            Position? positionToDelete = await _cuppaContext.Positions.FindAsync(id);

            if (positionToDelete != null)
            {
                _cuppaContext.Positions.Remove(positionToDelete);
                await _cuppaContext.SaveChangesAsync();

                TempData["Message"] = "Position was deleted successfully!";
                return RedirectToAction("Careers");
            }

            TempData["Message"] = "This position was already deleted.";
            return RedirectToAction("Careers");
        }





        [Authorize]
        public IActionResult JobApplications()
        {
            // setup for select menu to get only open positions
            var openPositions = _cuppaContext.Positions.Where(p => p.IsOpen).ToList();
            ViewBag.OpenPositions = openPositions;

            if (User.IsInRole("admin"))
            {
                List<JobApplication> applications = _cuppaContext.JobApplications
                    .Where(app => app.Status == "Pending")
                    .ToList();
                return View(applications);
            }

            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<JobApplication> userApplications = _cuppaContext.JobApplications
                .Where(app => app.UserId == currentUserId) // gets only applications from the authenticated user
                .ToList();

            return View(userApplications);
        }


        [HttpPost]
        public async Task<IActionResult> ApplicationCreate(JobApplication j, IFormFile resumeFile)
        {
            j.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            j.ChosenPosition = _cuppaContext.Positions.SingleOrDefault(p => p.PositionId == j.ChosenPosition.PositionId);
            j.Status = "Pending";
            j.SubmissionDate = DateTime.Now;

            _cuppaContext.JobApplications.Add(j);
            await _cuppaContext.SaveChangesAsync();

            TempData["Message"] = "Application submitted successfully!";
            return RedirectToAction("JobApplications");
        }


        public async Task<IActionResult> ApplicationDetails(int id)
        {
            var openPositions = _cuppaContext.Positions.Where(p => p.IsOpen).ToList();
            ViewBag.OpenPositions = openPositions;

            JobApplication? appDetails = await _cuppaContext.JobApplications.FindAsync(id);

            if (appDetails == null)
            {
                return NotFound();
            }

            return View(appDetails);
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationDelete(int id)
        {
            var openPositions = _cuppaContext.Positions.Where(p => p.IsOpen).ToList();
            ViewBag.OpenPositions = openPositions;

            JobApplication? appToDelete = await _cuppaContext.JobApplications.FindAsync(id);

            if (appToDelete == null)
            {
                return NotFound();
            }

            return View(appToDelete);
        }

        [HttpPost]
        public async Task <IActionResult> ApplicationDeleteConfirmed(int id)
        {
            JobApplication? appToDelete = await _cuppaContext.JobApplications.FindAsync(id);

            if (appToDelete != null)
            {
                _cuppaContext.JobApplications.Remove(appToDelete);
                await _cuppaContext.SaveChangesAsync();

                TempData["Message"] = "Application was deleted successfully!";
                return RedirectToAction("JobApplications");
            }

            TempData["Message"] = "This application was already deleted.";
            return RedirectToAction("JobApplications");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task <IActionResult> ApplicationReject(int id)
        {
            JobApplication? appToReject = await _cuppaContext.JobApplications.FindAsync(id);

            if (appToReject == null)
            {
                return NotFound();
            }
            else
            {
                appToReject.Status = "Rejected";
                await _cuppaContext.SaveChangesAsync();
            }

            return RedirectToAction("JobApplications");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task <IActionResult> ApplicationAccept(int id)
        {
            JobApplication? appToAccept = await _cuppaContext.JobApplications.FindAsync(id);

            if (appToAccept == null)
            {
                return NotFound();
            }
            else
            {
                appToAccept.Status = "Accepted";
                await _cuppaContext.SaveChangesAsync();
            }

            return RedirectToAction("JobApplications");
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