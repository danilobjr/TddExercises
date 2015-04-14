using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Mail;
using TddExercises.Main.Models;
using TddExercises.Main.Repositories;
using TddExercises.Main.Validators;

namespace TddExercises.Main.Exceptions
{
    public class AccountManager
    {
        private UserValidator _userValidator;
        private UserRepository _userRepository;
        private Mailer _mailer;

        public AccountManager()
        {
            _userValidator = new UserValidator();
            _userRepository = new UserRepository();
            _mailer = new Mailer();
        }

        public bool RegisterNewUser(User newUser)
        {
            if (_userValidator.IsValid(newUser))
            {
                _userRepository.Create(newUser);
                _mailer.Send("no@reply", newUser.Email, "Welcome", "Welcome email message");

                return true;
            }

            return false;
        }

        public void DeleteUser(int userId)
        {
            var user = _userRepository.FindById(userId);

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            if (!user.IsActive)
            {
                _userRepository.Delete(userId);
            }
            else
            {
                throw new InvalidOperationException("Cannot delete a active user");
            }
        }
    }
}
