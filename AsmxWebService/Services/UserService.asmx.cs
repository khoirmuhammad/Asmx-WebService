using Business.IBusinessLogic;
using Business.BusinessLogic;
using Data.Messages;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AsmxWebService.Services
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserService : System.Web.Services.WebService
    {

        private readonly IUserBL _user;
        public UserService()
        {
            _user = new UserBL();
        }

        [WebMethod]
        public Message<List<UserModel>> SelectUsers()
        {
            return _user.SelectUsers();
        }
    }
}
