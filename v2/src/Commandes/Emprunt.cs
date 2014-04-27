using System;

namespace Alexandrie.v2.Commandes
{
  public class Emprunt : Modèle.Emprunt, Identification.Emprunt
  {
    public Modèle.Adhérent Emprunteur { get; set; }
    public string Description { get; set; }
    public DateTime DateDébut { get; set; }
    
    public DateTime DateLimite {
      get {
        return DateDébut.AddMonths (1);
      }
    }
    
    public long Identifiant { get; internal set; }
  }
}

