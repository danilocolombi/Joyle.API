using Joyle.BuildingBlocks.Domain;
using System;

namespace Joyle.Accounts.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public Username Username { get; private set; }
        public string FullName { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime? InactivationDate { get; set; }

        protected User() { }

        public static User CreateUserFromRegistration(
            Guid id,
            Username username,
            string fullName,
            Email email,
            string password)
        {
            return new User(id, username, fullName, email, password);
        }

        private User(
            Guid id,
            Username username,
            string fullName,
            Email email,
            string password)
        {
            this.Id = id;
            Username = username;
            FullName = fullName;
            Email = email;
            Password = password;
            IsActive = true;
        }

        public void Inactivate()
        {
            if (!IsActive)
                throw new BusinessRuleValidationException("User is already inactive");

            IsActive = false;
            InactivationDate = DateTime.Now;
        }

        public void Activate()
        {
            if (IsActive)
                throw new BusinessRuleValidationException("User is already active");

            IsActive = true;
            InactivationDate = null;
        }

        public void ChangeUsername(Username newUsername, int usersWithThisUsernameCounter)
        {
            if (this.Username == newUsername)
                return;

            if (usersWithThisUsernameCounter > 0)
                throw new BusinessRuleValidationException("Username must be unique");

            this.Username = newUsername;
        }

        public void ChangePassword(string newPassword)
        {
            this.Password = newPassword;
        }
    }
}
