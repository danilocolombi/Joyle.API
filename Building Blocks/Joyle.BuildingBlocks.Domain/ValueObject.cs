using System;
using System.Diagnostics.CodeAnalysis;

namespace Joyle.BuildingBlocks.Domain
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public bool Equals([AllowNull] ValueObject other)
        {
            throw new NotImplementedException();
        }
    }
}
