using Microsoft.AspNetCore.Mvc;
using NextCBS.Bank.Module.IRepositories;

namespace NextCBS.Bank.Api.Controllers
{
    [Route("api/parameter")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly IParameterRepository _parameterRepository;

        public ParameterController(IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Module.Models.ParameterModel>> Upsert(Module.Models.ParameterModel parameterModel)
        {
            var entity = await _parameterRepository.UpsertParameter(parameterModel);
            return Ok(entity);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Module.Models.ParameterModel>> GetParameter(int id)
        {
            var item = await _parameterRepository.GetParameter(id);
            return Ok(item);
        }

        [HttpGet("all")]
        public async Task<ActionResult<Module.Models.ParameterModel>> GetParameters()
        {
            var entities = await _parameterRepository.GetAllParameters();
            return Ok(entities);
        }
    }
}
