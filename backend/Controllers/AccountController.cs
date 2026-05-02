using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using schoolApi.DTOs.AccountDtos;
using schoolApi.Interfaces;
using schoolApi.Models;

namespace schoolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<AppUser> _signInManage;
    public AccountController
    (UserManager<AppUser> userManager, ITokenService tokenService,
    SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManage = signInManager;
    }

    [HttpPost("register/teacher")]
    public async Task<IActionResult> RegisterTeacher([FromBody] RegisterDTO register)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(register.Password))
                return BadRequest("Password is empty");

            var appUser = new AppUser
            {
                UserName = register.Username,
                Email = register.Email,
                EmailConfirmed = register.EmailConfirmed,
            };

            var createdUser = await _userManager.CreateAsync(appUser, register.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager
                .AddToRoleAsync(appUser, "Teacher");

                if (roleResult.Succeeded)
                    return Ok(
                        new NewUserDTO
                        {
                            Username = appUser.Email,
                            Email = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        });
                else
                    return BadRequest(new
                    {
                        StatusCode = StatusCode(500),
                        ErrorMessage = "Teacher was not created.",
                        Error = createdUser.Errors
                    });
            }

            else
            {
                return StatusCode(500, createdUser.Errors);
            }

        }

        catch (Exception e)
        {
            return StatusCode(500, e);
        }

    }

    [HttpPost("register/student")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterDTO register)
    {
        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(register.Password))
                return BadRequest("Password is empty.");

            var appUser = new AppUser
            {
                UserName = register.Username,
                Email = register.Email,
                EmailConfirmed = register.EmailConfirmed
            };

            var createdUser = await _userManager.CreateAsync(appUser, register.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "Student");

                if (roleResult.Succeeded)
                    return Ok(new NewUserDTO
                    {
                        Username = appUser.UserName,
                        Email = appUser.Email,
                        Token = _tokenService.CreateToken(appUser)
                    });

                else
                    return BadRequest(
                        new
                        {
                            StatusCode = StatusCode(500),
                            ErrorMessage = "Student was not created.",
                            Error = createdUser.Errors
                        });
            }

            else
                return StatusCode(500, createdUser.Errors);

        }

        catch (Exception e)
        {
            return StatusCode(500, e);
        }

    }

    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDTO register)
    {
        try
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrWhiteSpace(register.Password))
                return BadRequest("Password is empty.");

            var appUser = new AppUser
            {
                UserName = register.Username,
                Email = register.Email,
                EmailConfirmed = register.EmailConfirmed
            };

            var CreatedUser = await _userManager.CreateAsync(appUser, register.Password);

            if (CreatedUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "Admin");
                if (roleResult.Succeeded)
                    return Ok(new NewUserDTO
                    {
                        Username = appUser.UserName,
                        Email = appUser.Email,
                        Token = _tokenService.CreateToken(appUser)
                    });

                else
                    return BadRequest(new
                    {
                        StatusCode = StatusCode(500),
                        ErrorMessage = "Admin was not created.",
                        Error = CreatedUser.Errors
                    });

            }

            else
            {
                return StatusCode(500, CreatedUser.Errors);
            }

        }

        catch (Exception e)
        {
            return StatusCode(500, e);
        }

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users
        .FirstOrDefaultAsync
        (u => u.UserName == loginRequest.Username.ToLower());

        if (user == null)
            return Unauthorized("Username not found and/or password incorrect.");

        var result = await _signInManage
        .CheckPasswordSignInAsync(user, loginRequest.Password, false);

        if (!result.Succeeded)
            return Unauthorized("Username not found and/or password incorrect.");

        return Ok(
           new NewUserDTO
           {
               Username = user.UserName,
               Email = user.Email,
               Token = _tokenService.CreateToken(user)
           });

    }

}
