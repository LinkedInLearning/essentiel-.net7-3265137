using System;
using System.IO;
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
        var contenu = Directory.GetFiles("c:/windows");

        foreach (var fichier in contenu)
        {
          var infos = new FileInfo(fichier);

          Console.WriteLine($"{infos.Name,-100}{infos.Length,10}");
        }
      }
      catch (Exception e)
      {
        Console.Error.WriteLine(e.Message);
      }
    }
  }
}
