﻿using LoginService.Interfaces;
using LoginService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoginService.ViewModel
{
    public class JWTMangerRepository : IJWTMangerRepository
    {
        Dictionary<string, string> userRecords;

        private readonly IConfiguration configuration;

        private readonly FLIGHTDATABASEContext db;

        public JWTMangerRepository(IConfiguration _configuration, FLIGHTDATABASEContext _db)
        {
            configuration = _configuration;
            db = _db;
        }
        public Tokens Authenticate(LoginViewModel users, bool IsRegister)
        {
            if (IsRegister)
            {
                if (db.LoginTbs.Any(x => x.UserName == users.UserName))
                {
                    return null;
                }

                LoginTb loginTb = new LoginTb();
                loginTb.Name = users.Name;
                loginTb.UserName = users.UserName;
                loginTb.Password = users.Password;
                db.LoginTbs.Add(loginTb);
                db.SaveChanges();
            }
            userRecords = db.LoginTbs.ToList().ToDictionary(x => x.UserName, x => x.Password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (!userRecords.Any(x => x.Key == users.UserName && x.Value == users.Password))
            {
                return null;
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,users.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}

