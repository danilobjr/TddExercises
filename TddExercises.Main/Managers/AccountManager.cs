using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Mail;
using TddExercises.Main.Models;
using TddExercises.Main.Repositories;
using TddExercises.Main.Validators;

namespace TddExercises.Main.Managers
{
    public class AccountManager
    {
        private UserValidator userValidator;
        private UserRepository userRepository;
        private Mailer mailer;

        public AccountManager()
        {
            userValidator = new UserValidator();
        }

        public AccountManager(UserValidator userValidator)
        {
            this.userValidator = userValidator;
        }

        public AccountManager(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public AccountManager(Mailer mailer)
        {
            this.mailer = mailer;
        }

        public bool RegisterNewUser(User newUser)
        {
            if (IsCredentialsValid(newUser))
            {
                InsertInDatabase(newUser);
                SendEmailTo(newUser.Email);

                return true;
            }

            return false;
        }

        public virtual bool IsCredentialsValid(User user)
        {
            return userValidator.IsValid(user);
        }

        public virtual void InsertInDatabase(User newUser)
        {
            userRepository.Create(newUser);
        }

        public virtual void SendEmailTo(string userEmail)
        {
            mailer.Send("no@reply", userEmail, "Welcome", "Welcome email message");
        }
    }
}
