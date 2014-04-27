using System;
using System.Linq;

namespace Alexandrie.v2
{
  public class HistoiresUtilisateur
  {
    Bibliotheque bibliotheque_;
    
    public void UnAdhérentVientEmprunter ()
    {
      var adhérents = bibliotheque_.RechercheAdherents ("Dupont");
      var adhérentTrouvé = adhérents.ElementAt (12);
      var emprunt = bibliotheque_.NouvelEmprunt;
      emprunt.Emprunteur = adhérentTrouvé;
      emprunt.Description = "Un livre";
      emprunt.DateDébut = DateTime.Now;
      bibliotheque_.DémarrerEmprunt (emprunt);
    }
    
    public void UnAdhérentVientRapporter ()
    {
      var emprunts = bibliotheque_.RechercheEmpruntsEnCours ("Un livre");
      var empruntTrouvé = emprunts.ElementAt (5);
      bibliotheque_.CloreEmprunt (empruntTrouvé);
    }
  }
}

