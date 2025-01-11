using BlazorChatWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorChatWebApp.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using BlazorChatWebApp.Data.Entities;

namespace BlazorChatWebApp.Controller
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
      _context = context;
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

      return Ok(user);
    }
  }
}
