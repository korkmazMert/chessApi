using chessApi.Models;
using chessApi.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;


namespace chessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessController : ControllerBase
    {
        private readonly IchessService _service;
        public ChessController(IchessService chessServices)
        {
            _service = chessServices;
        }
        [HttpGet]
        [Route("getBoard")]
        public chessModelBase getBoard(int playerID)
        {
            chessModelBase board = new chessModelBase();
            board = _service.getBoard(playerID);
            return board;
        }
        [HttpGet]
        [Route("saveBoard")]
        public int saveBoard(int playerID, string jsonData)
        {
            _service.saveBoard(playerID, jsonData);
            return 1;
        }



        //[HttpGet]
        //[Route("testing")]
        //public int inserttesting(string veri,string veri2)
        //{

        //    _service.inserttesting(veri,veri2);
        //    return 1;
        //}
    }
}
