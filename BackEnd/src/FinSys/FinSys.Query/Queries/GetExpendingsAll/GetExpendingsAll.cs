using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetExpendingsAll
{
    public class GetExpendingsAll : IRequest<IEnumerable<GetExpendingsAllResponse>>
    {
        public GetExpendingsAll()
        { }

        public GetExpendingsAll(int page, int numberRow)
        {
            Page = page;
            NumberRow = numberRow;
        }

        [JsonIgnore]
        public int Page { get; set; }

        [JsonIgnore]
        public int NumberRow { get; set; }
    }
}
