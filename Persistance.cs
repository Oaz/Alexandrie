using System;
using System.Collections.Generic;

namespace Alexandrie
{
  /// <summary>
  /// Cette classe simule une persistance de données avec des collections en mémoire
  /// </summary>
  public class Persistance
  {
    public Persistance ()
    {
      Adhérents = new List<DonnéesAdhérent> ();
      Emprunts = new List<DonnéesEmprunt> ();
    }
    
    public IList<DonnéesAdhérent> Adhérents { get; private set; }
    public IList<DonnéesEmprunt> Emprunts { get; private set; }
  }
  
  public class DonnéesAdhérent
  {
    public long Numéro;
    public string Nom;
    public string Ville;
  }
  
  public class DonnéesEmprunt
  {
    public long Identifiant;
    public long NuméroAdhérent;
    public string Description;
    public DateTime DateDébut;
    public DateTime DateLimite;
    public bool Actif;
  }
}

