﻿using FinSys.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Service.Interfaces
{
    public interface IAddSystemUserService
    {
        Task AddSystemUser(SystemUserDTO user);
    }
}
