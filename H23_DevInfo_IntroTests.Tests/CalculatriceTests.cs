using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace H23_DevInfo_IntroTests.Tests
{
    [TestClass]
    public class CalculatriceTests
    {

        private Calculatrice calc;


        [TestInitialize]
        public void Initialiser()
        {
            calc = new Calculatrice();
        }


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
    }
}
