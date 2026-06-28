using Microsoft.AspNetCore.Mvc;
using SmartClinicManagementSystem.Services;

namespace SmartClinicManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly FirebaseService _firebaseService;

        public HomeController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        public IActionResult Index()
        {
            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
