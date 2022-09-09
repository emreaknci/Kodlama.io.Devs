using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Students.Commands.CreateStudent;
using Kodlama.io.Devs.Application.Features.Students.Commands.DeleteStudent;
using Kodlama.io.Devs.Application.Features.Students.Commands.UpdateStudent;
using Kodlama.io.Devs.Application.Features.Students.Queries.GetListStudent;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStudentCommand createStudentCommand)
        {
            var result = await Mediator.Send(createStudentCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteStudentCommand deleteStudentCommand)
        {
            var result = await Mediator.Send(deleteStudentCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommand updateStudentCommand)
        {
            var result = await Mediator.Send(updateStudentCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListStudentQuery getListStudentQuery = new GetListStudentQuery { PageRequest = pageRequest };
            var result = await Mediator.Send(getListStudentQuery);
            return Ok(result);
        }
    }
}
