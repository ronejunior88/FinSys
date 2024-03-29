﻿using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.AddSystemUserCommand;
using FinSys.Command.UpdateExpendingCommand;
using FinSys.Command.UpdateSystemUserCommand;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
using FinSys.Query.Queries.GetSystemUserAll;
using FinSys.Query.Queries.GetSystemUserById;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Slapper.AutoMapper;

namespace FinSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        private IConfiguration _configuration;
        private IMapper _mapper;
        private IMediator _mediator;

        private readonly IValidator<AddSystemUserCommand> _systemUserAddValidator;
        private readonly IValidator<UpdateSystemUserCommand> _systemUserUpdateValidator;

        private readonly AddSystemUserCommandHandler _addSystemUserCommandHandler;
        private readonly UpdateSystemUserCommandHandler _updateSystemUserCommandHandler;

        private readonly GetSystemUserAllHandler _getSystemUserAll;
        private readonly GetSystemUserByIdHandler _getSystemUserById;

        public SystemUserController(IConfiguration configuration,
                                           IMapper mapper,
                                         IMediator mediator,
                  IValidator<AddSystemUserCommand> systemUserAddValidator,
               IValidator<UpdateSystemUserCommand> systemUserUpdateValidator,
                       AddSystemUserCommandHandler addSystemUserCommandHandler,
                    UpdateSystemUserCommandHandler updateSystemUserCommandHandler,
                           GetSystemUserAllHandler getSystemUserAll,
                          GetSystemUserByIdHandler getSystemUserById
                       )
        {
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
            _systemUserAddValidator = systemUserAddValidator;
            _systemUserUpdateValidator = systemUserUpdateValidator;
            _addSystemUserCommandHandler = addSystemUserCommandHandler;
            _updateSystemUserCommandHandler = updateSystemUserCommandHandler;
            _getSystemUserAll = getSystemUserAll;
            _getSystemUserById = getSystemUserById;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getSystemUserAll.Handle(new GetSystemUserAll(), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro com busca de usuarios: ", ex);
            }

        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getSystemUserById.Handle(new GetSystemUserById(id), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro com busca de usuario por Id: ", ex);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSystemUserCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _systemUserAddValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            try
            {
                await _addSystemUserCommandHandler.Handle(request, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir usuarios: ", ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateSystemUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _systemUserUpdateValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            try
            {
                await _updateSystemUserCommandHandler.Handle(request, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar os usuario: ", ex);
            }
        }
    }
}
