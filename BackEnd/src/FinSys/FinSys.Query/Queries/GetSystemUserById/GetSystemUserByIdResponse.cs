﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetSystemUserById
{
    public class GetSystemUserByIdResponse
    {
        public GetSystemUserByIdResponse()
        {  }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
