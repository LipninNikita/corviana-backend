using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.API.DTO;
using Test.API.Services;

namespace Test.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _testService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _testService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTest input)
        {
            var result = await _testService.Add(input);

            return Ok(result);
        }
    }
}
