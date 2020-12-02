﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PerfectBabysitter.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfectBabysitter.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Account model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect(model?.ReturnUrl ?? "/Home/Index");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new Account());
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
                IdentityUser userCheck = await userManager.FindByNameAsync(model.FirstName);

                if (userCheck == null)  
                {  
                   var user = new IdentityUser  
                   {  
                       UserName = model.FirstName,  
                       NormalizedUserName = model.Email,  
                       Email = model.Email,  
                       PhoneNumber = model.PhoneNumber,  
                       EmailConfirmed = true,  
                       PhoneNumberConfirmed = true,  
                   };  
                   var result = await userManager.CreateAsync(user, model.Password);  

                   if (result.Succeeded)  
                   {  
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
    }
}
