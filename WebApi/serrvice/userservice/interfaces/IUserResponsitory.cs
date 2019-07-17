using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.interfaces.responsitory;
using WebApi.model;

namespace WebApi.serrvice.userservice.interfaces
{
    public interface IUserResponsitory:IResponsitory<Users>
    {
        dynamic getAllUser();
        Users getUserByEmail(string email);
    }
}
