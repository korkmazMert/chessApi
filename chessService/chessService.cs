using chessApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace chessApi.services
{
    public interface IjobServices
    {
        public chessModelBase getBoard();
        public int saveBoard(int playerID, JsonContent jsonData);
        //public int loginCheck(string kullaniciAd, string kullaniciSifre);
    }
    public class jobServices : IjobServices
    {
        public string constr { get; set; }
        public IConfiguration _configuration;

        public jobServices(IConfiguration configuration)
        {
            _configuration = configuration;
            constr = _configuration["ConnectingStrings:DbConnection"];

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

        public int saveBoard(int playerID,JsonContent jsonData)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    var cmd = new SqlCommand("saveJob", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@playerID", playerID);
                    cmd.Parameters.AddWithValue("@JsonData", jsonData);
                    

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return 0;
                }

            }
            catch (Exception)
            {

                return 1;
            }
        }

       

        public chessModelBase getBoard(int playerID)
        {
            //List<jobModel> jobList = new List<jobModel>();
            chessModel chessModel = new chessModel();
            chessModelBase chessModelBase = new chessModelBase();


            try
            {


                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    var cmd = new SqlCommand("getBoard", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@playerID", playerID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            
                        }

                    }
                    else
                    {
                        
                    }

                    conn.Close();
                }

                return chessModelBase;
            }
            catch (SqlException ex)
            {

                return chessModelBase;
            }
            catch (Exception ex)
            {

                return chessModelBase;


            }
        }

        chessModelBase IjobServices.getBoard()
        {
            throw new NotImplementedException();
        }

        int IjobServices.saveBoard(int playerID, JsonContent jsonData)
        {
            throw new NotImplementedException();
        }
    }

}