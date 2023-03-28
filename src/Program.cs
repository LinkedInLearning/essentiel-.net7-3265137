using System;
using System.Text;

namespace info_01
{
  class Program
  {
    static void Main(string[] args)
    {
      var liste = """
                pique
                cœur
                trèfle
                carreau
                """;

      foreach (var couleur in liste.ToUpper().Split("\r\n"))
      {
        Console.WriteLine($"| {couleur.PadRight(10)} |");
      }
      
      StringBuilder text = new("Nombres");
      var sep = " : ";

      for (var i = 1; i <= 7; i++)
      {
        text.Append(sep);
        text.Append(i);
        sep = ", ";
      }
      Console.WriteLine(text.ToString());
      text.Insert(7, " de 1 à 7");
      Console.WriteLine(text.ToString());
    }
  }
}
