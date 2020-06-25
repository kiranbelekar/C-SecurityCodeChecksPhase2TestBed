using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeChecksSecurityRelatedTestBed
{
    class CodeCheckTestCases
    {
        private static ILog log = LogManager.GetLogger("HomeController");  //InvalidLoggingClassNameRule voilation here

        static void Main(string[] args)
        {
            try
            {
                using (var tripleDES = new TripleDESCryptoServiceProvider()) //Weak encryption here
                {
                    //...
                }
            }
            catch (Exception e)
            {
               
            }
        }

        [HttpPost]
        public IActionResult ChangePassword()           //CSRF voilation here
        {
            // ...
            return View();
        }
    }

    //ClassImplementsICloneable voilation
    public class Class1 : ICloneable
    {
        public int a;
        public int b;

        public Class1(int aa, int bb)
        {
            AesManaged aes = new AesManaged
            {
                KeySize = 128,
                BlockSize = 128,
                Mode = CipherMode.ECB,  // Noncompliant			
                Padding = PaddingMode.PKCS7
            };
        }

        public string ToString()
        {
            return "(" + a + "," + b + ")";
        }

        public virtual object Cloning()
        {
            return new Class1(a, b);
        }
        object ICloneable.Clone()
        {
            return Cloning();
        }
    }
}
