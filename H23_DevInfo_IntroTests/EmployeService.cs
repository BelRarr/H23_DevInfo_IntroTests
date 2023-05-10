using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace H23_DevInfo_IntroTests
{
    public class EmployeService
    {
        private readonly List<Employe> _employes;
        private IDateService _dateService;


        public EmployeService(IDateService dateService)
        {
            _employes = new List<Employe>();
            _dateService = dateService;
        }


        internal List<Employe> ObtenirEmployesPourTests()
        {
            var employes = new List<Employe>
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

            foreach (var item in employes)
            {
                AjouterEmploye(item);
            }

            return employes;
        }

        public List<Employe> ObtenirEmployes()
        {
            // aller chercher les employés dans la base de données
            // les ajouter dans la liste _employes
            // retourner la liste _employes
            return _employes;
        }

        public void AjouterEmploye(Employe employe)
        {
            if (!ExisteEmploye(employe))
                _employes.Add(employe);
        }

        public void SupprimerEmploye(Employe employe)
        {
            if (ExisteEmploye(employe))
                _employes.Remove(employe);
        }

        public void ModifierEmploye(Employe employe)
        {
            var employeAModifier = _employes.FirstOrDefault(e => e.Id == employe.Id);
            if (employeAModifier == null)
            {
                throw new ArgumentException("L'employé n'existe pas");
            }
            employeAModifier.Nom = employe.Nom;
            employeAModifier.Prenom = employe.Prenom;
        }

        public bool ExisteEmploye(Employe employe)
        {
            return _employes.Any(e => e.Id == employe.Id);
        }


        public List<Employe> ObtenirLaListeDesEmployesDontCestLanniversaireAujourdhui()
        {
            return _employes.Where(e => e.DateNaissance.Month == _dateService.ObtenirDateCourante().Month
                                    && e.DateNaissance.Day == _dateService.ObtenirDateCourante().Day).ToList();
        }
    }
}
