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
            if (string.IsNullOrEmpty(user.Email)) { return false; }
            if (!Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)) 
            {
                return false;
            }

            if (string.IsNullOrEmpty(user.Password)) { return false; }
            if (user.Password.Length < 6 || user.Password.Length > 10) { return false; }
            if (user.Password.Contains(' ')) { return false; }
            if (!Regex.IsMatch(user.Password, @"[a-z]")) { return false; }
            if (!Regex.IsMatch(user.Password, @"[A-Z]")) { return false; }
            if (!Regex.IsMatch(user.Password, @"[0-9]")) { return false; }
            if (!user.Password.Contains('.') && !user.Password.Contains('_') && !user.Password.Contains('-') && !user.Password.Contains('!') && !user.Password.Contains('$')) { return false; }            

            return true;
        }
    }
}
