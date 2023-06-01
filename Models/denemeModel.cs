namespace chessApi.Models
{
    public class denemeModelBase
    {

        public List<denemeModel> denemeModels { get; set; } 
        
        public denemeModelBase() {
            denemeModels = new List<denemeModel>();
        }
    }

    public class denemeModel
    {
        
        public String? data { get; set; }
    }
}
