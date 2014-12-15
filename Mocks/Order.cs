namespace Mocks
{
    public class Order
    {
        private readonly string product;
        private int amount;

        public Order(string product, int amount)
        {
            this.amount = amount;
            this.product = product;
        }

        public bool IsFilled { get; private set; }


        public void Fill(Warehouse warehouse)
        {
            if (warehouse.GetInventory(product) < amount)
                return;
            warehouse.Remove(product, amount);
            IsFilled = true;
        }
    }
}