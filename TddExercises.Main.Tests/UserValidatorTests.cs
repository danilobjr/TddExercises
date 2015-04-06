using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;
using TddExercises.Main.Validators;

namespace TddExercises.Main.Tests
{
    // TODO - refactor to align to Open/Close Principle

    [TestFixture]
    public class UserValidatorTests
    {
        private string validEmail = "a@a.com.br";
        private User user;
        private UserValidator validator;

        [SetUp]
        public void Init()
        {
            this.user = new User();

            this.validator = new UserValidator(user);
        }

        [Test]
        public void IsValid_ValidEmail_ReturnsTrue()
        {
            // arrange
            this.user.Email = "a@a.com.br";

            // act
            var isValid = this.validator.IsValid();

            // assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValid_EmptyEmail_ReturnsFalse()
        {
            // arrange
            this.user.Email = "";

            // act
            var isValid = this.validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_InvalidEmail_ReturnsFalse()
        {
            // arrange
            this.user.Email = "a@";

            // act
            var isValid = this.validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_ValidPassword_ReturnsTrue()
        {
            // arrange
            this.user.Email = this.validEmail;
            this.user.Password = "123456";

            // act
            var isValid = this.validator.IsValid();

            // assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValid_EmptyPassword_ReturnsFalse()
        {
            // arrange
            user.Password = "";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_PasswordWithLengthLessThan6_ReturnsFalse()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void IsValid_PasswordWithLengthMoreThan10_ReturnsFalse()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void IsValid_PasswordWithSpace_ReturnsFalse()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void IsValid_PasswordWithoutLowercaseLetter_ReturnsFalse()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void IsValid_PasswordWithoutUppercaseLetter_ReturnsFalse()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void IsValid_PasswordWithoutDigit_ReturnsFalse()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void IsValid_PasswordWithoutSymbol_ReturnsFalse()
        {
            throw new NotImplementedException();
        }
    }
}
