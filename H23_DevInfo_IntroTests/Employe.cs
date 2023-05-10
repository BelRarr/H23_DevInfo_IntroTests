using System;

namespace H23_DevInfo_IntroTests
{
    public class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public DateTime DateNaissance { get; set; } = DateTime.Now;
    }
}
