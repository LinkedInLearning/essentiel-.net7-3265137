using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;

namespace media_05
{
  class Program
  {
    [SupportedOSPlatform("windows")]
    static void Main(string[] args)
    {
      using var vignette = Image.FromFile("vignette-chat.png");
      using var gCadre = Graphics.FromImage(vignette);
      Rectangle rcCadre = new(x: 295, y: 7, width: 270, height: 270);

      gCadre.DrawRectangle(Pens.Red, rcCadre);

      vignette.Save("cadre-chat.png", ImageFormat.Png);
    }
  }
}
