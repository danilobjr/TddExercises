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
        private UserValidatorFake validator;
        private AccountManager manager;

        [SetUp]
        public void Setup()
        {
            newUser = UserBuilder.GetOne();
            validator = new UserValidatorFake(newUser);
            manager = new AccountManager(validator);
        }

        [Test]
        public void IsCredentialsValid_ValidUser_ReturnsTrue()
        {
            // arrange
            validator.UserIsValid = true;

            // act
            var credentialsIsValid = manager.IsCredentialsValid(newUser);

            // assert
            Assert.IsTrue(credentialsIsValid);
        }

        [Test]
        public void IsCredentialsValid_InvalidUser_ReturnsFalse()
        {
            // arrange
            validator.UserIsValid = false;

            // act
            var credentialsIsValid = manager.IsCredentialsValid(newUser);

            // assert
            Assert.IsFalse(credentialsIsValid);
        }
    }
}
