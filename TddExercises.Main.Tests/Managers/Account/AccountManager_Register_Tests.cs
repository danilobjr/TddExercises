using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;
using TddExercises.Main.Tests.Managers.Account.Fakes;
using TddExercises.Main.Tests.Mothers;

namespace TddExercises.Main.Tests.Managers.Account
{
    [TestFixture]
    internal class AccountManager_Register_Tests
    {
        private User newUser;
        private AccountManagerFake managerFake = new AccountManagerFake();

        [SetUp]
        public void Setup()
        {
            newUser = UserMother.GetOne();
        }

        [Test]
        public void Register_ValidNewUser_ReturnsTrue()
        {
            // arrange
            managerFake.IsUserCredentialsValid = true;

            // act
            var registered = managerFake.Register(newUser);

            // assert
            Assert.IsTrue(registered);
        }

        [Test]
        public void Register_InvalidNewUser_ReturnsFalse()
        {
            // arrange
            var invalidNewUser = newUser;
            invalidNewUser.Email = "invalid";
            invalidNewUser.Password = "invalid";

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
            var registered = managerFake.Register(newUser);

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
            var registered = managerFake.Register(newUser);

            // assert
            Assert.IsTrue(managerFake.WasSendEmailToMethodCalled);
        }
    }
}
