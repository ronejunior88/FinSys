namespace FinSys.Command.Domain
{
    public class ExpendingCommand
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
    }
}