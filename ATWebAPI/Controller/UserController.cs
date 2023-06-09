﻿using ATWebAPI.Facade.Interface;
using EFRepository.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserBusiness userBusiness, ILogger<UserController> logger)
        {
            _userBusiness = userBusiness;
            _logger = logger;

        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var users = await _userBusiness.Get();
            return Ok(users);

        }
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var users = await _userBusiness.Get(id);
            return Ok(users);
        }
        [HttpGet]
        [Route("GetUser/{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var users = await _userBusiness.Get(userName);
            return Ok(users);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add([FromBody] UserDTO user)
        {
            await _userBusiness.Add(user);
            return Ok("Inserted successfully");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO user)
        {
            await _userBusiness.Update(user);
            return Ok("Inserted successfully");
        }
    }
}
