using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChatWebApp.Shared.DTOs
{
  public class UserDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsOnline { get; set; }
    public bool IsSelected { get; set; }

    public UserDto(int id, string name, bool isOnline = false)
    {
      Id = id;
      Name = name;
      IsOnline = isOnline;
    }
  }
}
