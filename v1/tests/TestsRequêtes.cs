using System;
using NUnit.Framework;
using System.Linq;

namespace Alexandrie.v1.Tests
{
  [TestFixture]
  public class TestsRequêtes
  {
    Persistance persistance_;
    Requêtes.IBibliotheque bibliotheque_;
    
    [SetUp]
    public void Init ()
    {
      persistance_ = new Persistance ();
      bibliotheque_ = new Requêtes.Bibliotheque (persistance_);
      persistance_.Adhérents.Add (new DonnéesAdhérent {
        Numéro = 23,
        Nom = "Dupont",
        Ville = "Toulouse"
      });
      persistance_.Adhérents.Add (new DonnéesAdhérent {
        Numéro = 48,
        Nom = "Martin",
        Ville = "Marseille"
      });
      persistance_.Emprunts.Add (new DonnéesEmprunt {
        Identifiant = 1111,
        NuméroAdhérent = 48,
        Description = "Les 3 mousquetaires",
        Actif = true
      });
      persistance_.Emprunts.Add (new DonnéesEmprunt {
        Identifiant = 2222,
        NuméroAdhérent = 48,
        Description = "Les misérables",
        Actif = false
      });
      persistance_.Emprunts.Add (new DonnéesEmprunt {
        Identifiant = 3333,
        NuméroAdhérent = 23,
        Description = "Le Retour de Martin Guerre",
        Actif = true
      });
    }
    
    [Test]
    public void RechercheAdhérentsParVille ()
    {
      var résultat = bibliotheque_.RechercheAdherents ("Toulouse");
      Assert.That (résultat.Count (), Is.EqualTo (1));
      Assert.That (résultat.First ().Numéro, Is.EqualTo (23));
      Assert.That (résultat.First ().Nom, Is.EqualTo ("Dupont"));
    }
    
    [Test]
    public void RechercheAdhérentsParNom ()
    {
      var résultat = bibliotheque_.RechercheAdherents ("Martin");
      Assert.That (résultat.Count (), Is.EqualTo (1));
      Assert.That (résultat.First ().Numéro, Is.EqualTo (48));
      Assert.That (résultat.First ().Nom, Is.EqualTo ("Martin"));
    }
    
    [Test]
    public void RechercheEmpruntsActifsParDescription ()
    {
      var résultat = bibliotheque_.RechercheEmpruntsEnCours ("Les ");
      Assert.That (résultat.Count (), Is.EqualTo (1));
      Assert.That (résultat.First ().Identifiant, Is.EqualTo (1111));
      Assert.That (résultat.First ().Description, Is.EqualTo ("Les 3 mousquetaires"));
      Assert.That (résultat.First ().NomAdhérent, Is.EqualTo ("Martin"));
    }
    
    [Test]
    public void RechercheEmpruntsActifsParNomAdherent ()
    {
      var résultat = bibliotheque_.RechercheEmpruntsEnCours ("Dupont");
      Assert.That (résultat.Count (), Is.EqualTo (1));
      Assert.That (résultat.First ().Identifiant, Is.EqualTo (3333));
      Assert.That (résultat.First ().Description, Is.EqualTo ("Le Retour de Martin Guerre"));
      Assert.That (résultat.First ().NomAdhérent, Is.EqualTo ("Dupont"));
    }
    
    [Test]
    public void RechercheEmpruntsActifsParDescriptionOuNomAdherent ()
    {
      var résultat = bibliotheque_.RechercheEmpruntsEnCours ("Martin");
      Assert.That (résultat.Count (), Is.EqualTo (2));
      Assert.That (résultat.Select (r => r.Identifiant), Is.EquivalentTo (new long[] {1111,3333}));
    }
  }
}

