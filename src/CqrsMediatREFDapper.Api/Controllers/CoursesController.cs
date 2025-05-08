using CqrsMediatREFDapper.Application.InputModels;
using CqrsMediatREFDapper.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatREFDapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class CoursesController(ICourseAppService courseAppService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseInputModel courseInputModel)
        {
            await courseAppService.Register(courseInputModel);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CourseInputModel courseInputModel)
        {
            await courseAppService.Update(courseInputModel);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await courseAppService.Remove(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await courseAppService.GetAllCourses());

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id) =>
            Ok(await courseAppService.WatchCourse(id));
    }
}
