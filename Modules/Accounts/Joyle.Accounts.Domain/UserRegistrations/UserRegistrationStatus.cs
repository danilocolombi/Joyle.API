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
            if (obj is UserRegistrationStatus otherstatus)
                return Equals(otherstatus);

            return false;
        }

        public bool Equals([AllowNull] UserRegistrationStatus otherstatus)
        {
            if (otherstatus == null)
                return false;

            return string.Equals(this.Value, otherstatus.Value);
        }

        public static bool operator ==(UserRegistrationStatus status1, UserRegistrationStatus status2)
            => ReferenceEquals(status1, null) ? ReferenceEquals(status2, null) : status1.Equals(status2);

        public static bool operator !=(UserRegistrationStatus status1, UserRegistrationStatus status2)
            => !(status1 == status2);
    }
}
