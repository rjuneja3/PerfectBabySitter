using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PerfectBabysitter.Models;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectBabysitter.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private IAccountRepository repository;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr, IAccountRepository repo)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            repository = repo;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(SignIn model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByEmailAsync(model.Email);

                if (user != null && !user.EmailConfirmed)
                {
                    ModelState.AddModelError("message", "Email not confirmed yet");
                    return View(model);
                }

                if (await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    string role = model.AccountType;
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
                    //return RedirectToAction("Dashboard");
                    return Redirect(model?.ReturnUrl ?? "/Home/Index");
                }
            }

            ModelState.AddModelError("message", "Invalid email or password");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            SignIn model = new SignIn();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            Account model = new Account();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(Account model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser userCheck = await userManager.FindByEmailAsync(model.Email);

                if (userCheck == null)
                {
                    var user = new IdentityUser
                    {
                        UserName = model.Email,
                        NormalizedUserName = model.Email,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };
                    var result = await userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        repository.AddAccount(model);
                        return RedirectToAction("Login");
                    }

                    else
                    {
                        if (result.Errors.Count() > 0)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("message", error.Description);
                            }
                        }
                        return View(model);
                    }
                }

                else
                {
                    ModelState.AddModelError("message", "Email already exists.");
                    return View(model);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
<<<<<<< HEAD
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
=======
            await signInManager.SignOutAsync();  
            return RedirectToAction("Login", "Account");  
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Account(string returnUrl)
        {
         
            return View();
        }


>>>>>>> AccountUI
    }
}
