using System;
using System.Linq;

namespace Alexandrie.v1.Commandes
{
  public interface IBibliotheque
  {
    void CréerAdhérent (Adhérent adhérent);
    void DémarrerEmprunt (Emprunt emprunt);
    void CloreEmprunt (Emprunt emprunt);
  }
}

