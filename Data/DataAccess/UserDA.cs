using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.IDataAccess;
using Data.Messages;
using Data.Models;
using System.Data.Entity;

namespace Data.DataAccess
{
    public class UserDA : IUserDA
    {
        private readonly DefaultConnection _contex;
        public UserDA()
        {
            _contex = new DefaultConnection();
        }

        public Message<List<User>> SelectUsers()
        {
            Message<List<User>> result = new Message<List<User>>();

            try
            {
                var users = _contex.Users.ToList();

                result.IsSucceed = true;
                result.Data = users;

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
        public Message<User> GetUser(Guid userId)
        {
            Message<User> result = new Message<User>();

            try
            {
                var user = _contex.Users.FirstOrDefault(x => x.Id == userId);

                result.IsSucceed = true;
                result.Data = user;
            }
            catch(Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message.ToString();
                result.Data = null;
            }

            return result;
        }
        public Message<Guid?> AddUser(User user)
        {
            Message<Guid?> result = new Message<Guid?>();

            try
            {
                //_contex.Entry(user).State = EntityState.Added;
                _contex.Users.Add(user);
                _contex.SaveChanges();

                result.IsSucceed = true;
                result.Data = user.Id;
            }
            catch(Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message.ToString();
                result.Data = null;
            }

            return result;
        }
        public Message<Guid> UpdateUser(User user)
        {
            Message<Guid?> result = new Message<Guid?>();

            try
            {
                //_contex.Entry(user).State = EntityState.Modified;
                _contex.Users.Attach(user);               
                _contex.SaveChanges();

                result.IsSucceed = true;
                result.Data = user.Id;
            }
            catch (Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message.ToString();
                result.Data = null;
            }

            return result;
        }
        public Message<Guid> DeleteUser(User user)
        {
            Message<Guid> result = new Message<Guid>();

            try
            {
                //_contex.Entry(user).State = EntityState.Deleted;
                _contex.Users.Remove(user);               
                _contex.SaveChanges();

                result.IsSucceed = true;
                result.Data = user.Id;
            }
            catch(Exception ex)
            {
                result.IsSucceed = false;
                result.Message = ex.Message.ToString();
                result.Data = user.Id;
            }

            return result;
        }
    }
}
