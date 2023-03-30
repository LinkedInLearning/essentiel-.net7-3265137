namespace media_02;

using System.Media;
using System.Runtime.Versioning;

[SupportedOSPlatform("windows")]
class Program
{
  static void Main(string[] args)
  {
    using SoundPlayer player = new("son.wav");

    player.PlaySync();
    SystemSounds.Asterisk.Play();
    Console.WriteLine("Hello World!");
  }
}
