using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.UpdateExpendingCommand;
using FinSys.Command.UploadExpendingCommand;
using FinSys.Query.Queries.GetExpendingByValue;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
using FinSys.Uploads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinSysController : ControllerBase
    {
        private IConfiguration _configuration;
        private IMapper _mapper;
        private IMediator _mediator;

        private readonly AddExpendingCommandHandler _addExpendingCommandHandler;
        private readonly UpdateExpendingCommandHandler _updateExpendingCommandHandler;
        private readonly UploadExpendingCommandHandler _uploadExpendingCommandHandler;

        private readonly GetExpendingsAllHandler _getExpendingsAll;
        private readonly GetExpendingsByIdHandler _getExpendingsById;
        private readonly GetExpendingByValueHandler _getExpendingByValue;

        public FinSysController(IConfiguration configuration, 
                                       IMapper mapper,
                                     IMediator mediator,
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
            _addExpendingCommandHandler = addExpendingCommandHandler;
            _updateExpendingCommandHandler = updateExpendingCommandHandler;
            _uploadExpendingCommandHandler = uploadExpendingCommandHandler;
            _getExpendingsAll = getExpendingsAll;
            _getExpendingsById = getExpendingsById;
            _getExpendingByValue = getExpendingByValue;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getExpendingsAll.Handle(new GetExpendingsAll(), cancellationToken);
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
        public async Task<IActionResult> GetByValue(double value, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _getExpendingByValue.Handle(new GetExpendingByValue(value), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro com busca de gastos por Valor: ", ex);
            }
            
        }

        [HttpPost("Upload")]
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
        public async Task<IActionResult> Post([FromBody]AddExpendingCommand request, CancellationToken cancellationToken)
        {
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
        public async Task<IActionResult> Put([FromBody] UpdateExpendingCommand request, CancellationToken cancellationToken)
        {
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
