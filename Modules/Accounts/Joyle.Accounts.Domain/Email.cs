using Joyle.BuildingBlocks.Domain;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Joyle.Accounts.Domain
{
    public class Email : ValueObject, IEquatable<Email>
    {
        public const int MaxLength = 100;
        public const int MinLength = 5;
        public const string Regex = @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$";
        public static readonly string Specifications = $"The email length should be between {MinLength} and {MaxLength} characters";

        public string Address { get; private set; }

        protected Email() { }

        public Email(string address)
        {
            if (!Validate(address))
                throw new BusinessRuleValidationException(Specifications);

            this.Address = address;
        }

        public static bool Validate(string address)
        {
            if (IsEmpty(address))
                return false;

            if (DoesntHaveRequiredSize(address))
                throw new BusinessRuleValidationException($"The email length should be between {MinLength} and {MaxLength} characters");

            return MatchesRegex(address);
        }

        private static bool IsEmpty(string address)
            => string.IsNullOrWhiteSpace(address);

        private static bool DoesntHaveRequiredSize(string address)
            => address.Length > MaxLength || address.Length < MinLength;

        private static bool MatchesRegex(string address)
            => new Regex(Regex).IsMatch(address);

        public override string ToString()
          => $"[address: {Address}]";

        public override int GetHashCode()
            => StringComparer.OrdinalIgnoreCase.GetHashCode(Address);

        public override bool Equals(object obj)
        {
            if (obj is Email otherEmail)
                return Equals(otherEmail);

            return false;
        }

        public bool Equals([AllowNull] Email otherEmail)
        {
            if (otherEmail == null)
                return false;

            return string.Equals(this.Address, otherEmail.Address);
        }

        public static bool operator ==(Email email1, Email email2)
            => ReferenceEquals(email1, null) ? ReferenceEquals(email2, null) : email1.Equals(email2);

        public static bool operator !=(Email email1, Email email2)
            => !(email1 == email2);
    }
}
