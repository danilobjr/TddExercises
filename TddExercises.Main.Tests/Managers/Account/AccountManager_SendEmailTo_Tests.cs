using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Managers;
using TddExercises.Main.Models;
using TddExercises.Main.Tests.Mail.Fakes;
using TddExercises.Main.Tests.Managers.Account.Fakes;

namespace TddExercises.Main.Tests.Managers.Account
{
    [TestFixture]
    internal class AccountManager_SendEmailTo_Tests
    {
        [Test]
        public void SendEmailTo_SendMethodOfMail_CalledOnce()
        {
            // arrange
            var mailer = new MailerFake();
            mailer.SendWasCalledOnce = false;
            var manager = new AccountManager(mailer);

            // act
            manager.SendEmailTo("a@a.c");

            // assert
            Assert.IsTrue(mailer.SendWasCalledOnce);
        }
    }
}
