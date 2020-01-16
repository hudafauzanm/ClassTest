using System;
using Auth;
namespace Auth
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Auth auth = new Auth();
            auth.login("root","secret");
            auth.user();
            auth.id();
            auth.check();
            auth.guest();
            auth.lastLogin();
            auth.logout();
            auth.validate("root","secret");
        }
    }
}
