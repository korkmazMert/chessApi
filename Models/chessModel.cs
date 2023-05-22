using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace chessApi.Models
{
    public class chessModelBase
    {
        

        
        public List<chessModel> pieceList { get; set; }
        public chessModelBase()
        {
            pieceList = new List<chessModel>();
        }

    }

    public class chessModel
    {
        public int playerID { get; set; }   
        public string? pieceName { get; set; }
        public Location? location { get; set; }
        public PlayerColor? playerColor { get; set; }
        public string? fileName { get; set; }
        public int? x { get; set; }
        public int? y { get; set; }
        public bool? canMoveto { get; set; }
        public bool? canCapture { get; set; }
        public List<Location> moves { get; set; }
        public List<Location> captures { get; set; }
        public chessModel()
        {
            captures = new List<Location>();
            moves = new List<Location>();
            
        }


    }

    public enum PlayerColor
    {
        white,
        black
    }

    public class Location
    { 
        public int x;
        public int y;
        public PlayerColor color;
        
    }
}
