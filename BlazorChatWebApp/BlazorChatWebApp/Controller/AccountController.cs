﻿using BlazorChatWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorChatWebApp.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using BlazorChatWebApp.Data.Entities;
using System.Security.Claims;

namespace BlazorChatWebApp.Controller
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly TokenService _tokenService;

    public AccountController(ApplicationDbContext context, TokenService tokenService)
    {
      _context = context;
      _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto, CancellationToken cancellationToken)
    {
      var duLieuNguoiDung = await _context.Users
        .AsNoTracking()
        .AnyAsync(x => x.Username == dto.Username, cancellationToken);

      if(!duLieuNguoiDung)
      {
        return BadRequest($"{nameof(dto.Username)} da ton tai ");
      }

      var user = new User
      {
        Name = dto.Name,
        AddOn = DateTime.Now,
        Username = dto.Username,
        Password = dto.Password // cần mã hóa để bảo mật
      };

      await _context.Users.AddAsync(user, cancellationToken);
      await _context.SaveChangesAsync(cancellationToken);

      //Register


      //return Ok(new { message = "tai khoan dang ky thanh cong" });
      return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken)
    {
      var user = await _context.Users
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Username == dto.Username && x.Password == dto.Password, cancellationToken);
      //if (user == null)
      //{
      //  return BadRequest("tai khoan hoac mat khau khong dung");
      //}

      if (user is null)
      {
        return BadRequest("tai khoan hoac mat khau khong dung");
      }

      return Ok(GenerateToken(user));
    }

    //private GenerateToken(User user)
    //{
    //  var token = _tokenService.GenerateJWT(user);
    //  return new AuthResponseDto(new UserDto(user.Id, user.Name), token);
    //}

    private AuthResponseDto GenerateToken(User user)
    {
      var token = _tokenService.GenerateJWT(user);
      return new AuthResponseDto(user.Name, token);
    }
  }
}
