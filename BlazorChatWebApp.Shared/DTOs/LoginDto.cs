using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChatWebApp.Shared.DTOs
{
  public class LoginDto
  {
    public string Username { get; set; }
    [Required, MaxLength(25), DataType(DataType.Password)]
    public string Password { get; set; }
  }
}
