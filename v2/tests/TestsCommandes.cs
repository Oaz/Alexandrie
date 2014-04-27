using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Alexandrie.v2.Tests
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
      bibliotheque_ = new Bibliotheque (persistance_);
    }
    
    [Test]
    public void CréationAdhérent ()
    {
      var adhérent = bibliotheque_.NouvelAdhérent;
      adhérent.Nom = "Dupont";
      adhérent.Ville = "Toulouse";
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
      var adhérent = bibliotheque_.NouvelAdhérent;
      adhérent.Nom = "Dupont";
      adhérent.Ville = "Paris";
      bibliotheque_.CréerAdhérent (adhérent);
    }
    
    [Test]
    public void EmprunterUnLivre ()
    {
      var adhérent = bibliotheque_.NouvelAdhérent;
      (adhérent as Commandes.Adhérent).Numéro = 23;
      var emprunt = bibliotheque_.NouvelEmprunt;
      emprunt.Emprunteur = adhérent;
      emprunt.Description = "Un livre";
      emprunt.DateDébut = new DateTime (2014, 04, 22);
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
      var emprunt = bibliotheque_.NouvelEmprunt;
      (emprunt as Commandes.Emprunt).Identifiant = 1234;
      bibliotheque_.CloreEmprunt (emprunt);
      var données = persistance_.Emprunts.First ();
      Assert.That (données.Actif, Is.False);
    }
  }
}

