﻿using Joyle.BuildingBlocks.Domain;
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

        protected User() { }

        public static User CreateUserFromRegistration(Guid id, Username username, string fullName, Email email, string password)
        {
            return new User(id, username, fullName, email, password);
        }

        private User(Guid id, Username username, string fullName, Email email, string password)
        {
            this.Id = id;
            Username = username;
            FullName = fullName;
            Email = email;
            Password = password;
            IsActive = true;
        }
    }
}