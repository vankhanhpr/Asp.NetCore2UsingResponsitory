using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.model
{
    public class Users
    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public int gender { get; set; }
        public string addr { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
