using System;
using TddExercises.Main.Models;
using TddExercises.Main.Managers;
using NUnit.Framework;
using TddExercises.Main.Validators;

namespace TddExercises.Main.Tests
{
    [TestFixture]
    public class UserManagerTests
    {
        [Test]
        public void Register_ValidNewUser_ReturnsTrue()
        {
            // arrange
            var newUser = new User
            {
                Email = "meaningless value",
                Password = "meaningless value"
            };

            var manager = new UserManagerFake();
            manager.IsUserCredentialsValid = true;

            // act
            var registered = manager.Register(newUser);

            // assert
            Assert.IsTrue(registered);
        }

        [Test]
        public void Register_InvalidNewUser_ReturnsFalse()
        {
            // arrange
            var invalidNewUser = new User
            {
                Email = "meaningless value",
                Password = "meaningless value"
            };

            var manager = new UserManagerFake();
            manager.IsUserCredentialsValid = false;

            // act
            var registered = manager.Register(invalidNewUser);

            // assert
            Assert.IsFalse(registered);
        }

        [Test]
        public void Register_ValidNewUser_InsertNewUserInDatabase()
        {
            // arrange
            var newUser = new User
            {
                Email = "meaningless value",
                Password = "meaningless value"
            };

            var manager = new UserManagerFake();
            manager.IsUserCredentialsValid = true;
            manager.WasInsertInDatabaseMethodCalled = false;

            // act
            var registered = manager.Register(newUser);

            // assert
            Assert.IsTrue(manager.WasInsertInDatabaseMethodCalled);
        }

        [Test]
        public void Register_ValidNewUser_SendAEmailToNewUser()
        {
            // arrange
            var newUser = new User
            {
                Email = "meaningless email",
                Password = "meaningless password"
            };

            var manager = new UserManagerFake();
            manager.IsUserCredentialsValid = true;
            manager.WasSendEmailToMethodCalled = false;

            // act
            var registered = manager.Register(newUser);

            // assert
            Assert.IsTrue(manager.WasSendEmailToMethodCalled);
        }

        [Test]
        public void IsCredentialsValid_ValidUser_ReturnsTrue()
        {
            // arrange
            var newUser = new User
            {
                Email = "meaningless value",
                Password = "meaningless value"
            };

            var validator = new UserValidatorFake(newUser);
            validator.UserIsValid = true;
            var manager = new UserManager(validator);

            // act
            var credentialsIsValid = manager.IsCredentialsValid(newUser);

            // assert
            Assert.IsTrue(credentialsIsValid);
        }

        [Test]
        public void IsCredentialsValid_ValidationFails_ReturnsFalse()
        {
            // arrange
            var newUser = new User
            {
                Email = "meaningless value",
                Password = "meaningless value"
            };

            var validator = new UserValidatorFake(newUser);
            validator.UserIsValid = false;
            var manager = new UserManager(validator);

            // act
            var credentialsIsValid = manager.IsCredentialsValid(newUser);

            // assert
            Assert.IsFalse(credentialsIsValid);
        }

        // TODO - test InsertInDatabase

        // TODO - test SendEmailTo
    }

    internal class UserManagerFake : UserManager
    {
        internal bool IsUserCredentialsValid { get; set; }
        public bool WasInsertInDatabaseMethodCalled { get; set; }
        public bool WasSendEmailToMethodCalled { get; set; }

        public override bool IsCredentialsValid(User user)
        {
            return IsUserCredentialsValid;
        }

        public override void InsertInDatabase(User newUser)
        {
            WasInsertInDatabaseMethodCalled = true;
        }

        public override void SendEmailTo(User newUser)
        {
            WasSendEmailToMethodCalled = true;
        }
    }

    internal class UserValidatorFake : UserValidator
    {
        internal bool UserIsValid { get; set; }

        public UserValidatorFake(User user) : base(user)
        {
        }

        public override bool IsValid()
        {
            return UserIsValid;
        }
    }
}
