using Joyle.BuildingBlocks.Domain;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Joyle.Accounts.Domain.PasswordRecoveries
{
    public class PasswordRecoveryStatus : ValueObject, IEquatable<PasswordRecoveryStatus>
    {
        public static PasswordRecoveryStatus Requested => new PasswordRecoveryStatus(nameof(Requested));

        public static PasswordRecoveryStatus Recovered => new PasswordRecoveryStatus(nameof(Recovered));

        public string Value { get; }

        private PasswordRecoveryStatus(string value)
        {
            Value = value;
        }

        public override int GetHashCode()
           => StringComparer.OrdinalIgnoreCase.GetHashCode(Value);

        public override bool Equals(object obj)
        {
            if (obj is PasswordRecoveryStatus otherstatus)
                return Equals(otherstatus);

            return false;
        }

        public bool Equals([AllowNull] PasswordRecoveryStatus otherstatus)
        {
            if (otherstatus == null)
                return false;

            return string.Equals(this.Value, otherstatus.Value);
        }

        public static bool operator ==(PasswordRecoveryStatus status1, PasswordRecoveryStatus status2)
            => ReferenceEquals(status1, null) ? ReferenceEquals(status2, null) : status1.Equals(status2);

        public static bool operator !=(PasswordRecoveryStatus status1, PasswordRecoveryStatus status2)
            => !(status1 == status2);
    }
}
