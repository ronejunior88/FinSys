namespace FinSys.Service.Domain
{
    public class ExpendingDTO
    {
        public ExpendingDTO()
        {  }

        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
    }
}