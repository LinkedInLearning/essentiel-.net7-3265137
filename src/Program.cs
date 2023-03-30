using System.Drawing;
using System.Drawing.Drawing2D;
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
      using Pen crayon = new(Brushes.Red, 1) { DashStyle = DashStyle.Dash };
      Rectangle rcCadre = new(x: 295, y: 7, width: 270, height: 270);
      using Font police = new(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
      using StringFormat centré = new() { Alignment = StringAlignment.Center };

      gCadre.DrawRectangle(crayon, rcCadre);

      rcCadre.Y += rcCadre.Height;
      gCadre.DrawString("Zone de découpage de l'image", police, Brushes.Red, rcCadre, centré);
      vignette.Save("cadre-chat.png", ImageFormat.Png);
    }
  }
}
