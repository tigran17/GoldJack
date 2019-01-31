using DataAccess.DataProvider;
using DataAccess.Entities;
using GoldJack.Constants;
using GoldJack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldJack.Service
{
    public class GameService
    {
        private int _coinCount = GameConstants.CoinCount;

        public GameModel StartGame(GameModel game)
        {
            var gameEntity = new Game();
            var provider = new GameProvider();

            gameEntity.Coins = CreateCoins();
            ShuffleCoins(gameEntity.Coins);

            gameEntity.Range = GetRange();

            gameEntity = provider.StartGame(gameEntity);

            //TODO: Automapping

            return game;
        }

        private string GetRange()
        {
            Random random = new Random();
            int randomNumber = random.Next(GameConstants.MinNumber, GameConstants.MaxNumber);
            string range = String.Format("{0} - {1}", randomNumber, randomNumber + GameConstants.Range);

            return range;
        }

        public int GetCoinValue(int pos)
        {
            return 0;//game.GetCoinValue(pos);
        }

        //private functions

        #region 

        private List<Coin> CreateCoins()
        {
            List<Coin> coins = new List<Coin>();

            for (int i = 0; i < GameConstants.CoinCount; i++)
            {
                coins[i] = new Coin() { Value = i + 1, IsOpened = false };
            }

            return coins;
        }

        private void ShuffleCoins(List<Coin> coins)
        {       
            Random rnd = new Random();
            coins = coins.OrderBy(x => rnd.Next()).ToList();

            int i = 0;
            foreach(var item in coins)
            {
                item.Position = ++i;
            }
        }

        #endregion
    }
}