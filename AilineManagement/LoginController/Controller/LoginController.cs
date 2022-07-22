using LoginService.Interfaces;
using LoginService.Models;
using LoginService.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class LoginController : ControllerBase
    {
        
        private readonly FLIGHTDATABASEContext db;
        private readonly IJWTMangerRepository iJWTMangerRepository;
        public LoginController(FLIGHTDATABASEContext _db, IJWTMangerRepository _iJWTMangerRepository)
        {
            db = _db;
            iJWTMangerRepository = _iJWTMangerRepository;

        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var token = iJWTMangerRepository.Authenticate(loginViewModel, false);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        } 
        [HttpPost]
        [Route("Register")]

        public IActionResult Register(LoginViewModel loginViewModel)
        {
            var token = iJWTMangerRepository.Authenticate(loginViewModel, true);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
