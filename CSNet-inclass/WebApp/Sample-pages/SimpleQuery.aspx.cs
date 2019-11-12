
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional namespaces
using NorthwindSystem.BLL;
using NorthwindSystem.Data;
#endregion


namespace WebApp.Sample_pages
{
    public partial class SimpleQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //empty old messages.
            MessageLabel.Text = "";
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            //if we pressed
            if(string.IsNullOrEmpty(RegionIDArg.Text))
            {
                
                MessageLabel.Text = "Enter a region id value.";
            }
            else
            {
                int regionid = 0;
                if(int.TryParse(RegionIDArg.Text, out regionid))
                {
                    if(regionid > 0)
                    {
                        //validation is good
                        //anytime you plan on "leaving" the web project for the application
                        //      system project, you MUST use a try/catch.
                        try
                        {
                            //standard simple query

                            //create an instance of the desired controller
                            RegionController sysmgr = new RegionController();
                            //create a recieving instance for your data
                            Region info = null;
                            //make your call to the BLL cotroller method.

                            info = sysmgr.Regions_FindByID(regionid);

                            //test for resul
                            //single record test for null
                            //List<T> text for .Count
                            if(info == null)
                            {
                                MessageLabel.Text = "Region ID not found";
                                RegionID.Text = "";
                                RegionDescription.Text = "";
                            }
                            else
                            {
                                RegionID.Text = info.RegionID.ToString();
                                RegionDescription.Text = info.RegionDescription;
                            }

                        }
                        catch (Exception ex)
                        {

                            MessageLabel.Text = ex.Message;
                        }
                    }
                    else
                    {
                        //if region !> 0:
                        MessageLabel.Text = "RegionID must be > 0";
                    }
                }
                else
                {
                    MessageLabel.Text = "RegionID must be a number.";
                }
            }
        }
    }
}