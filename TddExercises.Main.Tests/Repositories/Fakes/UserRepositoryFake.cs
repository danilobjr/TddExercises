using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;
using TddExercises.Main.Repositories;

namespace TddExercises.Main.Tests.Repositories.Fakes
{
    internal class UserRepositoryFake : UserRepository
    {
        public bool CreatedMethodCalledOnce { get; set; }

        public override void Create(User newUser)
        {
            CreatedMethodCalledOnce = true;
        }
    }
}
