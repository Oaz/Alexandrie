using System;
using System.Linq;
using System.Collections.Generic;

namespace Alexandrie.v2.Requêtes
{
  public interface IBibliotheque
  {
    IEnumerable<Modèle.Adhérent> RechercheAdherents (string recherche);
    IEnumerable<Modèle.Emprunt> RechercheEmpruntsEnCours (string recherche);
  }
}

