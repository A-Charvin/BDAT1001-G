using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace G1_Project.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _manager; // RoleManager Added to the Identity
        public RolesController(RoleManager<IdentityRole> roleManager)  //Injected the same to the controller
        {
            _manager = roleManager;
        }
        public IActionResult Index()
        {
            //List of Roles
            var roles = _manager.Roles;
            return View(roles);
        }

        // Create Roles Get and Post
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdentityRole role)
        {
            // Check if Role Exists or Not
            if (!_manager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                _manager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult(); //Create the role
            }
            return RedirectToAction("Index");
        }
    }
}
