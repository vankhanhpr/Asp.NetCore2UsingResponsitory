using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.model;
using WebApi.serrvice.authentication.model;
using WebApi.serrvice.userservice.interfaces;

namespace WebApi.serrvice.authentication.responsitoty
{
    public class AuthenticationResponsitory : IAuthentication
    {
        private readonly IConfiguration m_config;
        private IUserResponsitory m_userResponsitory;
        public AuthenticationResponsitory(IConfiguration config, IUserResponsitory userResponsitory)
        {
            m_config = config;
            m_userResponsitory = userResponsitory;
        }

        public bool checkPass(string pass, string passClient)
        {
            throw new NotImplementedException();
        }

        public DataRespond login(Auth auth)
        {
            Users user = m_userResponsitory.getUserByEmail(auth.email);
            DataRespond data = new DataRespond();
            if(auth.email==user.email&& auth.password== user.password)
            {
                data.data = new { toke = BuildToken(user), id = user.userid };
            }
            return data;
        }

        public void logout(int id)
        {
            throw new NotImplementedException();
        }

        public void refreshToken()
        {
            throw new NotImplementedException();
        }

        public bool validateToken(string token, string tokenClien)
        {
            throw new NotImplementedException();
        }


        private string BuildToken(Users user)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.username),
                new Claim(JwtRegisteredClaimNames.Email, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(m_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(m_config["Jwt:Issuer"],
                m_config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(1), //expire time là 30 phút
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
