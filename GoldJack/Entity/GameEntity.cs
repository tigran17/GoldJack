using GoldJack.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldJack.Entity
{
    public class GameEntity
    {
        private int[][] _matrix;
        private int _bet;

        public string GetRange()
        {
            Random random = new Random();
            int randomNumber = random.Next(GameConstants.MinNumber, GameConstants.MaxNumber);
            string range = String.Format("{0} - {1}", randomNumber, randomNumber + GameConstants.Range);

            return range;
        }

    }
}