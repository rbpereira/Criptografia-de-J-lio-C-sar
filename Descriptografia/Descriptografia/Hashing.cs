using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Descriptografia
{
    class Hashing
    {
        public static string CalculateSHA1(string text)
        {
            try
            {
                using (var sha1 = new SHA1Managed())
                {
                    return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-","").ToLower();
                }
                //return string.Concat(hash.Select(b => b.ToString("x2")));
            }
            catch (Exception x)
            {
                throw new Exception(x.Message);
            }
        }
    }
}
