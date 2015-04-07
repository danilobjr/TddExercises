using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Mail;

namespace TddExercises.Main.Tests.Mail.Fakes
{
    internal class MailerFake : Mailer
    {
        public bool SendWasCalledOnce { get; set; }

        public override void Send(string from, string to, string subject, string message)
        {
            SendWasCalledOnce = true;
        }
    }
}
