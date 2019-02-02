using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataProvider
{
    public class GameProvider
    {
        private DataContext _context;

        public GameProvider()
        {
            if(_context == null)
            {
                _context = new DataContext();
            }
        }

        public Game StartGame(Game game)
        {
            var gameEntity = new Game();

            using (_context)
            {
                //Hard Code
                game.UserId = 1;

                _context.Games.Add(game);
                _context.SaveChanges();

                gameEntity = _context.Games.Where(x => x.UserId == game.UserId).OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                SaveGameCoins(gameEntity);
            }

            return gameEntity;
        }

        public Coin GetCoinByPosition(Coin coin)
        {
            using (_context)
            {
                coin = _context.GameCoins.Where(x => x.GameId == coin.GameId && x.Position == coin.Position)
                    .FirstOrDefault();

                if (coin == null) return null;

                coin.IsOpened = true;

                _context.SaveChanges();
            }

            return coin;
        }


        //private functions
        #region 

        private void SaveGameCoins(Game game)
        {
            List<Coin> coins = new List<Coin>();

            foreach(var coin in game.Coins)
            {
                var coinEntity = new Coin
                {
                    GameId = game.Id,
                    Position = coin.Position,
                    Value = coin.Value
                };

                coins.Add(coinEntity);
            }

            _context.GameCoins.AddRange(coins);
            _context.SaveChanges();
        }

        #endregion
    }
}
