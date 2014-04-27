using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Alexandrie.v1.Tests
{
  [TestFixture]
  public class TestsCommandes
  {
    Persistance persistance_;
    Commandes.IBibliotheque bibliotheque_;
    
    [SetUp]
    public void Init ()
    {
      persistance_ = new Persistance ();
      bibliotheque_ = new Commandes.Bibliotheque (persistance_);
    }
    
    [Test]
    public void CréationAdhérent ()
    {
      var adhérent = new Commandes.Adhérent {
        Nom = "Dupont",
        Ville = "Toulouse"
      };
      bibliotheque_.CréerAdhérent (adhérent);
      var données = persistance_.Adhérents.First ();
      Assert.That (données.Numéro, Is.GreaterThan (0));
      Assert.That (données.Nom, Is.EqualTo ("Dupont"));
      Assert.That (données.Ville, Is.EqualTo ("Toulouse"));
    }
    
    [Test]
    [ExpectedException(ExpectedMessage="Opération refusée")]
    public void OnNepeutPasCréerUnAdhérentEtranger ()
    {
      var adhérent = new Commandes.Adhérent {
        Nom = "Dupont",
        Ville = "Paris"
      };
      bibliotheque_.CréerAdhérent (adhérent);
    }
    
    [Test]
    public void EmprunterUnLivre ()
    {
      var emprunt = new Commandes.Emprunt {
        NuméroAdhérent = 23,
        Description = "Un livre",
        DateDébut = new DateTime(2014, 04, 22)
      };
      bibliotheque_.DémarrerEmprunt (emprunt);
      var données = persistance_.Emprunts.First ();
      Assert.That (données.Identifiant, Is.GreaterThan (0));
      Assert.That (données.NuméroAdhérent, Is.EqualTo (23));
      Assert.That (données.Description, Is.EqualTo ("Un livre"));
      Assert.That (données.DateDébut, Is.EqualTo (new DateTime (2014, 04, 22)));
      Assert.That (données.DateLimite, Is.EqualTo (new DateTime (2014, 05, 22)));
      Assert.That (données.Actif, Is.True);
    }
    
    [Test]
    public void RendreUnLivre ()
    {
      persistance_.Emprunts.Add (new DonnéesEmprunt {
        Identifiant = 1234,
        Actif = true
      });
      var emprunt = new Commandes.Emprunt {
        Identifiant = 1234
      };
      bibliotheque_.CloreEmprunt (emprunt);
      var données = persistance_.Emprunts.First ();
      Assert.That (données.Actif, Is.False);
    }
  }
}

