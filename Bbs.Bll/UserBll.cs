using Bbs.IDAL;
using Bbs.Models;
using System;
using System.Collections.Generic;

namespace Bbs.Bll
{
    public class UserBll 
    {
        private IUserDal _userDal;

        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public User GetUser(int Id)
        {
            return _userDal.GetUser(Id);
        }


        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }

        public bool SetUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
