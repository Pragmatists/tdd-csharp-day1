using Moq;
using NSubstitute;
using NUnit.Framework;

namespace Mocks
{
    public class OrderTestNSubstitute
    {
        private Warehouse warehouse;

        [SetUp]
        public void SetUpWarehouse()
        {
            warehouse = Substitute.For<Warehouse>();
            warehouse.GetInventory(Products.Ziemniaki).Returns(50);
        }

        [Test]
        public void ShouldFillOrderFromWarehouse()
        {
            var order = new Order(Products.Ziemniaki, 50);

            order.Fill(warehouse);

            warehouse.Received().Remove(Products.Ziemniaki, 50);
        }


        [Test]
        public void ShouldNotFillOrderWhenNotEnoughProductInWarehouse()
        {
            var order = new Order(Products.Ziemniaki, 51);

            order.Fill(warehouse);

            warehouse.DidNotReceive().Remove(Arg.Any<string>(), 0);
            warehouse.DidNotReceiveWithAnyArgs().Remove("", 0);
        }
      
    }
}