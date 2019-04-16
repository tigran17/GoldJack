using AutoMapper;
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
        //private int _coinCount = GameConstants.CoinCount;
        private GameProvider _provider;
        
        public GameService()
        {
            if (_provider == null)
            {
                _provider = new GameProvider();
            }
        }

        public GameModel GetGame (GameModel model)
        {
            //TODO: Should initialize User
            model.UserId = 6; //HARD CODE

            var gameEntity = Mapper.Map<Game>(model);

            _provider.GetGame(gameEntity);

            return model;
        }

        public GameModel StartGame(GameModel model)
        {
            var gameEntity = new Game();
            var provider = new GameProvider();

            //TODO:Check User Balance
            //TODO: Should init User
            gameEntity.UserId = 6;  //Hard Code
            gameEntity.Coins = CreateCoins();
            ShuffleCoins(gameEntity.Coins);
            gameEntity.Range = GetRange();

            gameEntity = provider.StartGame(gameEntity);

            var gameModel = Mapper.Map<Game, GameModel>(gameEntity);
            
            return gameModel;
        }

        public CoinModel GetCoinByPosition(CoinModel model)
        {
            var coinEntity = Mapper.Map<Coin>(model);

            coinEntity = _provider.GetCoinByPosition(coinEntity);

            if (coinEntity == null) return null;

            model = Mapper.Map<Coin, CoinModel>(coinEntity);

            return model;
        }

        //private functions

        #region 

        private List<Coin> CreateCoins()
        {
            List<Coin> coins = new List<Coin>();

            for (int i = 0; i < GameConstants.CoinCount; i++)
            {
                coins.Add(new Coin() { Value = i + 1, IsOpened = false });
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

        private string GetRange()
        {
            Random random = new Random();
            int randomNumber = random.Next(GameConstants.MinNumber, GameConstants.MaxNumber);
            string range = String.Format("{0} - {1}", randomNumber, randomNumber + GameConstants.Range);

            return range;
        }

        //private bool CheckGameResult(CoinModel model)
        //{

        //}

        #endregion
    }
}