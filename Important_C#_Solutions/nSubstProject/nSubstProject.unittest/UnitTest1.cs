using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using nSubstProject;
using Moq;

namespace nSubstProject.unittest
{
    [TestClass]
    public class Icalculator
    {
       
       [TestMethod]
        public void basicTest()
        {
          var  calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);
            Assert.AreEqual(calculator.Add(1, 2), 3);

        }


        [TestMethod]
        public void DealwithProberties()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2);
            calculator.Add(1, 2).Returns(3);
            Assert.AreEqual(calculator.Add(1, 2), 3);
            calculator.DidNotReceive().Add(5, 7);

            calculator.Mode.Returns("DEC");
            Assert.AreEqual(calculator.Mode, "DEC");

            calculator.Mode = "HEX";
            Assert.AreEqual(calculator.Mode, "HEX");
        }

        [TestMethod]
        public void Recivedcall()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(10, -5);
            calculator.Received().Add(10, Arg.Any<int>());
            calculator.Received().Add(10, Arg.Is<int>(x => x < 0));
        }
        [TestMethod]
        public void ImpressiveCall()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(Arg.Any<int>(), Arg.Any<int>())
            .Returns(x => (int)x[0] + (int)x[1]);
             Assert.AreEqual(calculator.Add(87, 1),88);
        }

        [TestMethod]
        public void RaiseEvent()
        {
            var calculator = Substitute.For<ICalculator>();
            bool eventWasRaised = false;
            calculator.PoweringUp += (sender, args) => eventWasRaised = true;
            calculator.PoweringUp += Raise.Event();
            Assert.IsTrue(eventWasRaised);
            
        }
        public void multi_interfaces()
        {
            //var command = Substitute.For<ICommand, IDisposable>();
            //var runner = new CommandRunner(command);
            //runner.RunCommand();

        }

        [TestMethod]
        public void withmoq()
        {
            Mock<Email> EmailMOqed = new Mock<Email>();
            EmailMOqed.Setup(x => x.sendEmail()).Returns(true);

            Develop mydev = new Develop();
            bool Result=  mydev.DoSomething();
            Assert.AreEqual(Result, true);
        }
    }
}
