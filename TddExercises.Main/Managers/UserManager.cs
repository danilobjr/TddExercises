using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;
using TddExercises.Main.Validators;

namespace TddExercises.Main.Managers
{
    public class UserManager
    {
        private IValidator validator;

        public UserManager()
        {
        }

        public UserManager(IValidator validator)
        {
            this.validator = validator;
        }

        public bool Register(User newUser)
        {
            if (IsCredentialsValid(newUser))
            {
                InsertInDatabase(newUser);
                SendEmailTo(newUser);

                return true;
            }

            return false;
        }

        public virtual bool IsCredentialsValid(User user)
        {
            return validator.IsValid();
        }

        public virtual void InsertInDatabase(User newUser)
        {
            throw new NotImplementedException();
        }

        public virtual void SendEmailTo(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
