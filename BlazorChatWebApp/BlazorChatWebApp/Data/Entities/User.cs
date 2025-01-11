using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorChatWebApp.Data.Entities
{
  [Table("User")]
  public class User
  {
    [Key]
    public int Id { get; set; }
    [Required, Unicode(false), MaxLength(50)]
    public string Name { get; set; }
    public DateTime AddOn { get; set; }
    [Required, Unicode(false), MaxLength(25)]
    public string Username { get; set; }
    [Required, MaxLength(25)]
    public string Password { get; set; }
  }
}
