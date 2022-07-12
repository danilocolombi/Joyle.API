using Joyle.BuildingBlocks.Application.Messages;
using System;

namespace Joyle.Accounts.Application.Users.ChangeUsername
{
    public class ChangeUsernameCommand : CommandBase
    {
        public Guid UserId { get; }
        public string Username { get; }

        public ChangeUsernameCommand(
            Guid userId,
            string username)
        {
            UserId = userId;
            Username = username;
        }
    }
}
