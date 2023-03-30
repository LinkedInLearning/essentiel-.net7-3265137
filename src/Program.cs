using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.Versioning;

namespace media_06
{
  [SupportedOSPlatform("windows")]
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        var contenu = Directory.GetFiles("c:/windows").GetEnumerator();
        using Font police = new(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
        using StringFormat aDroite = new() { Alignment = StringAlignment.Far };
        using PrintDocument pd = new();

        pd.PrintPage += new PrintPageEventHandler((o, e) =>
        {
          if(e.Graphics is null) return;

          var g = e.Graphics;
          var hauteurLigne = (int)police.GetHeight(g) + 2;
          var lignesParPage = e.MarginBounds.Height / hauteurLigne;
          Rectangle ligne = new(
              e.MarginBounds.Left, e.MarginBounds.Top,
              e.MarginBounds.Width, hauteurLigne
          );

          g.DrawString("Fichier", police, Brushes.Black, ligne.Left, ligne.Top);
          g.DrawString("Taille", police, Brushes.Black, ligne.Right, ligne.Top, aDroite);
          g.DrawLine(Pens.Black, ligne.Left, ligne.Bottom, ligne.Right, ligne.Bottom);
          for (int i = 0; i < lignesParPage && (e.HasMorePages = contenu.MoveNext()); i++)
          {
            var fichier = contenu.Current.ToString();
            
            if(fichier is null) continue;

            var infos = new FileInfo(fichier);

            ligne.Offset(0, hauteurLigne);
            if ((i & 1) != 0)
            {
              g.FillRectangle(Brushes.LightGray, ligne);
            }
            g.DrawString(infos.Name, police, Brushes.Black, ligne.Left, ligne.Top);
            g.DrawString($"{infos.Length}", police, Brushes.Black, ligne.Right, ligne.Top, aDroite);
          }
          g.DrawLine(Pens.Black, ligne.Left, ligne.Bottom, ligne.Right, ligne.Bottom);
        });
        pd.Print();
      }
      catch (Exception e)
      {
        Console.Error.WriteLine(e.Message);
      }
    }
  }
}
