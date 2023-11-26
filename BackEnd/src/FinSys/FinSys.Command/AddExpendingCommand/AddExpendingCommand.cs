﻿using MediatR;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommand : IRequest
    {
        public double Value { get; set; }
        public string Description { get; set; }
        public bool Inative { get; set; }
    }
}