using System;
using Microsoft.AspNetCore.Http;

namespace com_02web.Models
{
  public class FormulaireViewModel
  {
    public string Titre { get; set; }

    public IFormFile Photo { get; set; }
  }
}
