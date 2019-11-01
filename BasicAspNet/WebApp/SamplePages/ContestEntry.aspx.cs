using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        public static List<CEntry> Entries; //temporary database
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";

            if(!Page.IsPostBack)
            {
                Entries = new List<CEntry>();
            }
        }

        //submit button
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //you may have logical testing to do
                //if we have prompt line from our ddl, test for it
                //our entry form has a Terms acceptance
                //  accepted: store data enrty 
                //          display
                //  not accepted, tell user you cant proceed
                //the term data and check answer data will NOT be saved
                
                if(Terms.Checked)
                {
                    ////--one way--
                    ////create new instance
                    //CEntry theEntry = new CEntry();
                    ////load new instance
                    //theEntry.FirstName = FirstName.Text;
                    ////so on..
                    //// add to collection data.
                    //Entries.Add(theEntry);

                    //use the greedy constructor.
                    //create, load, add in one statement
                    Entries.Add(new CEntry(FirstName.Text,
                                            LastName.Text,
                                            StreetAddress1.Text,
                                            string.IsNullOrEmpty(StreetAddress2.Text)? null: StreetAddress2.Text,
                                            City.Text,
                                            Province.SelectedValue,
                                            PostalCode.Text,
                                            EmailAddress.Text));
                    EntryList.DataSource = Entries;
                    EntryList.DataBind();
                }
                else
                {
                    Message.Text = "You did not agree to the entry terms, enrty rejected.";
                   
                }
            }
            //store data entered.
            
        }
        //clear button
        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";

        }
    }
}