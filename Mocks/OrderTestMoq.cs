using Moq;
using NUnit.Framework;

namespace Mocks
{
    public class OrderTestMoq
    {
        private Mock<Warehouse> warehouse;

        [SetUp]
        public void SetUpWarehouse()
        {
            warehouse = new Mock<Warehouse>();
            warehouse.Setup(w => w.GetInventory(Products.Ziemniaki)).Returns(50);
        }

        [Test]
        public void ShouldFillOrderFromWarehouse()
        {
            var order = new Order(Products.Ziemniaki, 50);

            order.Fill(warehouse.Object);

            warehouse.Verify(w=>w.Remove(Products.Ziemniaki, 50));
        }


        [Test]
        public void ShouldNotFillOrderWhenNotEnoughProductInWarehouse()
        {
            var order = new Order(Products.Ziemniaki, 51);

            order.Fill(warehouse.Object);

            warehouse.Verify(w => w.Remove(It.IsAny<string>(), It.IsAny<int>()), Times.Never());
        }
      
    }
}