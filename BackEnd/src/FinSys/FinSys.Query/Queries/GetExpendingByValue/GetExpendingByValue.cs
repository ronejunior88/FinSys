using MediatR;
using Newtonsoft.Json;

namespace FinSys.Query.Queries.GetExpendingByValue
{
    public class GetExpendingByValue : IRequest<IEnumerable<GetExpendingByValueResponse>>
    {
        public GetExpendingByValue()
        { }

        public GetExpendingByValue(double value,int page, int numberRow)
        {
            Value = value;
            Page = page;
            NumberRow = numberRow;
        }

        public double Value { get; set; }

        [JsonIgnore]
        public int Page { get; set; }

        [JsonIgnore]
        public int NumberRow { get; set; }
    }
}
