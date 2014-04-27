using System;

namespace Alexandrie.v2.Modèle
{
  public interface Emprunt
  {
    Adhérent Emprunteur { get; set; }
    string Description { get; set; }
    DateTime DateDébut { get; set; }
    DateTime DateLimite { get; }
  }
}

