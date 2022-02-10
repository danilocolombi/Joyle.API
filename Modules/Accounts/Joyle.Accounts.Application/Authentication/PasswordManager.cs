using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Joyle.Accounts.Application.Authentication
{
    public class PasswordManager
    {
        private const int SaltSize = 0x10;
        private const int NumberOfInteractionsForIncryption = 0x3e8;
        private const int NumberOfBytesPerGeneration = 0x20;

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SaltSize, NumberOfInteractionsForIncryption))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(NumberOfBytesPerGeneration);
            }

            byte[] dst = new byte[0x31];

            Buffer.BlockCopy(salt, 0, dst, 1, SaltSize);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, NumberOfBytesPerGeneration);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;

            if (hashedPassword == null)
                return false;

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            byte[] src = Convert.FromBase64String(hashedPassword);

            if ((src.Length != 0x31) || (src[0] != 0))
                return false;

            byte[] dst = new byte[SaltSize];
            Buffer.BlockCopy(src, 1, dst, 0, SaltSize);
            byte[] buffer3 = new byte[NumberOfBytesPerGeneration];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, NumberOfBytesPerGeneration);

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, NumberOfInteractionsForIncryption))
                buffer4 = bytes.GetBytes(NumberOfBytesPerGeneration);

            return ByteArraysEqual(buffer3, buffer4);
        }

        [MethodImpl(MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a == null || b == null || a.Length != b.Length)
                return false;

            var areTheSame = true;

            for (var i = 0; i < a.Length; i++)
                areTheSame &= a[i] == b[i];

            return areTheSame;
        }
    }
}
