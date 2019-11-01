using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class CEntry
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string PostalCode{ get; set; }
        public string EmailAddress { get; set; }
        public CEntry() { }

        public CEntry(string firstname, string lastname, 
                        string streetaddres1, string streetaddress2, 
                        string city, string postalcode, string emailaddress)
        {
            FirstName = firstname;
            LastName = lastname;
            StreetAddress1 = streetaddres1;
            StreetAddress2 = streetaddress2;
            City = city;
            PostalCode = postalcode;
            EmailAddress = emailaddress;
        }

    }
}