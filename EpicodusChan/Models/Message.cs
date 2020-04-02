using System.ComponentModel.DataAnnotations;

namespace EpicodusChan.Models
{
  public class Message
  {
    public int MessageId { get; set; }

    public int GroupId { get; set; }

    public string Title { get; set; }
    
    public string UserName { get; set; }

    public string Entry { get; set; }

    public string Date { get; set; }
    
  }
}