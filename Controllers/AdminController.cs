using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsteriaApi.AuthUser;
using AsteriaApi.DataFolder;
using AsteriaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AsteriaApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AdminController(UserManager<User> userManager,
                                SignInManager<User> signInManager)
        {

            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public async Task<ActionResult<Specialist>> Get(UserLogin model)
        {
            var data = new Data();
            return await Task.Run(() => data.GetSpecialists().Value.Where(n => (n.Name == model.LoginProp)).FirstOrDefault());
        }


        [HttpPost]
        [Route("log")]
        public async Task<ActionResult> Login(UserLogin model)
        {
            SignInResult loginResult = new SignInResult();
            
            if (ModelState.IsValid)
            {
                loginResult = await _signInManager.PasswordSignInAsync(model.LoginProp,
                    model.Password,
                    false,
                    lockoutOnFailure: false);

                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return CreatedAtAction("Request", model.ReturnUrl);
                    }

                    return CreatedAtAction("Request", loginResult);
                }

            }

            ModelState.AddModelError("", "Пользователь не найден");
            return CreatedAtAction("Request", "Пользователь не найден или пароль не верен");
            
        }




        [HttpPost]
        [Route("reg")]
        public async Task<ActionResult<string>> Register(UserRegistration model)
        {
            IdentityResult createResult = new IdentityResult();
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.LoginProp };
               createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return CreatedAtAction("Request", createResult.Succeeded);
                }
                else//иначе
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }


            return BadRequest(createResult.Errors);
        }


        [HttpPost, ValidateAntiForgeryToken]

        [Route("out")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
