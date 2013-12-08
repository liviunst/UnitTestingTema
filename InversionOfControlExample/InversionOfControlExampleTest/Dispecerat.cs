using InversionOfControlExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlExampleTest
{
    [TestClass]
    public class Dispecerat
    {
        //Tema se testeaza ca ISursaDeDate se apeleaza cu Add(person),
        //person fiind instanta returnata de PersonInitialization

        [TestMethod]
        public void GivenADispecerAWhenCallAddPersonThenAddIsCalledWithTheReturnedValuedOfPersonInitialization()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();
            var person = new Persoana()
            {
                Nume = "NumeMock",
                Prenume = "PrenumeMock",
                Varsta = 22
            };

            List<Persoana> lista = new List<Persoana>();

            //setare pe mock
            personInitMock.Setup(s => s.CreatePerson()).Returns(person);
            sursaDeDateMock.Setup(s => s.ReadAll()).Returns(lista);

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //act
            A.Add();

            //assert
            sursaDeDateMock.Verify(v => v.Add(person), Times.Exactly(1));
        }

        //Tema se apeleaza ReadByName by Mock

        [TestMethod]
        public void GivenADispecerAWhenCallReadByNameTheMethodReadByNameFromIsursaDeDateIsCalled()
        {
            //arrange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<PersonInitialization>();

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            A.ReadByNume("Liviu");

            sursaDeDateMock.Verify(v => v.ReadByName("Liviu"), Times.Exactly(1));
        }

        //Tema se apeleaza ReadAll by Mock

        [TestMethod]
        public void GivenADispecerAWhenCalledReadAllTheMethodReadAllFromISursaDeDateIsCalled()
        {
            //arrange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<PersonInitialization>();

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            A.ReadAll();
            A.ReadAll();
            A.ReadAll();

            sursaDeDateMock.Verify(v => v.ReadAll(), Times.Exactly(3));
        }

        //Tema PersonInitialization returneaza o persoana cu nume null/empty => exceptie

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenADispecerAWhenCallAddPersonAndPersonHasNumeEmptyOrNullThenAnExceptionIsThrown()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            //setare pe mock
            personInitMock.Setup(s => s.CreatePerson()).Returns(new Persoana()
            {
                Nume = null,
                Prenume = "PrenumeMock",
                Varsta = 17
            });

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //act
            A.Add();
        }

        //Tema PersonInitialization returneaza o persoana cu prenume null/empty => exceptie

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenADispecerAWhenCallAddPersonAndPersonHasPrenumeEmptyOrNullThenAnExceptionIsThrown()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            //setare pe mock
            personInitMock.Setup(s => s.CreatePerson()).Returns(new Persoana()
            {
                Nume = "Nume Mock",
                Prenume = "",
                Varsta = 17
            });

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //act
            A.Add();
        }

        [TestMethod]
        public void GivenADispecerAWhenCallAddPersonThenTheMethodAddFromISursaDeDateIsCalled()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //setare pe Mock
            personInitMock.Setup(s => s.CreatePerson()).Returns(new Persoana()
            {
                Nume = "NumeMock",
                Prenume = "PrenumeMock",
                Varsta = 23
            });

            List<Persoana> lista = new List<Persoana>();
            sursaDeDateMock.Setup(s => s.ReadAll()).Returns(lista);

            //act
            A.Add();

            //assert
            sursaDeDateMock.Verify(v => v.Add(It.IsAny<Persoana>()), Times.Exactly(1));
            personInitMock.Verify(v => v.CreatePerson(), Times.Exactly(1));

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenADispecerAWhenCallAddPersonAndPersonHasVarstaLessThan18ThenAnExceptionIsThrown()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            //setare pe mock
            personInitMock.Setup(s => s.CreatePerson()).Returns(new Persoana()
                                                                        {
                                                                            Nume = "NumeMock",
                                                                            Prenume = "PrenumeMock",
                                                                            Varsta = 17
                                                                        });

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //act
            A.Add();
        }
    }
}
