namespace FinSys.Service.Domain
{
    public class ExpendingDTO
    {
        public ExpendingDTO()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public int Inative { get; set; }
    }
}