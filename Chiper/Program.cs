using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;
using System.Security.Cryptography;
using System.IO;  

namespace Chipers
{
    public class Chiper
    {
        private string _source;
        private string _password;

        public static string encrypt(string _source,string _password)
        {
            string output = string.Empty;
            string password_correct = "p4$$w0rd";
            if (_password == password_correct)
            {
                string EncryptionKey = "3";
                byte[] clearBytes = Encoding.Unicode.GetBytes(_source);
                 using (Aes encryptor = Aes.Create())
              {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
               {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                _source = Convert.ToBase64String(ms.ToArray());
                }
              }
           } 
           else 
           {
               Console.WriteLine("Password Salah");
           }
           return _source;
        }

        public static string decrypt(string _source,string _password)
        {
            string output = string.Empty;
            string password_correct = "p4$$w0rd";
            if (_password == password_correct)
            {
                string EncryptionKey = "3";
                _source = _source.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(_source);
                using (Aes encryptor = Aes.Create())
             {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
              {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                _source = Encoding.Unicode.GetString(ms.ToArray());
              }
              }
    
           } 
           else 
           {
               Console.WriteLine("Password Salah");
           }
           return _source;
        }

        public Chiper(string Source,string Password)
        {
            _source = Source;
            _password = Password;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   
            var message = Chiper.encrypt("Ini tulisan rahasia", "p4$$w0rd");
            Console.WriteLine(message); 
            var decryptedMessage = Chiper.decrypt(message, "p4$$w0rd");
            Console.WriteLine(decryptedMessage);
        }
    }
}
