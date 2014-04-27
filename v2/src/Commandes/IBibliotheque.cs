using System;
using System.Linq;
using System.Collections.Generic;

namespace Alexandrie.v2.Commandes
{
  public interface IBibliotheque
  {
    Modèle.Adhérent NouvelAdhérent { get; }
    Modèle.Emprunt NouvelEmprunt { get; }
    void CréerAdhérent (Modèle.Adhérent adhérent);
    void DémarrerEmprunt (Modèle.Emprunt emprunt);
    void CloreEmprunt (Modèle.Emprunt emprunt);
  }
}

