﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaqamliAvlod.Application.Utils;
using RaqamliAvlod.Infrastructure.Service.Dtos;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Common;
using RaqamliAvlod.Infrastructure.Service.Interfaces.Users;

namespace RaqamliAvlod.Api.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IIdentityHelperService _identityHelperService;

    public UsersController(IUserService userService, IIdentityHelperService identityHelperService)
    {
        _userService = userService;
        _identityHelperService = identityHelperService;
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _userService.GetAllAsync(@params));

    [HttpGet("{userId}"), AllowAnonymous]
    public async Task<IActionResult> GetIdAsync(long userId)
        => Ok(await _userService.GetIdAsync(userId));

    [HttpGet("username"), AllowAnonymous]
    public async Task<IActionResult> GetUsernameAsync(string username)
        => Ok(await _userService.GetUsernameAsync(username));

    [HttpPut, Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> UpdateAsync([FromForm] UserUpdateDto userUpdateViewModel)
        => Ok(await _userService.UpdateAsync(_identityHelperService.GetUserId(), userUpdateViewModel));

    [HttpDelete("{userId}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long userId)
        => Ok(await _userService.DeleteAsync(userId));

    [HttpPost("images/upload"), Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> ImageUpdateAsync(IFormFile imageUpload)
        => Ok(await _userService.ImageUpdateAsync(_identityHelperService.GetUserId(), imageUpload));

    [HttpGet("{userId}/submuissions")]
    public async Task<IActionResult> GetSubmissionsAsync(long userId, [FromQuery] PaginationParams @params)
    {
        return Ok();
    }
}
