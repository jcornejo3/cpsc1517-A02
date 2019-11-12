using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.SamplePages
{
    public class JobApps
    {
        public string Fullname { get; set; }
        public string EmailAddres { get; set; }
        public string PhoneNumber { get; set; }
        public string FullOrPartTime { get; set; }
        public string Jobs { get; set; }

        public JobApps() { }//constructor

        public JobApps(string fullname, string email, string phone, string time, string jobs)
        {
            Fullname = fullname;
            EmailAddres = email;
            PhoneNumber = phone;
            FullOrPartTime = time;
            Jobs = jobs;
        }

    }
}