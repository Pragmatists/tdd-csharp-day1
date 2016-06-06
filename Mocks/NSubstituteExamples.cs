using System;
using Moq;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace Mocks
{
    internal class NSubstituteExamples
    {
        [Test]
        public void CreatingAMock()
        {
            ISample sample = Substitute.For<ISample>();
            sample.IsActive.Returns(true);
            Assert.That(sample.IsActive, Is.True);
        }


        [Test]
        public void SettingUpAMock()
        {
            var sample = Substitute.For<ISample>();
            sample.IsActive.Returns(true);
            sample.IsActive.Returns(x => { throw new InvalidOperationException(); });
            sample.When(x=>x.Sample()).Do( x => {throw new InvalidOperationException(); });
            sample.Create("").ReturnsForAnyArgs(x => { Console.Out.WriteLine("Called with " + x.Arg<string>());
                                                         return false;
            });
            sample.Create("wiosna");
            Assert.That(() => sample.Sample(), Throws.InvalidOperationException);
        }

        [Test]
        [Ignore("just an api illustration")]
        public void SettingUpWarehouse()
        {
            var warehouse = Substitute.For<Warehouse>();
            warehouse.HasInventory(Products.Ziemniaki, 50).Returns(true);
            warehouse.HasInventory(Products.Ziemniaki, Arg.Is<int>(x => x <= 50)).Returns(true);
            warehouse.HasInventory(Products.Ziemniaki, Arg.Any<int>()).Returns(x => x.Arg<int>() <= 50);
        }


        [Test]
        [Ignore("just an api illustration")]
        public void Verifications()
        {
            var userManager = Substitute.For<IUserManager>();
            userManager.DidNotReceive().FindUserWithId(Arg.Any<int>());
            userManager.Received().FindUserWithId(5);
            userManager.Received(3).FindUserWithId(2);
        }

        [Test]
        [Ignore("just an api illustration")]
        public void SequenceVerification()
        {
            var warehouse = Substitute.For<Warehouse>();
            var userManager = Substitute.For<IUserManager>();

            Received.InOrder(() =>
            {
                userManager.FindUserWithId(1);
                warehouse.Remove("product", 4);
            });
        }
    }

}