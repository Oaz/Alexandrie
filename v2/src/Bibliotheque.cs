using System;
using System.Linq;
using System.Collections.Generic;

namespace Alexandrie.v2
{
  public class Bibliotheque : Commandes.IBibliotheque, Requêtes.IBibliotheque
  {
    public Bibliotheque (Persistance persistance)
    {
      persistance_ = persistance;
    }
    Persistance persistance_;

    public Modèle.Adhérent NouvelAdhérent {
      get {
        return new Commandes.Adhérent ();
      }
    }

    public Modèle.Emprunt NouvelEmprunt {
      get {
        return new Commandes.Emprunt ();
      }
    }
    
    public void CréerAdhérent (Modèle.Adhérent adhérent)
    {
      if (adhérent.EstEtranger)
        throw new ApplicationException ("Opération refusée");
      persistance_.Adhérents.Add (new DonnéesAdhérent {
        Numéro = persistance_.Adhérents.Count+1,
        Nom = adhérent.Nom,
        Ville = adhérent.Ville
      });
    }

    public void DémarrerEmprunt (Modèle.Emprunt emprunt)
    {
      persistance_.Emprunts.Add (new DonnéesEmprunt {
        Identifiant = persistance_.Emprunts.Count+1,
        NuméroAdhérent = (emprunt.Emprunteur as Identification.Adhérent).Numéro,
        Description = emprunt.Description,
        DateDébut = emprunt.DateDébut,
        DateLimite = emprunt.DateLimite,
        Actif = true
      });
    }

    public void CloreEmprunt (Modèle.Emprunt emprunt)
    {
      persistance_.Emprunts
        .First (d => d.Identifiant == (emprunt as Identification.Emprunt).Identifiant)
        .Actif = false;
    }

    public IEnumerable<Modèle.Adhérent> RechercheAdherents (string recherche)
    {
      return from adhérent in persistance_.Adhérents
        where adhérent.Nom == recherche || adhérent.Ville == recherche
      select new Requêtes.RésuméAdherent {
        Numéro = adhérent.Numéro,
        nom_ = adhérent.Nom
      };
    }

    public IEnumerable<Modèle.Emprunt> RechercheEmpruntsEnCours (string recherche)
    {
      return
        from emprunt in persistance_.Emprunts
          where emprunt.Actif
          from adhérent in persistance_.Adhérents
          where adhérent.Numéro == emprunt.NuméroAdhérent
          where emprunt.Description.Contains (recherche) || adhérent.Nom == recherche
          let emprunteur = new Requêtes.RésuméAdherent {
                nom_ = adhérent.Nom,
                Numéro = adhérent.Numéro
                }
          select new Requêtes.RésuméEmprunt {
                  Identifiant = emprunt.Identifiant,
                  description_ = emprunt.Description,
                  emprunteur_ = emprunteur
                };
    }
  }
}

