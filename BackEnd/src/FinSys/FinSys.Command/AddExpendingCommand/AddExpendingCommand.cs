using AutoMapper;
using FinSys.Command.Domain;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FinSys.Command.AddExpendingCommand
{
    public class AddExpendingCommand : IRequest
    {
        public double Value { get; set; }
        public string Description { get; set; }
    }
}