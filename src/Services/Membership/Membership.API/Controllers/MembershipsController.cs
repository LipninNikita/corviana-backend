using Membership.API.DTO;
using Membership.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Membership.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class MembershipsController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipsController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpGet]
        [Route("Membership")]
        public async Task<IActionResult> Get() 
        {
            var result = await _membershipService.GetMembershipInfo();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> IsPayed()
        {
            await _membershipService.IsPayed();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Buy(AddMembership input)
        {
            var result = await _membershipService.Buy(input);

            return Ok(result);
        }
    }
}
