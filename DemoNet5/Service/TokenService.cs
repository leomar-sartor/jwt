using DemoNet5.AuthHelpers;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace DemoNet5.Service
{
    public class TokenService
    {
        public string GerarSymetric()
        {
            var signingCredentials = new SigningCredentials(SymetricSecurit.GetKey(), SecurityAlgorithms.HmacSha256);
            return GerarToken(signingCredentials);
        }
        public string GerarECDsaAssymetric()
        {
            var signingCredentials = new SigningCredentials(ECDsaSecurity.ObterECDsaPrivada(), SecurityAlgorithms.EcdsaSha256);
            return GerarToken(signingCredentials);
        }
        public string GerarRSA()
        {
            var signingCredentials = new SigningCredentials(RSASecurity.ObterRsaPrivada(), SecurityAlgorithms.RsaSsaPssSha256);
            return GerarToken(signingCredentials);
        }
        private string GerarToken(SigningCredentials signIn)
        {
            DateTime Now = DateTime.Now;
            var Jwt = new SecurityTokenDescriptor
            {
                Issuer = "jwt-test",
                Audience = "jwt-test",
                IssuedAt = Now,
                NotBefore = Now,
                Expires = Now.AddDays(20),
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, "meuemail@gmail.com", ClaimValueTypes.Email),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.GivenName, "Nome Sobrenome"),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString())
                })
            };
            Jwt.SigningCredentials = signIn;

            var tokenHandler = new JsonWebTokenHandler();
            return tokenHandler.CreateToken(Jwt);
        }
    }
}
