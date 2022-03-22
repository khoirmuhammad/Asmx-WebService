using Data.Messages;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.IDataAccess
{
    public interface IUserDA
    {
        Message<List<User>> SelectUsers();
        Message<User> GetUser(Guid userId);
        Message<Guid?> AddUser(User user);
        Message<Guid> UpdateUser(User user);
        Message<Guid> DeleteUser(User user);
    }
}
