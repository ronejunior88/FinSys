using AutoMapper;
using FinSys.Command.AddExpendingCommand;
using FinSys.Command.Interfaces;
using FinSys.Service.Domain;
using FinSys.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinSysController : ControllerBase
    {
        private IConfiguration _configuration;
        private IMapper _mapper; 
        private IAddExpendingService _addExpendingService;

        public FinSysController(IConfiguration configuration, IMapper mapper,IAddExpendingService addExpendingService)
        {   
            _configuration = configuration;
            _mapper = mapper;
            _addExpendingService = addExpendingService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddExpendingCommandRequest request)
        {
            return Ok(_addExpendingService.AddExpending(_mapper.Map<ExpendingDTO>(request)));
        }
    }
}
