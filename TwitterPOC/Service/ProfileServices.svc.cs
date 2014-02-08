using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections;

namespace Service
{
    public class ProfileServices : IProfileServices
    {
        public int ReturnIdUser(string username)
        {
            int iduser = -1;
            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "SELECT ID_User from tb_Users WHERE username=@username";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@username", username);

                    try
                    {
                       cnn.Open();

                        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            dr.Read();
                            iduser = dr.GetInt32(0);
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cnn.State == System.Data.ConnectionState.Open)
                        {
                            try
                            {
                                cnn.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            return iduser;
        }

        public string GetUsername(int id)
        {
            string username = string.Empty;

            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "SELECT Username from tb_Users WHERE ID_User=@iduser";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@iduser", id);

                    try
                    {
                        cnn.Open();

                        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            dr.Read();
                            username = dr.GetString(0);
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cnn.State == System.Data.ConnectionState.Open)
                        {
                            try
                            {
                                cnn.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            return username;
        }

        public bool PostTweet(ProfileService pflsrv)
        {
            bool retorno = true;
            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "INSERT INTO tb_Tweets VALUES (@iduser,@tweet,@date,@active)";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@iduser", ReturnIdUser(pflsrv.Username).ToString());
                    cmd.Parameters.AddWithValue("@tweet", pflsrv.Tweet);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@active", 1);

                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        retorno = true;
                    }
                    catch (Exception ex)
                    {
                        retorno = false;
                        throw ex;

                    }
                    finally
                    {
                        if (cnn.State == System.Data.ConnectionState.Open)
                        {
                            try
                            {
                                cnn.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }

            return retorno;

        }
        
        public List<ProfileService> ListTweets(string username)
        {
            List<ProfileService> listprofile = new List<ProfileService>();

            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "SELECT t.Tweet, t.Data, t.ID_User FROM tb_Tweets t INNER JOIN tb_Follow f on f.ID_Follow=t.ID_User WHERE ID_User=@iduser OR f.ID_Follower=@iduser ORDER BY t.Data desc";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@iduser", ReturnIdUser(username));

                    try
                    {
                        cnn.Open();

                        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ProfileService profile = new ProfileService();
                            profile.Tweet = dr.GetString(0);
                            profile.Data = dr.GetDateTime(1);
                            profile.Username = GetUsername(dr.GetInt32(2));
                            listprofile.Add(profile);
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cnn.State == System.Data.ConnectionState.Open)
                        {
                            try
                            {
                                cnn.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            return listprofile;
        }

        public List<ProfileService> SearchTweets(string term)
        {
            List<ProfileService> listprofile = new List<ProfileService>();

            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "SELECT Tweet, ID_User from tb_Tweets WHERE Tweet LIKE '%" + term + "%' ORDER BY data desc";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@term", "'%" + term + "'%");

                    try
                    {
                        cnn.Open();

                        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            ProfileService profile = new ProfileService();
                            profile.Tweet = dr.GetString(0);
                            profile.Username = dr.GetInt32(1).ToString();
                            listprofile.Add(profile);
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cnn.State == System.Data.ConnectionState.Open)
                        {
                            try
                            {
                                cnn.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }
            return listprofile;
        }

        public bool Following(int idfollower, int idfollow)
        {
            bool retorno = true;
            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "SELECT ID_Follower FROM tb_Follow WHERE ID_Follower=@idfollower AND ID_Follow=@idfollow";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@idfollower", idfollower);
                    cmd.Parameters.AddWithValue("@idfollow", idfollow);

                    try
                    {
                        cnn.Open();

                        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            retorno = true;
                        }
                        else
                        {
                            retorno = false;
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        retorno = false;
                        throw ex;

                    }
                    finally
                    {
                        if (cnn.State == System.Data.ConnectionState.Open)
                        {
                            try
                            {
                                cnn.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }

            return retorno;

        }

        public void Follow(int idfollower, int idfollow)
        {   using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "INSERT INTO tb_Follow VALUES (@idfollow,@idfollower)";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@idfollow", idfollow);
                    cmd.Parameters.AddWithValue("@idfollower", idfollower);

                    try
                    {
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;

                    }
                    finally
                    {
                        if (cnn.State == System.Data.ConnectionState.Open)
                        {
                            try
                            {
                                cnn.Close();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
            }

        }
    }
}
