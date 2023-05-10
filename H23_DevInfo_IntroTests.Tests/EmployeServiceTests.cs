using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H23_DevInfo_IntroTests.Tests
{
    [TestClass]
    public class EmployeServiceTests
    {
        private EmployeService service;


        [TestInitialize]
        public void Initialiser()
        {
            service = new EmployeService(new DateServicePourLesTests());
        }


        [TestMethod]
        public void AjouterEmploye_AjouterLeMemeEmployeEnDouble_RetourneUneSeuleOccurrenceDeCetEmploye()
        {
            // Arrange
            var employe = new Employe { Id = 1, Nom = "Doe", Prenom = "John" };

            // Act
            service.AjouterEmploye(employe);
            service.AjouterEmploye(employe);

            var listeEmployes = service.ObtenirEmployes();


            // Assert
            Assert.AreEqual(1, listeEmployes.Where(e => e.Id == employe.Id).Count());
        }


        [TestMethod]
        public void ObtenirLaListeDesEmployesDontCestLanniversaireAujourdhui_10Mai_RetourneTroisEmployes()
        {
            // Arrange
            //CreerListeEmployes();
            service.ObtenirEmployesPourTests();

            // Act
            var listeObtenue = service.ObtenirLaListeDesEmployesDontCestLanniversaireAujourdhui();

            // Assert
            Assert.AreEqual(3, listeObtenue.Count());
        }


        private void CreerListeEmployes()
        {
            var liste = new List<Employe>
            {
                new Employe { Id = 1, Nom = "Smith", Prenom = "John", DateNaissance = new DateTime(1978, 01, 12) },
                new Employe { Id = 2, Nom = "Johnson", Prenom = "Emma", DateNaissance = new DateTime(1979, 01, 12) },
                new Employe { Id = 3, Nom = "Williams", Prenom = "Sophie", DateNaissance = new DateTime(1980, 01, 12) },
                new Employe { Id = 4, Nom = "Brown", Prenom = "Oliver", DateNaissance = new DateTime(1981, 01, 12) },
                new Employe { Id = 5, Nom = "Jones", Prenom = "Amelia", DateNaissance = new DateTime(1952, 01, 12) },
                new Employe { Id = 6, Nom = "Taylor", Prenom = "Ava", DateNaissance = new DateTime(1987, 05, 11) },
                new Employe { Id = 7, Nom = "Miller", Prenom = "Ethan", DateNaissance = new DateTime(1988, 01, 12) },
                new Employe { Id = 8, Nom = "Wilson", Prenom = "Charlotte", DateNaissance = new DateTime(1998, 05, 11) },
                new Employe { Id = 9, Nom = "Johnson", Prenom = "Jack", DateNaissance = new DateTime(1958, 01, 12) },
                new Employe { Id = 10, Nom = "Anderson", Prenom = "Olivia", DateNaissance = new DateTime(1968, 05, 11) }
            };

            foreach (var item in liste)
            {
                service.AjouterEmploye(item);
            }
        }
    }
}
