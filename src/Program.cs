using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;

namespace media_04
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

            rcCadre.Inflate(-1, -1);

            using var profil = new Bitmap(rcCadre.Width, rcCadre.Height, gCadre);
            using var gProfil = Graphics.FromImage(profil);

            gProfil.DrawImage(vignette, 0, 0, rcCadre, GraphicsUnit.Pixel);
            profil.Save("profil.jpg", ImageFormat.Jpeg);
        }
    }
}
