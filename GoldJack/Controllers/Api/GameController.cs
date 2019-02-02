using GoldJack.Attributes;
using GoldJack.Models;
using GoldJack.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GoldJack.Controllers.Api
{
    //[RequestFilter]
    public class GameController : ApiController
    {
        //GameService _service;

        [HttpPost]
        public HttpResponseMessage StartGame(GameModel model)
        {
            try
            {
                var service = new GameService();

                var result = service.StartGame(model);
                return Request.CreateResponse<GameModel>(HttpStatusCode.OK, result);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage GetCoinByPosition(CoinModel coin)
        {
            try
            {
                var service = new GameService();
                var result = service.GetCoinByPosition(coin);

                if (result == null)
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Can't find the coin");

                return Request.CreateResponse<CoinModel>(HttpStatusCode.OK, result);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}