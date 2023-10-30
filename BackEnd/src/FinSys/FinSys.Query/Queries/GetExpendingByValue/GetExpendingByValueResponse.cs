using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetExpendingByValue
{
    public class GetExpendingByValueResponse
    {
        public GetExpendingByValueResponse()
        {  }

        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
    }
}
