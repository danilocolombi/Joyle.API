using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.Users.GetUser
{
    public class GetUserQuery: QueryBase<UserDto>
    {
        public Guid UserId { get; }

        public GetUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
