using System;

namespace Alexandrie.v2.Commandes
{
  public class Adhérent : Modèle.Adhérent, Identification.Adhérent
  {
    public string Nom { get; set; }
    public string Ville { get; set; }
    
    public bool EstEtranger {
      get {
        return Ville == "Paris";
      }
    }
    
    public long Numéro { get; internal set; }
  }
}

