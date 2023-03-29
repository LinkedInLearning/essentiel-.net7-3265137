namespace media_03;

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;

class Program
{
  [SupportedOSPlatform("windows")]
  static void Main(string[] args)
  {
    using var img = Image.FromFile("chat.jpeg");

    img.RotateFlip(RotateFlipType.RotateNoneFlipX);

    using var vignette = img.GetThumbnailImage(
        img.Width / 10,
        img.Height / 10,
        () => false,
        IntPtr.Zero
    );
    vignette.Save("vignette-chat.png", ImageFormat.Png);
  }
}
