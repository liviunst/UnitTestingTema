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
        [TestMethod]
        public void GivenADispeceratWhenCallAddPersonThenTheMethodAddFromISursaDeDateIsCalled()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //act
            A.Add();
            A.Add();

            //assert
            sursaDeDateMock.Verify(v => v.Add(It.IsAny<Persoana>()), Times.Exactly(2));
            personInitMock.Verify(v => v.CreatePerson(), Times.Exactly(0));

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenADispeceratWhenCallAddPersonAndPersonHasVarstaLessThan18ThenAnExceptionIsThrown()
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
