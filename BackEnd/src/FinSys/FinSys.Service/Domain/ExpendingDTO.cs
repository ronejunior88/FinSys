namespace FinSys.Service.Domain
{
    public class ExpendingDTO
    {
        public ExpendingDTO()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public int Inative { get; set; }
        public DateTime DateExpiration { get; set; }
        public DateTime DateRelease { get; set; }
        public DateTime? DatePayment { get; set; }
    }
}