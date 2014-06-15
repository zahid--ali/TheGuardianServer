using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using TheGuardian.Models;
using System.Data.SqlClient;

namespace TheGuardian.Controllers
{
    public class UserController : ApiController
    {
        //
        // GET: /User/
        public string Get()
        {
            return "Welcome Zahid";
        }

        public string Get(int id)
        {
            return "Welcome " + id;
        }

        public UserLoginResponseModel Post(UserLoginModel model)
        {

            //string response = null;

            UserLoginResponseModel response = new UserLoginResponseModel();

            GuardianDBEntities db = new GuardianDBEntities();
            
            try
            {
                string modelType = model.Type;
                string username = model.Username;
                string password = model.Password;
                string email = model.Email;
                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = "Data Source=ZAHID-PC\\SQLEXPRESS;Initial Catalog=GuardianDB;Integrated Security=True";
                //con.Open();
                
                //login

                if (modelType.Equals("login"))
                {
                    //SqlCommand cmd = new SqlCommand("SELECT USERNAME,PASSWORD FROM TBL_LOGIN WHERE USERNAME='" + username + "' and PASSWORD='" + password + "'", con);
                    //SqlDataReader dr = cmd.ExecuteReader();

                    int count = (from zid in db.TBL_LOGIN
                                 where zid.USERNAME == username
                                 select zid).Count();


                    if (count.Equals(0))
                    {
                        response.Status = false;
                        response.Response = "Invalid Username";
                    }
                    else
                    {
                        int c = (from zid in db.TBL_LOGIN
                                 where zid.USERNAME == username && zid.PASSWORD == password
                                 select zid).Count();

                        if (c.Equals(0))
                        {
                            response.Status = false;
                            response.Response = "Invalid password";
                        }
                        else
                        {
                            response.Status = true;
                            response.Response = "Welcome MR. " + username;
                        }

                    }


                    //while (dr.Read()) { 
                    // if (dr["USERNAME"].ToString().Equals(username)){
                    //     if (dr["PASSWORD"].ToString().Equals(password))
                    //     {
                    //         response = "Welcome Mr. " + username;

                    //     }
                    //     else {

                    //         response = "Invalid Password";

                    //     }}
                    // else
                    //{
                    //    response = "Invalid Username";

                    //}
                    // dr.Close();
                    //}}
                    /*    if (username.Equals("Zahid"))
                        {
                            if (password.Equals("123456"))
                            {
                                response = "Welcome Mr. " + username;
                            }
                            else
                            {
                                response = "Invalid Password";
                            }
                        }
                        else
                        {
                            response = "Invalid Username";
                        }
                        */
                }
                else { 
                
                                                    //signup using sql
                //    SqlCommand cmd = new SqlCommand("SELECT USERNAME FROM TBL_LOGIN WHERE USERNAME='" + username + "' ", con);
                //    SqlDataReader dr = cmd.ExecuteReader();
                //    bool count = dr.HasRows;
                //    dr.Close();
                //    if (!count)
                //    {
                //        SqlCommand cmd1 = new SqlCommand("INSERT INTO TBL_LOGIN (USERNAME,PASSWORD) VALUES(@username,@password)", con);
                //        cmd1.Parameters.Add("@username", username);
                //        cmd1.Parameters.Add("@password", password);
                //        cmd1.ExecuteNonQuery();
                //        SqlCommand cmd2 = new SqlCommand("INSERT INTO TBL_USERDATA (NAME,EMAIL) VALUES(@name,@email)", con);
                //        cmd2.Parameters.Add("@name", name);
                //        cmd2.Parameters.Add("@email", email);
                //        cmd2.ExecuteNonQuery();
                //        response = username + "Welcome you have sussesfully signed up";

                //    }
                //    else {

                //        response = "User already Exist";
                //    }
                    //signup using entity framework
                    int count = (from zid in db.TBL_LOGIN
                                 where zid.USERNAME == username
                                 select zid).Count();


                    if (count.Equals(0))
                    {
                        TBL_LOGIN login = new TBL_LOGIN();
                        login.Email = email;
                        login.PASSWORD = password;
                        login.USERNAME = username;

                        db.AddToTBL_LOGIN(login);
                        db.SaveChanges();

                        response.Status = true;
                        response.Response = username + "You have sussesfully Registered";
                        response.UserID = login.ID;

                     
                       
                    }
                    else {
                        response.Status = false;
                        response.Response = "Username Already Exist";
                     
                    }

                
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Response = ex.Message.ToString();
            }

            return response;
        }

        public void Put()
        {

        }

        public void Delete()
        {

        }

    }
}
