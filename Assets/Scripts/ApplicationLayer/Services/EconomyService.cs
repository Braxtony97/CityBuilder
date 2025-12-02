using System;

namespace ApplicationLayer.Services
{
    public class EconomyService
    {
        public int Gold { get; private set; }

        public EconomyService(int startingGold = 500)
        {
            Gold = startingGold;
        }

        public bool CanSpend(int amount) => 
            Gold >= amount;

        public void Spend(int amount)
        {
            if (amount > Gold)
                throw new InvalidOperationException("Not enough gold");

            Gold -= amount;
        }

        public void Earn(int amount) => 
            Gold += amount;
    }
}