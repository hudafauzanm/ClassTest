using System;
using System.Security.Cryptography;
using System.Text;

namespace Hash
{
    public class Hash
    {
        private string _source;

        public static string md5(string _source)
        {
            {  
              MD5 md5 = new MD5CryptoServiceProvider();  

              md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_source));  
  
             
              byte[] result = md5.Hash;  

              StringBuilder strBuilder = new StringBuilder();  
                 for (int i = 0; i < result.Length; i++)  
                  {  
                    
                    strBuilder.Append(result[i].ToString("x2"));  
                  }  

               return strBuilder.ToString();  
            } 
        }

        public static string sha1(string _source)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
          {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(_source));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString().ToLower();
          } 
        }

        public static string sha256 (string _source)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(_source));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }
        }

        public static string sha512 (string _source)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(_source);
            using (var hash = System.Security.Cryptography.SHA512.Create())
                {
                    var hashedInputBytes = hash.ComputeHash(bytes);

    
                    var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                    foreach (var b in hashedInputBytes)
                        hashedInputStringBuilder.Append(b.ToString("X2"));
                    return hashedInputStringBuilder.ToString().ToLower();
                }
        }

        public Hash(string Source)
        {
            _source = Source;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Hash.md5("secret"));
            Console.WriteLine(Hash.sha1("secret"));
            Console.WriteLine(Hash.sha256("secret"));
            Console.WriteLine(Hash.sha512("secret"));   
        }
    }
}
