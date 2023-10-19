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
        public async Task<IActionResult> Get()
        {
            var result = await _getExpendingService.GetExpendingAsync();
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _getExpendingService.GetExpendingByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddExpendingCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
