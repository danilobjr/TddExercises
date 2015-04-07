using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;
using TddExercises.Main.Validators;

namespace TddExercises.Main.Tests.Validators
{
    [TestFixture]
    public class UserValidatorTests
    {
        private string validEmail = "a@a.com.br";
        private string validPassword = "abCD12_!";
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
            this.user.Email = this.validEmail;
            this.user.Password = this.validPassword;

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
        public void IsValid_NullEmail_ReturnsFalse()
        {
            // arrange
            this.user.Email = null;

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
            this.user.Password = this.validPassword;

            // act
            var isValid = this.validator.IsValid();

            // assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void IsValid_EmptyPassword_ReturnsFalse()
        {
            // arrange
            this.user.Email = this.validEmail;
            user.Password = "";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_PasswordWithLengthLessThan6_ReturnsFalse()
        {
            // arrange
            this.user.Email = this.validEmail;
            user.Password = "12345";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_PasswordWithLengthMoreThan10_ReturnsFalse()
        {
            // arrange
            this.user.Email = this.validEmail;
            user.Password = "0123456789a";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_PasswordWithWhitespace_ReturnsFalse()
        {
            // arrange
            this.user.Email = this.validEmail;
            user.Password = "a bcde";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_PasswordWithoutLowercaseLetter_ReturnsFalse()
        {
            // arrange
            this.user.Email = this.validEmail;
            user.Password = "ABC!23";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_PasswordWithoutUppercaseLetter_ReturnsFalse()
        {
            // arrange
            this.user.Email = this.validEmail;
            user.Password = "abc!23";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_PasswordWithoutDigit_ReturnsFalse()
        {
            // arrange
            this.user.Email = this.validEmail;
            user.Password = "abcDE!";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }

        [Test]
        public void IsValid_PasswordWithoutSymbol_ReturnsFalse()
        {
            // arrange
            this.user.Email = this.validEmail;
            user.Password = "abCD34";

            // act
            var isValid = validator.IsValid();

            // assert
            Assert.IsFalse(isValid);
        }
    }
}
