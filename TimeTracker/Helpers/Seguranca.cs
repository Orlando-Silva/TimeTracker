#region --Using--
using System.Security.Cryptography;
using System.Text;
#endregion

namespace Helpers
{
    public class Seguranca
    {

        public static string GerarHashSHA512(string texto)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);

                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));

                return hashedInputStringBuilder.ToString();
            }
        }

    }
}
