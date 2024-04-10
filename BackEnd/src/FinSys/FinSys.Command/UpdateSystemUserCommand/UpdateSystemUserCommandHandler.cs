using AutoMapper;
using FinSys.Command.Domain;
using FinSys.Command.Interfaces;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace FinSys.Command.UpdateSystemUserCommand
{
    public class UpdateSystemUserCommandHandler : IRequestHandler<UpdateSystemUserCommand, UserToken>
    {
        IConfiguration _configuration;
        IUpdateSystemUseService _command;
        IAuthenticate _authenticateService;
        IMapper _mapper;

        public UpdateSystemUserCommandHandler(IConfiguration configuration, IUpdateSystemUseService command, IMapper mapper, IAuthenticate authenticateService)
        {
            _configuration = configuration;
            _command = command;
            _mapper = mapper;
            _authenticateService = authenticateService;
        }


        public async Task<UserToken> Handle(UpdateSystemUserCommand request, CancellationToken cancellationToken)
        {
            var commandMap = _mapper.Map<SystemUserDTO>(request);

            using var hmac = new HMACSHA512();
            byte[] passWordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.NewPassword));
            byte[] passWordSalt = hmac.Key;

            commandMap.PasswordHash = passWordHash;
            commandMap.PasswordSalt = passWordSalt;

            await _command.UpdateSystemUser(commandMap);

            var token = _authenticateService.GenerateToken(request.Id, request.Email);

            return new UserToken
            {
                Token = token
            };
        }
    }
}
