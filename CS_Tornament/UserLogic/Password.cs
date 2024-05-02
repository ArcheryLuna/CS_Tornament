using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Tornament.UserLogic
{
    internal class Password
    {
        private static int SaltRounds = 12;
        private static string Salt = BCrypt.Net.BCrypt.GenerateSalt(SaltRounds);

        public static string Hash(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, Salt).ToString();

            return hashedPassword;
        }

        public static bool Verify(string rawPassword, string hashedPassword)
        {
            bool passwordVerified = BCrypt.Net.BCrypt.Verify(rawPassword, hashedPassword);

            return passwordVerified;
        }
    }
}
