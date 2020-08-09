using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/index")]
    public class MainController : Controller
    {
        // GET
        public HelloView Index()
        {

           
            
            String str = Guid.NewGuid().ToString("N");
            var hashCode = str.GetHashCode();
            var guid = Guid.Parse(str);
            var hashCode2 = guid.ToString("N").GetHashCode();

            var helloView = new HelloView {HelloText = guid.ToString()};
         //   Console.WriteLine($"{hashCode} = {hashCode2}  {Equals(hashCode,hashCode2)}");
            
            using (MD5 hash = MD5.Create())
            {
                string strHash = GetMd5Hash(hash, str);
                if (VerifyMd5Hash(hash, str, strHash))
                {
                    Console.WriteLine("ALL GOOD");
                }
                else
                { 
                    
                    Console.WriteLine("Not as Equals");
                }
            }
            
            static string GetMd5Hash(MD5 md5Hash, string input)
            {

                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }

            // Verify a hash against a string.
            static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
            {
                // Hash the input.
                string hashOfInput = GetMd5Hash(md5Hash, input);

                // Create a StringComparer an compare the hashes.
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (0 == comparer.Compare(hashOfInput, hash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            return helloView;
        }
    }
}