using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnologyByDynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TechnologiesController : BaseController
    {   
        /*Read Operations*/

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new GetListTechnologyQuery{PageRequest = pageRequest};
            var result = await Mediator.Send(getListTechnologyQuery);
            return Ok(result);
        }
        [HttpPost("GetList/Dynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,Dynamic dynamic)
        {
            var getListTechnologyByDynamicQuery = new GetListTechnologyByDynamicQuery { PageRequest = pageRequest ,Dynamic = dynamic};
            var result = await Mediator.Send(getListTechnologyByDynamicQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTechnologyQuery getByIdTechnologyQuery)
        {
            var techGetByIdDto = await Mediator.Send(getByIdTechnologyQuery);
            return Ok(techGetByIdDto);
        }
        /*Write Operations*/

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            var result = await Mediator.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            var result = await Mediator.Send(deleteTechnologyCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            var result = await Mediator.Send(updateTechnologyCommand);
            return Ok(result);
        }
    }
}
