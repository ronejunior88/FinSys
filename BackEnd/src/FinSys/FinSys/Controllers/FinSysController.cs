using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Query.Queries.GetExpendingsAll;
using FinSys.Query.Queries.GetExpendingsById;
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
        private readonly GetExpendingsAllHandler _getExpendingsAll;
        private readonly GetExpendingsByIdHandler _getExpendingsById;

        public FinSysController(IConfiguration configuration, IMapper mapper,IMediator mediator, GetExpendingsAllHandler getExpendingsAll, GetExpendingsByIdHandler getExpendingsById)
        {   
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
            _getExpendingsAll = getExpendingsAll;
            _getExpendingsById = getExpendingsById;
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
        public async Task<IActionResult> GetByValue(double value)
        {
            try
            {
                //var result = await _getExpendingService.GetExpendingByValueAsync(value);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro com busca de gastos por Valor: ", ex);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddExpendingCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir gastos: ", ex);
            }       
        }
    }
}
