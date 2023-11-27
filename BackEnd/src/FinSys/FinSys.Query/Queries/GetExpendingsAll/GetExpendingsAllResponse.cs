﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetExpendingsAll
{
    public class GetExpendingsAllResponse
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public bool Inative { get; set; }
        public DateTime DateExpiration { get; set; }
        public DateTime DateRelease { get; set; }
        public DateTime? DatePayment { get; set; }
    }
}
