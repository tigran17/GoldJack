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
        public Game StartGame(Game game )
        {
            using (DataContext context = new DataContext())
            {
                //var lastGame = context.Games.LastOrDefault();
                //game.Id = lastGame == null ? 0 : ++lastGame.Id;

                context.Games.Add(game);
                context.SaveChanges();

                

                return game;
            }
        }

        //public Game GetCoinValue()
        //{

        //}
    }
}
