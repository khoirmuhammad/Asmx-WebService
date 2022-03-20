using Business.IBusinessLogic;
using Data.DataAccess;
using Data.IDataAccess;
using Data.Messages;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLogic
{
    public class UserBL : IUserBL
    {
        private readonly IUserDA _userData;
        public UserBL()
        {
            _userData = new UserDA();
        }

        public Message<List<UserModel>> SelectUsers()
        {
            return _userData.SelectUsers();
        }
    }
}
