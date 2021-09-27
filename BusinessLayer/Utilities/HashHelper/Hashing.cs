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
      



       public static string HashString(string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in GetHash(password))
            {
                stringBuilder.Append(b.ToString("X2"));
            }
            return stringBuilder.ToString();
        }

        private static byte[] GetHash(string password)
        {
            using (HashAlgorithm algorithm = SHA512.Create())
            {
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

 


       







    }
}
