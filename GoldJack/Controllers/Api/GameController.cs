using GoldJack.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoldJack.Controllers.Api
{
    public class GameController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage StartGame()
        {
            try
            {
                var service = new GameService();
                var result = service.GetRange();
                return Request.CreateResponse<string>(HttpStatusCode.OK, result); ;
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
            
        }

        //[HttpGet]
        //public int GetCoinValue()
        //{
        //    return 0;
        //}

        //[HttpGet]
        //public void GetRange()
        //{

        //}
    }
}