using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities.HashHelper
{
   public class Hashing
    {
       private static SHA1 _sha1 = new SHA1CryptoServiceProvider();

       

        public static string CreateHashing(string password)
        {
           var hashed =  Convert.ToBase64String(_sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return hashed;
        }
    }
}
