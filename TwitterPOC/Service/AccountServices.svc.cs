using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    public class AccountServices : IAccountServices
    {
        public bool CreateAccount(AccountService accservice)
        {//sp_Account_NewUser
            
            bool retorno = true;
            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "INSERT INTO tb_Users VALUES (@name,@gender,@user,@pass,@creation,@lastaccess,@active)";
                
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@name", accservice.Name);
                    cmd.Parameters.AddWithValue("@gender", accservice.Gender);
                    cmd.Parameters.AddWithValue("@user", accservice.Username);
                    cmd.Parameters.AddWithValue("@pass", accservice.Password);
                    cmd.Parameters.AddWithValue("@creation", DateTime.Now);
                    cmd.Parameters.AddWithValue("@lastaccess", DateTime.Now);
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

        public string TryLogin(AccountService accservice)
        {
            string retorno = null;
            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ExternalDB"].ToString()))
            {
                string query = "SELECT Name, ID_User FROM tb_Users WHERE Username=@user AND Pass=@pass";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@user", accservice.Username);
                    cmd.Parameters.AddWithValue("@pass", accservice.Password);

                    try
                    {
                        cnn.Open();

                        System.Data.SqlClient.SqlDataReader dr = cmd.ExecuteReader();

                        int iduser = -1;
                        if (dr.HasRows)
                        {
                            dr.Read();
                            retorno = dr.GetString(0);
                            iduser = dr.GetInt32(1);
                        }
                        dr.Close();

                        if (retorno != null)
                        {
                            query = "UPDATE tb_Users SET LastAccess=@date WHERE ID_User=@iduser";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@iduser", iduser);
                            cmd.ExecuteNonQuery();
                        }
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

            return retorno;
        }
    }
}
