using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using TheGuardian.Models;

namespace TheGuardian.Controllers
{
    public class UserDataController : ApiController
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

        public UserDataResponseModel Post(UserData model)
        {

            //string response = null;

            UserDataResponseModel response = new UserDataResponseModel();

            GuardianDBEntities db = new GuardianDBEntities();

            try
            {
                        TBL_USERRECORD data = new TBL_USERRECORD();
                        data.THREAD_TYPE = model.THREADTYPE;
                        data.MSG_BODY = model.BODY;
                data.PHONE_NUMBER = model.PHONE_NUMBER;
                data.TYPE = model.TYPE;
                data.DATE_TIME = model.DATE_TIME; 
                data.CALL_DURATION = model.CALL_DURATION;
                data.LINK_TITLE = model.TITLE;
                data.LINK_URL = model.URL;
                data.LONGITUDE = model.LONGITUDE;
                data.LATITUDE= model.LATITUDE;
                data.UserID = model.USERID;
                data.UserDataID = model.UserDataID;


                        db.AddToTBL_USERRECORD(data);
                        db.SaveChanges();

                        response.Status = true;
                        response.UserDataID = model.UserDataID;
                      


                }
            
            catch (Exception ex)
            {
                response.Status = false;
               
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
