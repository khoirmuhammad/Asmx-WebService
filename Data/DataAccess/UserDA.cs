using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.IDataAccess;
using Data.Messages;
using Data.Models;

namespace Data.DataAccess
{
    public class UserDA : IUserDA
    {
        private readonly DefaultConnection _contex;
        public UserDA()
        {
            _contex = new DefaultConnection();
        }

        public Message<List<UserModel>> SelectUsers()
        {
            Message<List<UserModel>> result = new Message<List<UserModel>>();

            try
            {
                List<UserModel> data = new List<UserModel>();

                var users = _contex.Users.ToList();

                foreach (var user in users)
                {
                    data.Add(new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Phone = user.Phone,
                        Birthdate = user.Birthdate
                    });
                }

                result.IsSucceed = true;
                result.Data = data;

                return result;

            }
            catch(Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message.ToString();
                result.Data = null;

                return result;
            }
        }
    }
}
