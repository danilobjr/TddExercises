using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TddExercises.Main.Models;

namespace TddExercises.Main.Validators
{
    public class UserValidator : IValidator
    {
        private User user;

        public UserValidator(User user)
        {
            this.user = user;
        }

        public virtual bool IsValid()
        {
            var isEmptyEmail = string.IsNullOrEmpty(user.Email);
            var isValidEmail = Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

            if (isEmptyEmail || !isValidEmail)
            {
                return false;
            }

            return true;
        }
    }
}
