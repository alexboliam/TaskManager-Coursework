using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.PL.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "TaskManagerServer";
        public const string AUDIENCE = "http://localhost:4200/";
        const string KEY = "onceupon_atime!!!";
        public const int LIFETIME = 20;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
