using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.AddSystemUserCommand;
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
        private readonly AddSystemUserCommandHandler _systemUserCommandHandler;

        public SystemUserController(IConfiguration configuration,
                                           IMapper mapper,
                                         IMediator mediator,
                  IValidator<AddSystemUserCommand> systemUserAddValidator,
                       AddSystemUserCommandHandler systemUserCommandHandler)
        {
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
            _systemUserAddValidator = systemUserAddValidator;
            _systemUserCommandHandler = systemUserCommandHandler;
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
                await _systemUserCommandHandler.Handle(request, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir usuarios: ", ex);
            }
        }
    }
}
