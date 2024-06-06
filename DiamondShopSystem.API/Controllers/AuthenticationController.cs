﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Users;

namespace DiamondShopSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly ICustomerService _customerService;
        public AuthenticationController(IAuthenticateService authenticateService, ICustomerService customerService)
        {
            _authenticateService = authenticateService;
            _customerService = customerService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] DTO.LoginRequest request)
        {
            var token = _authenticateService.Authenticate(request.Email, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
        [Authorize]
        [HttpPost("test")]
        public IActionResult test()
        {

            return Ok(new int[] {1,2,3,4,5});
        }

    }
}
