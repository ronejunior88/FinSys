using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Service.Interfaces;
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
        private IAddExpendingService _addExpendingService;

        public FinSysController(IConfiguration configuration, IMapper mapper,IMediator mediator, IAddExpendingService addExpendingService)
        {   
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
            _addExpendingService = addExpendingService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddExpendingCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
