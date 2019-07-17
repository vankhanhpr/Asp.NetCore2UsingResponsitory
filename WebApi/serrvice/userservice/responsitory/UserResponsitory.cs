using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.data;
using WebApi.model;
using WebApi.responsitory;
using WebApi.serrvice.userservice.interfaces;

namespace WebApi.serrvice.userservice.responsitory
{
    public class UserResponsitory : Responsitory<Users>, IUserResponsitory
    {
        private DbSet<Users> userEntity;
        public UserResponsitory(MyDBContext context) : base(context)
        {
            userEntity = context.Set<Users>();
        }
        public dynamic getAllUser()
        {
            return context.Users.ToList();
        }

        public Users getUserByEmail(string email)
        {
            return context.Users.Where(m => m.email == email).FirstOrDefault();

        }
    }
}
