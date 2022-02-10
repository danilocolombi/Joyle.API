using System.Linq;

namespace Joyle.Accounts.Application.UserRegistrations
{
    public class PasswordValidator
    {
        public const int MaxLength = 50;
        public const int MinLength = 8;
        public static readonly string Specifications = $@"The password length should be between {MinLength} and {MaxLength} characters and it should contain at least: 1 number, 1 letter, 1 special character";

        public static bool Validate(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (!HasRequiredSize(password))
                return false;

            if (!HasNumber(password))
                return false;

            if (!HasLetter(password))
                return false;

            if (!HasSpecialCharacter(password))
                return false;

            return true;
        }

        private static bool HasRequiredSize(string password)
            => password.Length >= MinLength && password.Length <= MaxLength;

        private static bool HasNumber(string password)
            => password.Any(char.IsDigit);

        private static bool HasLetter(string password)
            => password.Any(char.IsLetter);

        private static bool HasSpecialCharacter(string password)
           => password.Any(char.IsLetterOrDigit);
    }
}
