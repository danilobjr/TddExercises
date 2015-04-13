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
        private UserValidator userValidator;

        [SetUp]
        public void Setup()
        {
            user = new User();
            userValidator = new UserValidator();
        }

        [Test]
        public void IsValid_ValidBothEmailAndPassword_ReturnsTrue()
        {
            Assert_IsValid_ReturnsTrue_When(email: validEmail, password: validPassword);
        }

        [Test]
        public void IsValid_EmptyEmail_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: "", password: validPassword);
        }

        [Test]
        public void IsValid_NullEmail_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: null, password: validPassword);
        }

        [Test]
        public void IsValid_InvalidEmail_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: "a@", password: validPassword);
        }

        [Test]
        public void IsValid_EmptyPassword_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: validEmail, password: "");
        }

        [Test]
        public void IsValid_PasswordWithLengthLessThan6_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: validEmail, password: "12345");
        }

        [Test]
        public void IsValid_PasswordWithLengthMoreThan10_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: validEmail, password: "0123456789a");
        }

        [Test]
        public void IsValid_PasswordWithWhitespace_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: validEmail, password: "a bcde");
        }

        [Test]
        public void IsValid_PasswordWithoutLowercaseLetter_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: validEmail, password: "ABC!23");
        }

        [Test]
        public void IsValid_PasswordWithoutUppercaseLetter_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: validEmail, password: "abc!23");
        }

        [Test]
        public void IsValid_PasswordWithoutDigit_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: validEmail, password: "abcDE!");
        }

        [Test]
        public void IsValid_PasswordWithoutSymbol_ReturnsFalse()
        {
            Assert_IsValid_ReturnsFalse_When(email: validEmail, password: "abCD34");
        }

        private void Assert_IsValid_ReturnsTrue_When(string email, string password)
        {
            // arrange
            user.Email = email;
            user.Password = password;

            // act
            var isValid = userValidator.IsValid(user);

            // assert
            Assert.IsTrue(isValid);
        }

        private void Assert_IsValid_ReturnsFalse_When(string email, string password)
        {
            // arrange
            user.Email = email;
            user.Password = password;

            // act
            var isValid = userValidator.IsValid(user);

            // assert
            Assert.IsFalse(isValid);
        }
    }
}
