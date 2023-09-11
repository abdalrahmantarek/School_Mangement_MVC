using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCTaskTwo.ViewModel;
using System.Reflection.Metadata.Ecma335;

namespace MVCTaskTwo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<IdentityUser> _userManager ,
            SignInManager<IdentityUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        // open registration page
        public IActionResult Registration()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Instructor");
            }
            return View();
        }

        //if data is valid save data in DB
        [HttpPost]
        public  async Task <IActionResult> Registration(RegistrationViewModel newUser)
        {
           
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.Email = newUser.Email;
                user.UserName = newUser.UesrName;
                var result = await userManager.CreateAsync(user, newUser.Password);
                if (result.Succeeded)
                {
                    //create cookie
                    await signInManager.SignInAsync(user, isPersistent: false);
                    // forward to authoraize  action
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage: item.Description);
                    }
                }
            }
            return View(newUser);
        }

        // open login page
        public IActionResult LogIn ( string ReturnUrl = "~/Instructor/Index")
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Instructor");
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginUser ,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {

                 IdentityUser? user = await userManager.FindByEmailAsync(loginUser.Email);
                if (user != null)
                {
                    //create cookie 
                    var result = await signInManager.PasswordSignInAsync(user, loginUser.password, loginUser.Ispersisite, false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "invalid UserName and password");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "invalid UserName and password");
                }

            }
            return  View(loginUser);
        }
        public async Task <IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        //add admin
        public IActionResult AdminRegistration()
        {
            return View("Registration");
        }

        //if data is valid save data in DB
        [HttpPost]
        public async Task<IActionResult> AdminRegistration(RegistrationViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.Email = newUser.Email;
                user.UserName = newUser.UesrName;
                var result = await userManager.CreateAsync(user, newUser.Password);
                var roleResult = await userManager.AddToRoleAsync(user, "Admin");

               
                if (result.Succeeded)
                {
                    //create cookie
                    await signInManager.SignInAsync(user, isPersistent: false);
                    // forward to authoraize  action
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage: item.Description);
                    }
                }
               
            }
            return View("Registration", newUser);
        }
    }
}
