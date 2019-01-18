using GoldJack.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldJack.Service
{
    public class GameService
    {
        private GameEntity game;
        public static int GameNumber { get; set; }

        public GameService()
        {
            GameNumber++;
            game = new GameEntity();
        }

        public string GetRange()
        {
            return game.GetRange();
        }

        public int GetCoinValue(int pos)
        {
            return game.GetCoinValue(pos);
        }
    }
}