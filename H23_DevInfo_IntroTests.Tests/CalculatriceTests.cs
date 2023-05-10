using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Security.AccessControl;

namespace H23_DevInfo_IntroTests.Tests
{
    [TestClass]
    public class CalculatriceTests
    {
        #region Initialisation

        private Calculatrice calc;


        [TestInitialize]
        public void Initialiser()
        {
            calc = new Calculatrice();
        }

        #endregion


        #region Tests de la méthode Addition

        [TestMethod]
        [TestCategory("Méthodes d'addition")]
        public void Addition_UnPlusDeux_RetourneTrois()
        {
            // Arrange
            int a = 1;
            int b = 2;
            int attendue = 3;

            // Act
            int obtenue = calc.Addition(a, b);

            // Assert
            Assert.AreEqual(attendue, obtenue);
        }


        [TestMethod]
        [Timeout(300)]
        [TestCategory("Méthodes d'addition")]
        public void Addition_ZeroPlusZero_RetourneZero()
        {
            // Arrange
            int a = 0;
            int b = 0;
            int attendue = 0;

            // Act
            int obtenue = calc.Addition(a, b);

            // Assert
            Assert.AreEqual(attendue, obtenue);
        }

        #endregion


        #region Tests de la méthode Soustraction

        [TestMethod]
        [TestCategory("Méthodes de soustraction")]
        public void Soustraction_UnMoinsDeux_RetourneMoinsUn()
        {
            // Arrange
            int a = 1;
            int b = 2;
            int attendue = -1;

            // Act
            int obtenue = calc.Soustraction(a, b);

            // Assert
            Assert.AreEqual(attendue, obtenue);
            Assert.IsTrue(obtenue < 0);
        }

        #endregion


        #region Tests de la méthode Division

        [TestMethod]
        //[ExpectedException(typeof(DivideByZeroException))]
        public void Division_1Par0_RetourneDivideByZeroException()
        {
            // Arrange
            int a = 2;
            int b = 0;


            // Act
            // calc.Division(a, b);


            // Act & Assert
            Assert.ThrowsException<DivideByZeroException>(() => calc.Division(a, b));
        }

        #endregion


        #region Tests de la méthode PuissanceDeux

        [TestMethod]
        public void PuissanceDeux_ANegatif_RetourneArgumentOutOfRangeException()
        {
            // Arrange
            int a = -1;
            string parametreExceptionAttendue = "a";
            string messsageExceptionAttendue = "a doit être positif ou nul (Parameter 'a')";


            // Act & Assert
            var exceptionObtenue = Assert.ThrowsException<ArgumentOutOfRangeException>(() => calc.PuissanceDeux(a));
            Assert.AreEqual(parametreExceptionAttendue, exceptionObtenue.ParamName);
            Assert.AreEqual(messsageExceptionAttendue, exceptionObtenue.Message);
        }

        [TestMethod]
        public void PuissanceDeux_AZero_RetourneZero()
        {
            // Arrange
            int a = 0;
            int attendue = 0;
            // Act
            int obtenue = calc.PuissanceDeux(a);
            // Assert
            Assert.AreEqual(attendue, obtenue);
        }

        #endregion


        #region Tests de la méthode EstPair

        [TestMethod]
        public void EstPair_NombreImpair_RetourneFalse()
        {
            // Arrange
            int a = 1;

            // Act
            // use MS Test to test the private method
            MethodInfo privateMethod = typeof(Calculatrice).GetMethod("EstPair", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = new object[] { a };
            var obtenue = (bool)privateMethod.Invoke(calc, parameters);

            // Assert
            Assert.IsFalse(obtenue);
        }

        #endregion


        #region Tests de la méthode EstImpair

        [TestMethod]
        public void EstImpair_NombreImpair_RetourneTrue()
        {
            // Arrange
            int a = 1;

            // Act
            var obtenue = calc.EstImpair(a);

            // Assert
            Assert.IsTrue(obtenue);
        }

        #endregion


        #region Tests de la méthode TrierNombres

        // liste de nombres à trier
        // 1. liste est vide, retourne liste vide
        [TestMethod]
        [TestCategory("Tests de la méthode TrierNombres")]
        public void TrierNombres_ListeVide_RetourneListeVide()
        {
            // Arrange
            List<int> liste = new List<int>();
            
            // Act
            var obtenue = calc.TrierNombres(liste);
            
            // Assert
            Assert.AreEqual(0, obtenue.Count());
        }



        // 2. liste est null, lance ArgumentNullException
        [TestMethod]
        [TestCategory("Tests de la méthode TrierNombres")]
        public void TrierNombres_ListeNull_RetourneArgumentNullException()
        {
            // Arrange
            List<int> liste = null;
            
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => calc.TrierNombres(liste));
        }


        // 3. liste contient un seul nombre, retourne liste avec un seul nombre
        [TestMethod]
        [TestCategory("Tests de la méthode TrierNombres")]
        public void TrierNombres_ListeUnNombre_RetourneListeUnNombre()
        {
            // Arrange
            List<int> liste = new List<int>() { 12 };
            
            // Act
            var obtenue = calc.TrierNombres(liste);
            
            // Assert
            Assert.AreEqual(1, obtenue.Count());
            Assert.AreEqual(12, obtenue[0]);
        }


        // 4. liste contient deux nombres, retourne liste avec deux nombres triés ascendant (du plus petit au plus grand)
        [TestMethod]
        [TestCategory("Tests de la méthode TrierNombres")]
        public void TrierNombres_ListeAvecDeuxNombres_RetourneListeTriee()
        {
            // Arrange
            List<int> liste = new List<int>() { 12, 5 };

            // Act
            var obtenue = calc.TrierNombres(liste);

            // Assert
            Assert.AreEqual(2, obtenue.Count());
            Assert.AreEqual(5, obtenue[0]);
            Assert.AreEqual(12, obtenue[1]);
        }


        // 5. liste contient trois nombres, retourne liste avec trois nombres triés ascendant (du plus petit au plus grand)
        [TestMethod]
        [TestCategory("Tests de la méthode TrierNombres")]
        public void TrierNombres_ListeAvecTroisNombres_RetourneListeTriee()
        {
            // Arrange
            List<int> liste = new List<int>() { 12, 5, 8 };
            
            // Act
            var obtenue = calc.TrierNombres(liste);
            
            // Assert
            Assert.AreEqual(3, obtenue.Count());
            Assert.AreEqual(5, obtenue[0]);
            Assert.AreEqual(8, obtenue[1]);
            Assert.AreEqual(12, obtenue[2]);
        }

        // 6. liste contenant des nombres négatifs, retourne liste avec nombres triés ascendant (du plus petit au plus grand)
        [TestMethod]
        [TestCategory("Tests de la méthode TrierNombres")]
        public void TrierNombres_ListeAvecNombresNegatifs_RetourneListeTriee()
        {
            // Arrange
            List<int> liste = new List<int>() { -12, -5, -8, -1 };
            
            // Act
            var obtenue = calc.TrierNombres(liste);
            
            // Assert
            Assert.AreEqual(4, obtenue.Count());
            Assert.AreEqual(-12, obtenue[0]);
            Assert.AreEqual(-8, obtenue[1]);
            Assert.AreEqual(-5, obtenue[2]);
            Assert.AreEqual(-1, obtenue[3]);
        }


        // 7. liste contenant des nombres positifs et négatifs, retourne liste avec nombres triés ascendant (du plus petit au plus grand)
        [TestMethod]
        [TestCategory("Tests de la méthode TrierNombres")]
        public void TrierNombres_ListeAvecNombresPositifsEtNegatifs_RetourneListeTriee()
        {
            // Arrange
            List<int> liste = new List<int>() { 12, -5, 8, -1 };

            // Act
            var obtenue = calc.TrierNombres(liste);

            // Assert
            Assert.AreEqual(4, obtenue.Count());
            Assert.AreEqual(-5, obtenue[0]);
            Assert.AreEqual(-1, obtenue[1]);
            Assert.AreEqual(8, obtenue[2]);
            Assert.AreEqual(12, obtenue[3]);
        }

        // 8. liste contenant des doublons, retourne liste avec nombres triés ascendant (du plus petit au plus grand) mais en éliminant les doublons
        [TestMethod]
        [TestCategory("Tests de la méthode TrierNombres")]
        public void TrierNombres_ListeAvecDoublons_RetourneListeTrieeSansDoublons()
        {
            // Arrange
            List<int> liste = new List<int>() { 12, 5, 8, 5, 12, 8, 12, 6, 5, 8, 5, 12, 8, 12, 5, 8, 5, 12, 8, 12, 5, 8, 5, 12, 8, 12, 5, 8, 5, 12, 8, 12, 5, 8, 5, 12, 8, 12, 5, 8, 5, 12, 8, 12, 5, 8, 5, 12, 8, 12, 5, 8, 5, 12, 8 };
            
            // Act
            var obtenue = calc.TrierNombres(liste);
            
            // Assert
            Assert.AreEqual(4, obtenue.Count());
            Assert.AreEqual(5, obtenue[0]);
            Assert.AreEqual(6, obtenue[1]);
            Assert.AreEqual(8, obtenue[2]);
            Assert.AreEqual(12, obtenue[3]);
        }

        #endregion

    }
}
