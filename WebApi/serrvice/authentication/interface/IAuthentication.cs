using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.model;
using WebApi.serrvice.authentication.model;

namespace WebApi.serrvice.authentication
{
    public interface IAuthentication
    {
        DataRespond login(Auth auth);
        void logout(int id);

        void refreshToken();

        Boolean validateToken(String token, string tokenClien);

        Boolean checkPass(string pass, string passClient);

    }
}
