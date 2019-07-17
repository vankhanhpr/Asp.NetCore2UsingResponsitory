using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.model;
using WebApi.serrvice.authentication;
using WebApi.serrvice.authentication.model;

namespace WebApi.controllers.auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthentication m_authentication;
        public AuthController(IAuthentication authetication)
        {
            m_authentication = authetication;
        }
        //login user
        [HttpPost("login")]
        public DataRespond login([FromBody]Users users)
        {
            DataRespond data = new DataRespond();
            try
            {
                Auth auth = new Auth();
                auth.email = users.email;
                auth.password = users.password;
                data.success = true;
                data.data = m_authentication.login(auth);
            }
            catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.message = e.Message;
            }
            return data;
        }
    }
}