using System;

namespace Alexandrie.v1.Commandes
{
  public class Adhérent
  {
    public long Numéro;
    public string Nom;
    public string Ville;
    
    public bool EstEtranger {
      get {
        return Ville == "Paris";
      }
    }
  }
}

