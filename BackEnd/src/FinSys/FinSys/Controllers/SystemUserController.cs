﻿using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.AddSystemUserCommand;
using FinSys.Command.UpdateExpendingCommand;
using FinSys.Command.UpdateSystemUserCommand;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetSystemUserAll;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        public SystemUserController(IConfiguration configuration,
                                           IMapper mapper,
                                         IMediator mediator,
                  IValidator<AddSystemUserCommand> systemUserAddValidator,
               IValidator<UpdateSystemUserCommand> systemUserUpdateValidator,
                       AddSystemUserCommandHandler addSystemUserCommandHandler,
                    UpdateSystemUserCommandHandler updateSystemUserCommandHandler,
                           GetSystemUserAllHandler getSystemUserAll
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
