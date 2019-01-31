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
        GameService _service;

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
        public HttpResponseMessage GetCoinValue(int pos)
        {
            if(_service == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Game has been not started");
            }

            var result = _service.GetCoinValue(pos);
            return Request.CreateResponse<int>(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public void GetRange()
        {

        }
    }
}