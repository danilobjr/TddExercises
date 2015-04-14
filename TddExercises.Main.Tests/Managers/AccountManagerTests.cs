using NUnit.Framework;
using TddExercises.Main.Exceptions;
using TddExercises.Main.Models;

namespace TddExercises.Main.Tests.Managers
{
    [TestFixture]
    public class AccountManagerTests
    {
        private User INVALID_USER = new User();

        [Test]
        public void RegisterNewUser_InvalidNewUser_ReturnsFalse()
        {
            // Arrange
            var accountManager = new AccountManager();

            // Act
            var userWasRegistered = accountManager.RegisterNewUser(INVALID_USER);

            // Assert
            Assert.IsFalse(userWasRegistered);
        }
    }
}
