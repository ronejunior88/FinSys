using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetExpendingsAll
{
    public class GetExpendingsAll : IRequest<IEnumerable<GetExpendingsAllResponse>>
    {
    }
}
