using System;

namespace Alexandrie.v2.Requêtes
{
  public class RésuméEmprunt : Modèle.Emprunt, Identification.Emprunt
  {
    public Modèle.Adhérent Emprunteur { get { return emprunteur_; } set { throw NI (); } }
    public string Description { get { return description_; } set { throw NI (); } }
    public DateTime DateDébut { get { throw NI (); } set { throw NI (); } }
    public DateTime DateLimite { get { throw NI (); } }
    public long Identifiant { get; internal set; }
    
    internal RésuméAdherent emprunteur_;
    internal string description_;
    
    private Exception NI ()
    {
      return new NotImplementedException ();
    }
  }
}

