using System;
using Moq;
using NUnit.Framework;

namespace Mocks
{
    internal class MoqExamples
    {
        [Test]
        public void CreatingAMock()
        {
            ISample sample = Mock.Of<ISample>();
            Mock<ISample> sampleMock = new Mock<ISample>();
            Mock.Get(sample).SetupGet(s => s.IsActive).Returns(true);
            Assert.That(sample.IsActive, Is.True);
        }


        [Test]
        public void SettingUpAMock()
        {
            Mock<ISample> sampleMock = new Mock<ISample>();
            sampleMock.SetupGet(s => s.IsActive).Returns(true);
            sampleMock.Setup(s => s.Sample()).Throws<InvalidOperationException>();
            sampleMock.Setup(s => s.Create(It.IsAny<string>())).Callback(
                (string name) => Console.Out.WriteLine("Called with " + name));
            sampleMock.Setup(s => s.Create(It.IsAny<string>())).Returns(() =>
                                                                            {
                                                                                Console.Out.WriteLine("returning true");
                                                                                return true;
                                                                            });

            sampleMock.Object.Create("me");
            Assert.That(sampleMock.Object.IsActive, Is.True);
            Assert.That(() => sampleMock.Object.Sample(), Throws.InvalidOperationException);
        }

        [Test]
        [Ignore("just an api illustration")]
        public void SettingUpWarehouse()
        {
            var warehouseMock = new Mock<Warehouse>();
            warehouseMock.Setup(w => w.HasInventory(Products.Ziemniaki, 50)).Returns(true);
            warehouseMock.Setup(w => w.HasInventory(Products.Ziemniaki, It.IsAny<int>())).Returns((string s, int amount) => amount <= 50);
            Assert.That(warehouseMock.Object.HasInventory(Products.Ziemniaki, 60), Is.False);
            warehouseMock.Setup(w => w.HasInventory(It.IsAny<string>(), It.IsAny<int>())).Throws<Exception>();
            warehouseMock.Setup(s => s.Remove(Products.Ziemniaki, 50)).Throws<Exception>();
            warehouseMock.SetupGet(s => s.IsActive).Returns(true);
            
            warehouseMock.Verify(w => w.Remove(Products.Ziemniaki, 50));
            warehouseMock.Verify(w => w.Remove(It.IsAny<string>(), 50));
            warehouseMock.Verify(w => w.Remove(Products.Ziemniaki, 50), Times.Exactly(10));
            warehouseMock.Verify(w => w.Remove(Products.Ziemniaki, 50), Times.Exactly(0));
            warehouseMock.Verify(w => w.Remove(Products.Ziemniaki, 50), Times.Never());
            var warehouseStrictMock = new Mock<Warehouse>(MockBehavior.Strict);
            warehouseStrictMock.VerifyAll();

        }


        [Test]
        public void Verifications()
        {
            var userManagerMock = new Mock<IUserManager>();
            userManagerMock.Object.FindUserWithId(2);
            userManagerMock.Verify(um => um.FindUserWithId(1), Times.Never());
        }

        [Test]
        public void SequenceVerification()
        {
            var userManagerMock = new Mock<IUserManager>(MockBehavior.Strict);
            var sampleMock = new Mock<ISample>(MockBehavior.Strict);
            var sequence = new MockSequence();
            userManagerMock.InSequence(sequence).Setup(x => x.FindUserWithId(1));
            sampleMock.InSequence(sequence).Setup(x=>x.Sample());

            userManagerMock.Object.FindUserWithId(1);
            sampleMock.Object.Sample();
        }


    }

    public interface IUserManager
    {
        void FindUserWithId(int i);
    }

    public interface ISample
    {
        bool IsActive { get; }
        void Sample();
        bool Create(string name);
    }
}