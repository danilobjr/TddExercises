using System;
using TddExercises.Main.Models;
using TddExercises.Main.Managers;
using NUnit.Framework;

namespace TddExercises.Main.Tests
{
    [TestFixture]
    public class UserManagerTests
    {
        [Test]
        public void Register_ValidNewUser_ReturnsTrue()
        {
            var newUser = new User
            {
                Email = "meaningless email",
                Password = "meaningless password"
            };

            var userManager = new TestableUserManager();
            userManager.IsUserCredentialsValid = true;
            var result = userManager.Register(newUser);

            Assert.IsTrue(result);
        }

        [Test]
        public void Register_InvalidNewUser_ReturnsFalse()
        {
            var invalidNewUser = new User
            {
                Email = "meaningless email",
                Password = "meaningless password"
            };

            var userManager = new TestableUserManager();
            userManager.IsUserCredentialsValid = false;
            var result = userManager.Register(invalidNewUser);

            Assert.IsFalse(result);
        }

        [Test]
        public void Register_ValidNewUser_InsertNewUserInDatabase()
        {
            var invalidNewUser = new User
            {
                Email = "meaningless email",
                Password = "meaningless password"
            };

            var userManager = new TestableUserManager();
            userManager.IsUserCredentialsValid = true;
            userManager.WasInsertInDatabaseMethodCalled = false;
            var result = userManager.Register(invalidNewUser);

            Assert.IsTrue(userManager.WasInsertInDatabaseMethodCalled);
        }

        [Test]
        public void Register_ValidNewUser_SendAEmailToNewUser()
        {
            var invalidNewUser = new User
            {
                Email = "meaningless email",
                Password = "meaningless password"
            };

            var userManager = new TestableUserManager();
            userManager.IsUserCredentialsValid = true;
            userManager.WasSendEmailToMethodCalled = false;
            var result = userManager.Register(invalidNewUser);

            Assert.IsTrue(userManager.WasSendEmailToMethodCalled);
        }
    }

    internal class TestableUserManager : UserManager
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
}
