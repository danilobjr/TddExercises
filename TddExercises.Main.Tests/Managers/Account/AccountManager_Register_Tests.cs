using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;
using TddExercises.Main.Tests.Managers.Account.Fakes;
using TddExercises.Main.Tests.Builders;

namespace TddExercises.Main.Tests.Managers.Account
{
    [TestFixture]
    internal class AccountManager_Register_Tests
    {
        private User validNewUser;
        private AccountManagerFake managerFake = new AccountManagerFake();

        [SetUp]
        public void Setup()
        {
            validNewUser = UserBuilder.AUser().Valid().Build();
        }

        [Test]
        public void Register_ValidNewUser_ReturnsTrue()
        {
            // arrange
            managerFake.IsUserCredentialsValid = true;

            // act
            var registered = managerFake.Register(validNewUser);

            // assert
            Assert.IsTrue(registered);
        }

        [Test]
        public void Register_InvalidNewUser_ReturnsFalse()
        {
            // arrange
            var invalidNewUser = UserBuilder.AUser().Invalid().Build();

            managerFake.IsUserCredentialsValid = false;

            // act
            var registered = managerFake.Register(invalidNewUser);

            // assert
            Assert.IsFalse(registered);
        }

        [Test]
        public void Register_ValidNewUser_InsertNewUserInDatabase()
        {
            // arrange
            managerFake.IsUserCredentialsValid = true;
            managerFake.WasInsertInDatabaseMethodCalled = false;

            // act
            var registered = managerFake.Register(validNewUser);

            // assert
            Assert.IsTrue(managerFake.WasInsertInDatabaseMethodCalled);
        }

        [Test]
        public void Register_ValidNewUser_SendAEmailToNewUser()
        {
            // arrange
            managerFake.IsUserCredentialsValid = true;
            managerFake.WasSendEmailToMethodCalled = false;

            // act
            var registered = managerFake.Register(validNewUser);

            // assert
            Assert.IsTrue(managerFake.WasSendEmailToMethodCalled);
        }
    }
}
