using System;
using System.Collections.Generic;
using Bbs.Models;

namespace Bbs.IDAL
{
    public interface IUserDal
    {
        User GetUser(int No);
        IEnumerable<User> GetUserList();
        bool SetUser(User user);
        User GetUser();
    }
}
