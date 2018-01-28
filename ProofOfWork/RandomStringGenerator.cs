using System;
using System.Linq;

namespace ProofOfWork
{
    public class RandomStringGenerator
    {
        private static readonly Random Random = new Random();
        /// <summary>
        /// Use RNGCryptoServiceProvider to generate truly random byte arrays
        /// </summary>
        public static string GenerateByLen(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
