using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Managers;
using TddExercises.Main.Models;
using TddExercises.Main.Repositories;

namespace TddExercises.Main.Tests.Managers.Account.Fakes
{
    internal class AccountManagerFake : AccountManager
    {
        internal bool IsUserCredentialsValid { get; set; }
        public bool WasInsertInDatabaseMethodCalled { get; set; }
        public bool WasSendEmailToMethodCalled { get; set; }

        public AccountManagerFake()
        {
        }

        public AccountManagerFake(UserRepository userRepo)
            : base(userRepo)
        {
        }

        public override bool IsCredentialsValid(User user)
        {
            return IsUserCredentialsValid;
        }

        public override void InsertInDatabase(User newUser)
        {
            WasInsertInDatabaseMethodCalled = true;
        }

        public override void SendEmailTo(string userEmail)
        {
            WasSendEmailToMethodCalled = true;
        }
    }
}
