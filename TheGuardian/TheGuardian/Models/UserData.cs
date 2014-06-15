using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TheGuardian.Models
{
    public class UserData
    {
        
        public string THREADTYPE { get; set; }
        public string  BODY { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string TYPE { get; set; }
        public string DATE_TIME { get; set; }
        public string CALL_DURATION { get; set; }
        public string TITLE { get; set; }
        public string URL { get; set; }
        public string LONGITUDE { get; set; }
        public string LATITUDE { get; set; }
        public string UserDataID { get; set; }
        public string USERID { get; set; }



    }

    
}