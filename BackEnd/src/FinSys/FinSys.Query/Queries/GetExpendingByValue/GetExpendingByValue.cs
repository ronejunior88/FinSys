using MediatR;

namespace FinSys.Query.Queries.GetExpendingByValue
{
    public class GetExpendingByValue : IRequest<IEnumerable<GetExpendingByValueResponse>>
    {
        public GetExpendingByValue()
        { }

        public GetExpendingByValue(double value)
        {
            Value = value;
        }

        public double Value { get; set; }
    }
}
