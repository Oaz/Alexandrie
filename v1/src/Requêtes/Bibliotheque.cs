using System;
using System.Collections.Generic;
using System.Linq;

namespace Alexandrie.v1.Requêtes
{
  public class Bibliotheque : IBibliotheque
  {
    public Bibliotheque (Persistance persistance)
    {
      persistance_ = persistance;
    }
    Persistance persistance_;
    
    public IEnumerable<RésuméAdherent> RechercheAdherents (string recherche)
    {
      return from adhérent in persistance_.Adhérents
        where adhérent.Nom == recherche || adhérent.Ville == recherche
        select new RésuméAdherent {
          Numéro = adhérent.Numéro,
          Nom = adhérent.Nom
        };
    }
    
    public IEnumerable<RésuméEmprunt> RechercheEmpruntsEnCours (string recherche)
    {
      return
        from emprunt in persistance_.Emprunts
        where emprunt.Actif
        from adhérent in persistance_.Adhérents
        where adhérent.Numéro == emprunt.NuméroAdhérent
        where emprunt.Description.Contains (recherche) || adhérent.Nom == recherche
        select new RésuméEmprunt {
          Identifiant = emprunt.Identifiant,
          Description = emprunt.Description,
          NomAdhérent = adhérent.Nom
        };
    }
  }
}

