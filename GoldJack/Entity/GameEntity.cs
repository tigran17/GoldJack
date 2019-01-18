using GoldJack.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldJack.Entity
{
    public class GameEntity
    {
        private Coin[] _coins;
        private int _coinCount = GameConstants.CoinCount;
        private int _bet;

        public GameEntity()
        {
           ShuffleCoins();
        }

        public string GetRange()
        {
            Random random = new Random();
            int randomNumber = random.Next(GameConstants.MinNumber, GameConstants.MaxNumber);
            string range = String.Format("{0} - {1}", randomNumber, randomNumber + GameConstants.Range);

            return range;
        }

        private Coin[] CreateCoins()
        {
            Coin[] coins = new Coin[_coinCount];

            for (int i = 0; i < GameConstants.CoinCount; i++)
            {
                coins[i] = new Coin() { Value = i + 1, IsVisibleValue = false };
            }

            return coins;
        }

        private void ShuffleCoins ()
        {
            if(_coins == null)
            {
                _coins = CreateCoins();
            }

            Random rnd = new Random();
            _coins = _coins.OrderBy(x => rnd.Next()).ToArray();
        }

        public int GetCoinValue(int pos)
        {
            _coins[pos].IsVisibleValue = true;
            return _coins[pos].Value;
        }

    }
}