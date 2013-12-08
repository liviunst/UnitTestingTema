using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountRegister_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accountregisterTest
{
    [TestClass]
    public class PasswordStrengthMeterTest
    {
        //mai scrieti inca 5 teste [[TEMA]]

        //Tema1
        [TestMethod]
        public void GivenAnPasswordWithLessThan8CharsContainingLowercasesAndNumbersWhenPSMIsCalledThenResultIs2(){
            //arrange
            String password = "ab12cd";
            int expectedResult = 2;

            //act 
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        //Tema2
        [TestMethod]
        public void GivenAnPasswordWithMoreThan7CharsOnlyNumbersWhenPSMIsCalledThenResultIs2()
        {
            //arrange
            String password = "112233445566";
            int expectedResult = 2;

            //act 
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        //Tema3
        [TestMethod]
        public void GivenAnPasswordWithLessThan8CharsOnlyUpperCaseWhenPSMIsCalledThenResultIs1()
        {
            //arrange
            String password = "GIRAFA";
            int expectedResult = 1;

            //act 
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        //Tema4
        [TestMethod]
        public void GivenAnPasswordWithMoreThan7CharContainingUpperCasesSpecialCharsAndLowerCasesWhenPSMIsCalledThenResultIs4()
        {
            //arrange
            String password = "p@RolaMareEEE";
            int expectedResult = 4;

            //act 
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        //Tema5
        [TestMethod]
        public void GivenAnPasswordWithMoreThan7CharContainingUpperAndLowerCasesSpecialCharsAndNumbersWhenPSMIsCalledThenResultIs5()
        {
            //arrange
            String password = "p@r0LAde5puncte";
            int expectedResult = 5;

            //act 
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        //gata tema

        [TestMethod]
        public void GivenAnEmptyPasswordWhenPSMIsCalledThenResultIs0()
        { 
            //arrange
            String password = "";
            int expectedResult = 0;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAnPasswordWith8LowerCaseLettersWhenPSMIsCalledThenResultIs2() 
        { 
            //arange 
            String password = "alabalap";
            int expectedResult = 2;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAnPasswordWithLessThan8LowerCaseLettersWhenPSMIsCalledThenResultIs1()
        {
            //arange 
            String password = "alab";
            int expectedResult = 1;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAnPasswordWithMoreThan7LettersWithLowerAndUpperCaseandNumberWhenPSMIsCalledThenResultIs4()
        {
            //arange 
            String password = "aLab4asdadad";
            int expectedResult = 4;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAnPasswordWith7LettersWithLowerAndUpperCaseandASpecialCharWhenPSMIsCalledThenResultIs4()
        {
            //arange 
            String password = "aB#cded";
            int expectedResult = 3;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenANullPasswordWhenPSMIsCalledThenResultIs0()
        {
            //arange 
            String password = null;
            int expectedResult = 0;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenAPasswordWithASingelSpecialCharWhenPSMIsCalledThenResultIs1()
        {
            //arange 
            String password = "?";
            int expectedResult = 1;

            //act
            var result = PasswordStrengthMeter.GetPasswordStrength(password);

            //assert
            Assert.AreEqual(expectedResult, result);
        }

        

    }
}
