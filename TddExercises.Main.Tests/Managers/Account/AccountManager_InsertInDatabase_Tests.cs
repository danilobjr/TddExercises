using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Managers;
using TddExercises.Main.Models;
using TddExercises.Main.Tests.Builders;
using TddExercises.Main.Tests.Repositories.Fakes;

namespace TddExercises.Main.Tests.Managers.Account
{
    [TestFixture]
    internal class AccountManager_InsertInDatabase_Tests
    {
        [Test]
        public void InsertInDatabase_CreateMethodOfUserRepository_CalledOnce()
        {
            // arrange
            var newUser = UserBuilder.AUser().Valid().Build();

            var repo = new UserRepositoryFake();
            repo.CreatedMethodCalledOnce = false;
            var manager = new AccountManager(repo);

            // act
            manager.InsertInDatabase(newUser);

            // assert
            Assert.IsTrue(repo.CreatedMethodCalledOnce);
        }
    }
}
