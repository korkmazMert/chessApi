using chessApi.Models;
using chessApi.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace chessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChessController : Controller
    {
        private IchessService _service;
        public ChessController(IchessService chessService)
        {
            _service = chessService;
        }
        [HttpGet]
        [Route("getBoard")]
        public chessModelBase getBoard()
        {
            chessModelBase board= new chessModelBase();
            board = _service.getBoard();
            return board;
        }
        [HttpGet]
        [Route("saveBoard")]
        public int saveBoard(int playerID, JsonContent jsonData)
        {
            _service.saveBoard(playerID, jsonData);
            return 1;
        }
    }
}
