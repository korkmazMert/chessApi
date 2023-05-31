using chessApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Text.Json.Serialization;


namespace chessApi.services
{
    public interface IchessService
    {
        public chessModelBase getBoard(int playerID);
        public int saveBoard(int playerID, string jsonData);
        //public int loginCheck(string kullaniciAd, string kullaniciSifre);

        //public int inserttesting(string veri, string veri2);
    }
    public class chessService : IchessService
    {
        public string constr { get; set; }
        public IConfiguration _configuration;

        public chessService(IConfiguration configuration)
        {
            _configuration = configuration;
            constr = _configuration["ConnectionStrings:chessDB"];

        }

        //public int loginCheck(string kullaniciAd, string kullaniciSifre)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(constr))
        //        {
        //            var cmd = new SqlCommand("loginCheck", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@kullaniciAd", kullaniciAd);
        //            cmd.Parameters.AddWithValue("@kullaniciSifre", kullaniciSifre);

        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            conn.Close();

        //            return 0;
        //        }
        //    }

        //    catch (SqlException)
        //    {

        //        return 1;


        //    }
        //    catch (Exception)
        //    {
        //        return 2;
        //    }
        //}


        //public int inserttesting(string veri, string veri2) 
        //{

        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection(connectionString: "Data Source=DESKTOP-RLBVTTN; Initial Catalog=chessDB; Integrated Security=true; TrustServerCertificate=True"))
        //        {
        //            var cmd = new SqlCommand("inserttesting", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@veri", veri);
        //            cmd.Parameters.AddWithValue("@veri2", veri2);


        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //            return 1;

        //        }

        //    }
        //    catch (Exception)
        //    {

        //        return 0;
        //    }
        //}

        public int saveBoard(int playerID, string jsonData)
        {
           
           String jsonString = JsonConvert.SerializeObject(jsonData);
           
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    var cmd = new SqlCommand("SaveJson", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@playerID", playerID);
                    cmd.Parameters.AddWithValue("@JsonData", jsonData);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return 1;
                }

            }
            catch (Exception)
            {

                return 0;
            }
        }



        public chessModelBase getBoard(int playerID)
        {

            chessModel chessModel = new chessModel();
            chessModelBase chessModelBase = new chessModelBase();
            try
            {


                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    var cmd = new SqlCommand("getBoard", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", playerID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            chessModel.playerID= Convert.ToInt32(dr["playerId"]);
                            chessModel.pieceName = dr["pieceName"].ToString();
                            chessModel.location = (Location?)dr["locatiion"];
                            chessModel.playerColor = (PlayerColor?)dr["playerColor"];
                            chessModel.fileName= dr["fileName"].ToString();
                            chessModel.x = Convert.ToInt32(dr["x"]);
                            chessModel.y = Convert.ToInt32(dr["y"]);
                            chessModel.canMoveto = Convert.ToBoolean(dr["canMoveto"]);
                            chessModel.canCapture = Convert.ToBoolean(dr["canCapture"]);
                            
                            //moves ve captures nasıl olacak bilmiyorum
                            chessModelBase.pieceList.Add(chessModel);


                        }

                    }
                    else
                    {
                        Console.WriteLine("girdi yok");
                    }

                    conn.Close();
                }

                return chessModelBase;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return chessModelBase;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return chessModelBase;


            }
        }


    }
}