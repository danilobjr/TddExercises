using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;
using TddExercises.Main.Validators;

namespace TddExercises.Main.Tests.Validators.Fakes
{
    internal class UserValidatorFake : UserValidator
    {
        internal bool UserIsValid { get; set; }

        public override bool IsValid(User user)
        {
            return UserIsValid;
        }
    }
}
