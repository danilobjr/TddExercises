using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;

namespace TddExercises.Main.Tests.Mothers
{
    internal class UserMother
    {
        public static User GetOne()
        {
            return new User
            {
                Email = "a@a.c",
                Password = "asCD12!_"
            };
        }
    }
}
