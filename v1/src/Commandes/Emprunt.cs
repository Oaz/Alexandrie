using System;

namespace Alexandrie.v1.Commandes
{
  public class Emprunt
  {
    public long Identifiant;
    public long NuméroAdhérent;
    public string Description;
    public DateTime DateDébut;
    
    public DateTime DateLimite {
      get {
        return DateDébut.AddMonths (1);
      }
    }
  }
}

