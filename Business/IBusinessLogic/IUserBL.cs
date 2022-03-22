using Data.Messages;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IBusinessLogic
{
    public interface IUserBL
    {
        Message<List<UserModel>> SelectUsers();
        Message<UserModel> GetUser(Guid userId);
        Message<Guid> SaveUser(UserModel userModel);
        Message<Guid> DeleteUser(Guid userId);
    }
}
