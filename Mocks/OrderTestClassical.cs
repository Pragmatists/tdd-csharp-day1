using System;
using NUnit.Framework;

namespace Mocks
{
    internal class Products
    {
        internal const string Ziemniaki = "ziemniaki";
    }

    public class OrderTestClassical
    {
        private readonly Warehouse warehouse = new Warehouse();

        [SetUp]
        public void SetupWarehouse()
        {
            warehouse.Add(Products.Ziemniaki, 50);
        }


        [Test]
        public void ShouldFillOrderFromWarehouse()
        {
            var order = new Order(Products.Ziemniaki, 50);

            order.Fill(warehouse);

            Assert.That(order.IsFilled, Is.True);
            Assert.That(warehouse.GetInventory(Products.Ziemniaki), Is.EqualTo(0));
           
        }

        [Test]
        public void ShouldNotFillOrderWhenNotEnoughProductInWarehouse()
        {
            var order = new Order(Products.Ziemniaki, 51);

            order.Fill(warehouse);

            Assert.That(order.IsFilled, Is.False);
            Assert.That(warehouse.GetInventory(Products.Ziemniaki), Is.EqualTo(50)); 
        }
      
    }
}