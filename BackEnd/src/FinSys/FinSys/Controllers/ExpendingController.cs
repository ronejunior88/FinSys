using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.UpdateExpendingCommand;
using FinSys.Command.UploadExpendingCommand;
using FinSys.Query.Queries.GetExpendingByValue;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
using FinSys.Uploads;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FinSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpendingController : ControllerBase
    {
        private IConfiguration _configuration;
        private IMapper _mapper;
        private IMediator _mediator;

        private readonly IValidator<AddExpendingCommand> _expendingAddValidator;
        private readonly IValidator<UpdateExpendingCommand> _expendingUpdateValidator;

        private readonly AddExpendingCommandHandler _addExpendingCommandHandler;
        private readonly UpdateExpendingCommandHandler _updateExpendingCommandHandler;
        private readonly UploadExpendingCommandHandler _uploadExpendingCommandHandler;

        private readonly GetExpendingsAllHandler _getExpendingsAll;
        private readonly GetExpendingsByIdHandler _getExpendingsById;
        private readonly GetExpendingByValueHandler _getExpendingByValue;

        public ExpendingController(IConfiguration configuration,
                                       IMapper mapper,
                                     IMediator mediator,
               IValidator<AddExpendingCommand> expendingAddValidator,
            IValidator<UpdateExpendingCommand> expendingUpdateValidator,
                    AddExpendingCommandHandler addExpendingCommandHandler,
                 UpdateExpendingCommandHandler updateExpendingCommandHandler,
                 UploadExpendingCommandHandler uploadExpendingCommandHandler,
                       GetExpendingsAllHandler getExpendingsAll, 
                      GetExpendingsByIdHandler getExpendingsById, 
                    GetExpendingByValueHandler getExpendingByValue)
        {   
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
            _expendingAddValidator = expendingAddValidator;
            _expendingUpdateValidator = expendingUpdateValidator;
            _addExpendingCommandHandler = addExpendingCommandHandler;
            _updateExpendingCommandHandler = updateExpendingCommandHandler;
            _uploadExpendingCommandHandler = uploadExpendingCommandHandler;
            _getExpendingsAll = getExpendingsAll;
            _getExpendingsById = getExpendingsById;
            _getExpendingByValue = getExpendingByValue;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(int page, int numberRow, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getExpendingsAll.Handle(new GetExpendingsAll(page, numberRow), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro com busca de gastos: ", ex);
            }
            
        }


        [HttpGet("Id")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getExpendingsById.Handle(new GetExpendingsById(id), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro com busca de gastos por Id: ", ex);
            }
            
        }

        [HttpGet("Value")]
        public async Task<IActionResult> GetByValue(double value, int page, int numberRow, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getExpendingByValue.Handle(new GetExpendingByValue(value, page, numberRow), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro com busca de gastos por Valor: ", ex);
            }
            
        }

        [HttpPost("Upload")]
        [Authorize]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken) 
        {
            try
            {
                if (string.IsNullOrEmpty(file.ToString()))
                {
                    return BadRequest("O Arquivo não pode estar vazio ou Nulo.");
                }
                
                var fileReader = new UploadExpending(file);
                var uploadCommand = fileReader.GetFileAsync();

                await _uploadExpendingCommandHandler.Handle(uploadCommand, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao carregar Arquivo: ", ex);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]AddExpendingCommand request, CancellationToken cancellationToken)
        {

            var validationResult = _expendingAddValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                    return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));        
            }

            try
            {
                await _addExpendingCommandHandler.Handle(request, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir gastos: ", ex);
            }       
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UpdateExpendingCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _expendingUpdateValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(error => error.ErrorMessage));
            }

            try
            {
                await _updateExpendingCommandHandler.Handle(request, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar os gastos: ", ex);
            }
        }
    }
}
