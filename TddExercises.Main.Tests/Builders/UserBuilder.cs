using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;

namespace TddExercises.Main.Tests.Builders
{
    internal class UserBuilder
    {
        private string Email { get; set; }
        private string Password { get; set; }

        public static UserBuilder AUser()
        {
            return new UserBuilder();
        }

        public UserBuilder Valid()
        {
            Email = "a@a.c";
            Password = "asCD12!_";

            return this;
        }

        internal UserBuilder Invalid()
        {
            Email = "invalid email";
            Password = "invalid password";

            return this;
        }

        public User Build()
        {
            return new User
            {
                Email = Email,
                Password = Password
            };
        }
    }
}
