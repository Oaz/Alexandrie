using System;
using System.Linq;

namespace Alexandrie.v1.Commandes
{
  public class Bibliotheque : IBibliotheque
  {
    public Bibliotheque (Persistance persistance)
    {
      persistance_ = persistance;
    }
    Persistance persistance_;

    public void CréerAdhérent (Adhérent adhérent)
    {
      if (adhérent.EstEtranger)
        throw new ApplicationException ("Opération refusée");
      persistance_.Adhérents.Add (new DonnéesAdhérent {
        Numéro = persistance_.Adhérents.Count+1,
        Nom = adhérent.Nom,
        Ville = adhérent.Ville
      });
    }
    
    public void DémarrerEmprunt (Emprunt emprunt)
    {
      persistance_.Emprunts.Add (new DonnéesEmprunt {
        Identifiant = persistance_.Emprunts.Count+1,
        NuméroAdhérent = emprunt.NuméroAdhérent,
        Description = emprunt.Description,
        DateDébut = emprunt.DateDébut,
        DateLimite = emprunt.DateLimite,
        Actif = true
      });
    }
    
    public void CloreEmprunt (Emprunt emprunt)
    {
      persistance_.Emprunts
      .First (d => d.Identifiant == emprunt.Identifiant)
      .Actif = false;
    }
  }
}

