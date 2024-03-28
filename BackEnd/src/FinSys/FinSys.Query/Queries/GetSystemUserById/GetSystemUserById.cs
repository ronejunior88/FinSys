using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSys.Query.Queries.GetSystemUserById
{
    public class GetSystemUserById : IRequest<GetSystemUserByIdResponse>
    {
        public GetSystemUserById()
        {  }

        public GetSystemUserById(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
