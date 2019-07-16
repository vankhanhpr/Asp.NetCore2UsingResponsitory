using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.model;
using WebApi.serrvice.userservice.interfaces;

namespace WebApi.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserResponsitory m_userResponsitory;
        public UserController(IUserResponsitory userResponsitory)
        {
            m_userResponsitory = userResponsitory;
        }
        
        [HttpGet("getAllUser")]
        public DataRespond getAllUser()
        {
            DataRespond data = new DataRespond();
            try
            {
                data.success = true;
                data.data = m_userResponsitory.getAllUser();
                data.message = "success";
            }
            catch(Exception e)
            {
                data.success = false;
                data.error = e;
                data.error = e.Message;
            }
            return data;
        }
    }
}