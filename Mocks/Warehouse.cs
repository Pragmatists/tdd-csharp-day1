namespace Mocks
{
    public class Warehouse
    {
        private int amount;

        public virtual bool IsActive
        {
            get { throw new System.NotImplementedException(); }
        }

        public virtual int GetInventory(string product)
        {
            return amount;
        }

        public virtual void Remove(string product, int amount)
        {
            this.amount -= amount;
        }

        public void Add(string product, int amount)
        {
            this.amount = amount;
        }

        public virtual bool HasInventory(string product, int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}