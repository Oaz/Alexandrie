using System;
using System.Linq;

namespace Alexandrie.v1
{
  public class HistoiresUtilisateur
  {
    Requêtes.Bibliotheque requêtes_;
    Commandes.Bibliotheque commandes_;
    
    public void UnAdhérentVientEmprunter ()
    {
      var adhérents = requêtes_.RechercheAdherents ("Dupont");
      var adhérentTrouvé = adhérents.ElementAt (12);
      var emprunt = new Commandes.Emprunt
      {
        NuméroAdhérent = adhérentTrouvé.Numéro,
        Description = "Un livre",
        DateDébut = DateTime.Now
      };
      commandes_.DémarrerEmprunt (emprunt);
    }
    
    public void UnAdhérentVientRapporter ()
    {
      var emprunts = requêtes_.RechercheEmpruntsEnCours ("Un livre");
      var empruntTrouvé = emprunts.ElementAt (5);
      var emprunt = new Commandes.Emprunt
      {
        Identifiant = empruntTrouvé.Identifiant
      };
      commandes_.CloreEmprunt (emprunt);
    }
  }
}

