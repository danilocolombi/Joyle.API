using Joyle.BuildingBlocks.Domain;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Joyle.Accounts.Domain.UserRegistrations
{
    public class UserRegistrationStatus : ValueObject, IEquatable<UserRegistrationStatus>
    {
        public static UserRegistrationStatus WaitingForConfirmation => new UserRegistrationStatus(nameof(WaitingForConfirmation));

        public static UserRegistrationStatus Confirmed => new UserRegistrationStatus(nameof(Confirmed));

        public string Value { get; }

        private UserRegistrationStatus(string value)
        {
            Value = value;
        }

        public override int GetHashCode()
            => StringComparer.OrdinalIgnoreCase.GetHashCode(Value);

        public override bool Equals(object obj)
        {
            if (obj is Username otherUsername)
                return Equals(otherUsername);

            return false;
        }

        public bool Equals([AllowNull] UserRegistrationStatus otherUsername)
        {
            if (otherUsername == null)
                return false;

            return string.Equals(this.Value, otherUsername.Value);
        }

        public static bool operator ==(UserRegistrationStatus username1, UserRegistrationStatus username2)
            => ReferenceEquals(username1, null) ? ReferenceEquals(username2, null) : username1.Equals(username2);

        public static bool operator !=(UserRegistrationStatus username1, UserRegistrationStatus username2)
            => !(username1 == username2);
    }
}
