﻿using MediatR;

namespace FinSys.Command.UpdateExpendingCommand
{
    public class UpdateExpendingCommand : IRequest
    {
        public Guid Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public bool Inative { get; set; }
        public DateTime DateExpiration { get; set; }
        public DateTime DateRelease { get; set; }
        public DateTime? DatePayment { get; set; }
        public string IdUser { get; set; }
    }
}
