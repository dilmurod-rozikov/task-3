using System.Security.Cryptography;

namespace Task3.classes
{
    public class KeyGenerator
    {
        public static byte[] GenerateKey()
        {
            byte[] key = new byte[32];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(key);

            return key;
        }
    }
}