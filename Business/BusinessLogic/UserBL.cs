using Business.IBusinessLogic;
using Data;
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
            Message<List<UserModel>> result = new Message<List<UserModel>>();

            var response = _userData.SelectUsers();

            try
            {
                List<UserModel> data = new List<UserModel>();

                foreach (var item in response.Data)
                {
                    data.Add(new UserModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email,
                        Phone = item.Phone,
                        Birthdate = item.Birthdate
                    });
                }

                result.IsSucceed = response.IsSucceed;
                result.Message = response.Message;
                result.Data = data;
            }
            catch(Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }
        public Message<UserModel> GetUser(Guid userId)
        {
            Message<UserModel> result = new Message<UserModel>();

            try
            {
                var response = _userData.GetUser(userId);

                result.IsSucceed = response.IsSucceed;
                result.Message = response.Message;

                if (response.Data == null)
                {
                    result.Data = null;
                }
                else
                {
                    UserModel data = new UserModel
                    {
                        Id = response.Data.Id,
                        Name = response.Data.Name,
                        Email = response.Data.Email,
                        Phone = response.Data.Phone,
                        Birthdate = response.Data.Birthdate
                    };

                    result.Data = data;
                }
            }
            catch(Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message;
                result.Data = null;
            }

            return result;
        }
        public Message<Guid> SaveUser(UserModel userModel)
        {
            Message<Guid> result = new Message<Guid>();

            try
            {
                User user = new User();

                userModel.Id = userModel.Id == Guid.Parse("00000000-0000-0000-0000-000000000000") ? Guid.NewGuid() : userModel.Id;

                user = _userData.GetUser(userModel.Id).Data;

                user.Name = userModel.Name;
                user.Email = userModel.Email;
                user.Phone = userModel.Phone;
                user.Birthdate = userModel.Birthdate;

                if (user == null)
                {
                    var response = _userData.AddUser(user);

                    result.IsSucceed = response.IsSucceed;
                    result.Message = response.Message;
                    result.Data = (Guid)response.Data;
                }
                else
                {
                    var response = _userData.UpdateUser(user);

                    result.IsSucceed = response.IsSucceed;
                    result.Message = response.Message;
                    result.Data = response.Data;
                }
            }
            catch(Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message;
            }

            return result;

        }
        public Message<Guid> DeleteUser(Guid userId)
        {
            var user = _userData.GetUser(userId).Data;

            return _userData.DeleteUser(user);
        }
    }
}
