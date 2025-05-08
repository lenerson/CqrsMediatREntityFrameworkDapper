using CqrsMediatREFDapper.Application.InputModels;
using CqrsMediatREFDapper.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CqrsMediatREFDapper.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private readonly ICourseAppService courseAppService;

        public CoursesController(ICourseAppService courseAppService) => this.courseAppService = courseAppService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CourseInputModel courseInputModel)
        {
            await courseAppService.Register(courseInputModel);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CourseInputModel courseInputModel)
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