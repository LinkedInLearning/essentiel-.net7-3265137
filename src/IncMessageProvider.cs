using Microsoft.Extensions.Configuration;

namespace ctrl_02
{
  public class IncMessageService : IMessageProvider
  {
    private int inc = 0;
    private string Prefix { get; init; } = "Ok";
    public IncMessageService()
    {
      
    }
    public string NextMessage
    {
      get
      {
        inc++;
        return $"{Prefix} ({inc})";
      }
    }
  }
}