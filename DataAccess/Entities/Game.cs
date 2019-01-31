using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public double Bet { get; set; }

        public string Range { get; set; }

        public bool IsWin { get; set; }

        public bool IsCashback { get; set; }

        public bool IsBonusGame { get; set; }

        public Int16 GameNumber { get; set; }

        [NotMapped]
        public List<Coin> Coins { get; set; }

        [NotMapped]
        public List<GameDetails> GamesDetails { get; set; }
    }
}
