namespace info_07
{
  class Program
  {
    static void Main(string[] args)
    {
      DateTimeOffset début = new DateTimeOffset(year: 2023, month: 08, day: 10, hour: 12, 0, 0, offset: TimeSpan.FromHours(1));
      TimeSpan       durée = new TimeSpan(hours: 1, minutes: 30, 0);
      DateTimeOffset fin   = début + durée;
      TimeSpan       attente = début - DateTimeOffset.Now;

      Console.WriteLine($"RDV {début:f} - {fin:F} dans {attente:dd\\jhh\\hmm}");
      Console.WriteLine($"RDV {début:g} - {fin:G} dans {attente:g}"); // DateTime : s
      Console.WriteLine($"RDV le {début:d} à {début:t} jusqu'à {fin:T} dans {attente:G}");

      var rdv = new Rdv(début, durée, "Réunion");
      List<Rdv> occurrences = new() { rdv };

      for (var i = 1; i < 10; i++)
      {
        occurrences.Add(rdv with { Début = début + TimeSpan.FromDays(i * 7) });
      }
      foreach (var occ in occurrences)
      {
        Console.WriteLine(occ);
      }
    }
    public record Rdv(DateTimeOffset Début, TimeSpan Durée, string Titre)
    {
      public DateTimeOffset Fin => Début + Durée;
      public TimeSpan Attente => Début - DateTimeOffset.Now;
    }
  }
}
