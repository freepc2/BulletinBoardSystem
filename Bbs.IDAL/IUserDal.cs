﻿using System;
using System.Collections.Generic;
using Bbs.Models;

namespace Bbs.IDAL
{
    public interface IUserDal
    {
        User GetUser(int No);
        List<User> GetUserList();
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
