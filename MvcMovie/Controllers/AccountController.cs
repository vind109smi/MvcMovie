using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Account
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name};
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid registration attempt.");
            }

            // Up to this point, something has failed, and redisplay the form
            return View(model);

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
            // Something failed, redisplay the form
            return View(model);
        }

        //POST: /Account/LogOut
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Rename()
        {
            return View();
        }

        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rename(string Name)
        {
            ApplicationUser model = await _userManager.GetUserAsync(User);

            if(User.Identity.IsAuthenticated)
            {
                return NotFound();
            }

            try
            {
                model.Name = Name;
                await _userManager.UpdateAsync(model);
                System.Console.WriteLine("success");
            }

            catch
            {
                // No catch exception implemented here
            }

            return View(model);
        }

    }
}


//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Movie.ToListAsync());
//        }

//        // GET: Account/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var movie = await _context.Movie
//                .SingleOrDefaultAsync(m => m.ID == id);
//            if (movie == null)
//            {
//                return NotFound();
//            }

//            return View(movie);
//        }

//        // GET: Account/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Account/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(movie);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(movie);
//        }

//        // GET: Account/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
//            if (movie == null)
//            {
//                return NotFound();
//            }
//            return View(movie);
//        }

//        // POST: Account/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
//        {
//            if (id != movie.ID)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(movie);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!MovieExists(movie.ID))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(movie);
//        }

//        // GET: Account/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var movie = await _context.Movie
//                .SingleOrDefaultAsync(m => m.ID == id);
//            if (movie == null)
//            {
//                return NotFound();
//            }

//            return View(movie);
//        }

//        // POST: Account/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
//            _context.Movie.Remove(movie);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool MovieExists(int id)
//        {
//            return _context.Movie.Any(e => e.ID == id);
//        }
//    }
//}
