using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddExercises.Main.Models;

namespace TddExercises.Main.Repositories
{
    public class UserRepository
    {
        public virtual void Create(User newUser)
        {
            // TODO - real implementation
            throw new NotImplementedException();
        }

        internal User FindById(int userId)
        {
            throw new NotImplementedException();
        }

        internal void Delete(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
