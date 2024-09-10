using System.Security.Cryptography;
using System.Text;

namespace Task3.classes
{
    public static class HMACGenerator
    {
        public static string GenerateHMAC(string message, byte[] key)
        {
            using HMACSHA256 hmac = new(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] hashBytes = hmac.ComputeHash(messageBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}