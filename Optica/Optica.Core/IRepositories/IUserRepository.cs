﻿using Optica.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optica.Core.IRepositories
{
    public interface IUserRepository:IRepository<User>
    {
        List<User> GetFull();
    }
}
