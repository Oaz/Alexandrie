using System;

namespace Alexandrie.v2.Modèle
{
  public interface Adhérent
  {
    string Nom { get; set; }
    string Ville { get; set; }
    bool EstEtranger { get; }
  }
}

