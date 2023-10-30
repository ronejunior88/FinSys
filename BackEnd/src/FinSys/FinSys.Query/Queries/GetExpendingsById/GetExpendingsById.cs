using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetExpendingsById
{
    public class GetExpendingsById : IRequest<GetExpendingsByIdResponse>
    {
        public GetExpendingsById()
        { }

        public GetExpendingsById(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
