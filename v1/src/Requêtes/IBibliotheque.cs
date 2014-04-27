using System;
using System.Collections.Generic;
using System.Linq;

namespace Alexandrie.v1.Requêtes
{
  public interface IBibliotheque
  {  
    IEnumerable<RésuméAdherent> RechercheAdherents (string recherche);
    IEnumerable<RésuméEmprunt> RechercheEmpruntsEnCours (string recherche);
  }
}

