using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ctrl_04
{
  class Program
  {
    static void Main(string[] args)
    {
      Produit p = new()
      {
        Ref = "",
        Nom = "Tong",
        Description = null,
        Prix = -2.3,
        PageProduit = "https://site.example/AM123",
        CourrielSupport = "supportsite.example",
        Retrait = DateTime.Now
      };
      ValidationContext validationProduit = new(p);
      List<ValidationResult> résultats = new();

      if (Validator.TryValidateObject(p, validationProduit, résultats, true))
      {
        Console.WriteLine("Fiche produit correctement remplie.");
      }
      else
      {
        Console.Error.WriteLine("Erreurs dans la fiche produit :");
        foreach (var res in résultats)
        {
          Console.Error.WriteLine($"- {res.MemberNames.First()} : {res.ErrorMessage}");
        }
      }
    }
  }
}
