using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeNeedsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("{caseid}/header")]
        [HttpGet]
        [SwaggerOperation(OperationId = "Cases_GetCases")]
        [SwaggerResponse(StatusCodes.Status200OK , Type = typeof(UserDetails))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]

        public async Task <IActionResult> GetShow(long caseid)
        {
            return Ok(await this._userRepository.GetUserDetails(caseid));
        }
    }
}
