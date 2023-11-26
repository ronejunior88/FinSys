using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetExpendingsAll
{
    public class GetExpendingsAllResponse
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public bool Inative { get; set; }
    }
}
