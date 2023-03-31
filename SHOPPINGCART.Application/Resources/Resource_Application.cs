using System.Security.Cryptography;
using System.Text;

namespace SHOPPINGCART.Application.Resources
{
    public class Resource_Application
    {
        // Encriptación de Texto en SHA256
        public static string ConvertSha256(string text)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 sha = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = sha.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                {
                    Sb.Append(b.ToString("x2"));
                }
                return Sb.ToString();
            }

        }


    }
}
