using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Query.Domain;
using FinSys.Query.Interfaces;
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
        private IGetExpendingService _getExpendingService;

        public FinSysController(IConfiguration configuration, IMapper mapper,IMediator mediator, IGetExpendingService getExpendingService)
        {   
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
            _getExpendingService = getExpendingService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _getExpendingService.GetExpendingAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro com busca de gastos: ", ex);
            }
            
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _getExpendingService.GetExpendingByIdAsync(id);
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
                var result = await _getExpendingService.GetExpendingByValueAsync(value);
                return Ok(result);
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
