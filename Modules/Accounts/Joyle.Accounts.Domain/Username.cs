using Joyle.BuildingBlocks.Domain;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Joyle.Accounts.Domain
{
    public class Username : ValueObject, IEquatable<Username>
    {
        private const int MaxLength = 30;
        private const int MinLength = 2;
        public readonly string Specifications = @$"The username should be between {MinLength} and {MaxLength} characters and
        it can't contain empty spaces";

        public string Value { get; private set; }


        protected Username() { }

        public Username(string value)
        {
            if (!Validate(value))
                throw new BusinessRuleValidationException(Specifications);

            this.Value = value;
        }

        public static bool Validate(string value)
        {
            if (IsEmpty(value))
                return false;

            if (DoesntHaveRequiredSize(value))
                return false;

            if (ContainEmptySpaces(value))
                return false;

            return true;
        }

        private static bool IsEmpty(string value)
            => string.IsNullOrWhiteSpace(value);

        private static bool DoesntHaveRequiredSize(string value)
            => value.Length > MaxLength || value.Length < MinLength;

        private static bool ContainEmptySpaces(string value)
            => value.Contains(" ");

        public override string ToString()
          => $"[value: {Value}]";

        public override int GetHashCode()
            => StringComparer.OrdinalIgnoreCase.GetHashCode(Value);

        public override bool Equals(object obj)
        {
            if (obj is Username otherUsername)
                return Equals(otherUsername);

            return false;
        }

        public bool Equals([AllowNull] Username otherUsername)
        {
            if (otherUsername == null)
                return false;

            return string.Equals(this.Value, otherUsername.Value);
        }

        public static bool operator ==(Username username1, Username username2)
            => ReferenceEquals(username1, null) ? ReferenceEquals(username2, null) : username1.Equals(username2);

        public static bool operator !=(Username username1, Username username2)
            => !(username1 == username2);
    }
}
