using AutoMapper;
using DataAccess.Entities;
using GoldJack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldJack.Mapping
{
    public class GameMapperProfile : Profile
    {

        public GameMapperProfile()
        {
            CreateMap<Game, GameModel>();
            CreateMap<GameModel, Game>();

            CreateMap<Coin, CoinModel>();
            CreateMap<CoinModel, Coin>();
        }
    }
}