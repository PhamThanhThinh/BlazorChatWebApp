using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChatWebApp.Shared.DTOs
{
  public record AuthResponseDto(string Name, string Token);
}
