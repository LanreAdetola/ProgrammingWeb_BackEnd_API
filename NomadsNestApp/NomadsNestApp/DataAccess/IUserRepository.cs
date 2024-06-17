using NomadsNestApp.Models;
using System.Collections.Generic;

namespace NomadsNestApp.DataAccess
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        User GetById(int id);
        IEnumerable<User> GetAll();
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
    }
}
