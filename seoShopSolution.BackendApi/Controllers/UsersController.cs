﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using seoShopSolution.Application.System.Users;
using seoShopSolution.ViewModel.System.Users;
using System.Threading.Tasks;

namespace seoShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]//chua dang nhap van goi vao dc method nay 
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultToken = await _userService.Authencate(request);
            if (string.IsNullOrEmpty(resultToken))
            {
                return BadRequest("username or password is incorrect");
            }
            return Ok(resultToken);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Register(request);
            if (!result)
            {
                return BadRequest("Register is unsuccessful.");
            }
            return Ok();
        }
    }
}