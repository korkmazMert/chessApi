using chessApi.Models;
using chessApi.services;
using Microsoft.AspNetCore.Mvc;

namespace chessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class denemeController : ControllerBase
    {
        private readonly IchessService _service;
        public denemeController(IchessService chessServices)
        {
            _service = chessServices;
        }
        [HttpGet]
        [Route("denemeGet")]
        public denemeModelBase denemeGet(int playerID)
        {
            denemeModelBase board = new denemeModelBase();
            board = _service.getTahta(playerID);
            Console.WriteLine(board);
            return board;
        }
        [HttpGet]
        [Route("saveTahta")]
        public int denemeSave(int playerID, string data)
        {
            _service.saveTahta(playerID, data);
            return 1;
        }
    }
}
