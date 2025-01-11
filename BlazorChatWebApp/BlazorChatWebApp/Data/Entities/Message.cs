using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorChatWebApp.Data.Entities
{
  [Table("Message")]
  public class Message
  {
    [Key]
    public long Id { get; set; }
    //id người gửi và id người nhận
    public int FromId { get; set; }
    public int ToId { get; set; }
    [Required]
    public string Content { get; set; }

    // đã gửi tin nhắn đó vào ngày tháng năm giờ phút giây nào
    public DateTime SentOn { get; set; }
    
    public virtual User FromUser { get; set; }
    public virtual User ToUser { get; set; }

  }
}
