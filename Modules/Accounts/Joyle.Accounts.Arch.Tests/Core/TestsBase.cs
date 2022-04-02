using Joyle.Accounts.Application.UserRegistrations.RegisterNewUser;
using Joyle.Accounts.Domain.Users;
using Joyle.Accounts.Infra.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Joyle.Accounts.Arch.Tests.Core
{
    public abstract class TestsBase
    {
        protected Assembly _applicationAssembly => typeof(RegisterNewUserCommand).Assembly;

        protected Assembly _domainAssembly => typeof(User).Assembly;
        protected Assembly _infraAssembly => typeof(UserRepository).Assembly;

        protected void AssertAreImmutable(IEnumerable<Type> types)
        {
            var typesWithError = new List<Type>();

            foreach (var type in types)
            {
                if (type.GetFields().Any(x => !x.IsInitOnly) ||
                    type.GetProperties().Any(x => x.CanWrite))
                    typesWithError.Add(type);
            }

            Assert.Empty(typesWithError);
        }

        protected void AssertDontHavePublicSetters(IEnumerable<Type> types)
        {
            var typesWithError = new List<Type>();

            foreach (var type in types)
            {
                if (type.GetProperties().Any(x => x.CanWrite && x.SetMethod.IsPublic))
                    typesWithError.Add(type);
            }

            Assert.Empty(typesWithError);
        }
    }
}
