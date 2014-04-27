using System;

namespace Alexandrie.v2.Requêtes
{
  public class RésuméAdherent : Modèle.Adhérent, Identification.Adhérent
  {
    public string Nom { get { return nom_; } set { throw NI (); } }
    public string Ville { get { throw NI (); } set { throw NI (); } }
    public bool EstEtranger { get { throw NI (); } }
    public long Numéro { get; internal set; }

    internal string nom_;
    
    private Exception NI ()
    {
      return new NotImplementedException ();
    }
  }
}

