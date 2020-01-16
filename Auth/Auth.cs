using System;

namespace Auth
{
    public class Auth
    {
        // private static string  _user;
        // private static string  _password;
        
        //Varibel untuk menyimpan user yang log in
        public string logged = "";
        //Varibel untuk menyimpan password yang log in
        public string logpass = ""; 

        //Varibel untuk menyimpan id_user yang log in
        public string id_user = "";

        public string username = "root";
        public string password = "secret";

        public void login(string _user,string _password)
        {
            string username = "root";
            string password = "secret";
            

            if(username == _user && password == _password)
            {
                logged = _user;
                logpass = _password;
                id_user = "USR0001";
                Console.WriteLine("Successfull to Log In");
            }
            else if(username == _user && password != _password)
            {
                Console.WriteLine("Password Salah");
            }
            else if(username != _user && password == _password)
            {
                Console.WriteLine("Username Salah");
            }
            else
            {
                Console.WriteLine("Username dan Password Salah");
            }
        }

        public void validate(string _user,string _password)
        {

            if(username == _user && password == _password)
            {   
                Console.WriteLine("Akun anda tersedia dan ada");
            }
            else if(username == _user && password != _password)
            {
                Console.WriteLine("Password Salah");
            }
            else if(username != _user && password == _password)
            {
                Console.WriteLine("Username Salah");
            }
            else
            {
                Console.WriteLine("Username dan Password Salah");
            }
        }

        public void logout()
        {
            logged.Remove(0);
            logpass.Remove(0);
            Console.WriteLine("Berhasil Logout");
        }

        public void user()
        {
            Console.WriteLine("user :" + logged);
            Console.WriteLine("password :" + logpass);
        }

        public void id()
        {
            Console.WriteLine("id_user :" + id_user);
        }

        public bool check()
        {   
            if(logged == username)
            {
                Console.WriteLine("true");
                return true;
            }
            else 
            {
                Console.WriteLine("false");
                return false;
            }
        }

        public bool guest()
        {
            if(logged =="")
            {
                Console.WriteLine("true");
                return true;
            }
            else 
            {
                Console.WriteLine("false");
                return false;
            }
        }

        public void lastLogin()
        {
            Console.WriteLine("last login :" + logged);
        }
    }
}