using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Managers;
using TddExercises.Main.Models;
using TddExercises.Main.Tests.Builders;
using TddExercises.Main.Tests.Validators.Fakes;

namespace TddExercises.Main.Tests.Managers.Account
{
    [TestFixture]
    internal class AccountManager_IsCredentialsValid_Tests
    {
        private User newUser;
        private UserValidatorFake userValidator;
        private AccountManager manager;

        [SetUp]
        public void Setup()
        {
            newUser = UserBuilder.AUser().Valid().Build();
            userValidator = new UserValidatorFake();
            manager = new AccountManager(userValidator);
        }

        [Test]
        public void IsCredentialsValid_ValidUser_ReturnsTrue()
        {
            // arrange
            userValidator.UserIsValid = true;

            // act
            var credentialsIsValid = manager.IsCredentialsValid(newUser);

            // assert
            Assert.IsTrue(credentialsIsValid);
        }

        [Test]
        public void IsCredentialsValid_InvalidUser_ReturnsFalse()
        {
            // arrange
            userValidator.UserIsValid = false;

            // act
            var credentialsIsValid = manager.IsCredentialsValid(newUser);

            // assert
            Assert.IsFalse(credentialsIsValid);
        }
    }
}
