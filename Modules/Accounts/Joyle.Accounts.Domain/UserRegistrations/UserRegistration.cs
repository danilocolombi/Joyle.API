using Joyle.Accounts.Domain.UserRegistrations.Events;
using Joyle.BuildingBlocks.Domain;
using System;

namespace Joyle.Accounts.Domain.UserRegistrations
{
    public class UserRegistration : Entity, IAggregateRoot
    {
        public Username Username { get; private set; }
        public string FullName { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime? ConfirmationDate { get; private set; }
        public UserRegistrationStatus Status { get; set; }

        protected UserRegistration() { }

        public static UserRegistration RegisterNewUser(
            Username username,
            string fullName,
            Email email,
            string password,
            int usersWithThisLoginCounter,
            string confirmationLink)
        {
            return new UserRegistration(username, fullName, email, password, usersWithThisLoginCounter, confirmationLink);
        }

        private UserRegistration(
            Username username,
            string fullName,
            Email email,
            string password,
            int usersWithThisUsernameCounter,
            string confirmationLink)
        {

            if (usersWithThisUsernameCounter > 0)
                throw new BusinessRuleValidationException("Username must be unique");

            this.Id = Guid.NewGuid();
            this.Username = username;
            this.FullName = fullName;
            this.Email = email;
            this.Password = password;
            this.RegistrationDate = DateTime.Now;
            this.Status = UserRegistrationStatus.WaitingForConfirmation;

            AddDomainEvent(new NewUserRegisteredDomainEvent(this.Id, this.FullName, this.Email, confirmationLink));
        }

        public void Confirm()
        {
            if (Status == UserRegistrationStatus.Confirmed)
                throw new BusinessRuleValidationException("User already confirmed");

            Status = UserRegistrationStatus.Confirmed;
            ConfirmationDate = DateTime.Now;

            AddDomainEvent(new UserRegistrationConfirmedDomainEvent(this));
        }
    }
}
