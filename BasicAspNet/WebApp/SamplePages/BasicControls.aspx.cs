using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        //create a global variable available to the entire page
        //that will temporarily represent data from  the database
        public static List<DDLClass> DataCollection;


        protected void Page_Load(object sender, EventArgs e)
        {
            //This event will happen EACH and EVERY time your page is executed
            //this event will happen BEFORE ANY of YOUR control events happen
            //this is a great place to initialise items(controls) that are common 
            //  to many events. and need to be done everytime

            //Example:
            // old messages should be cleared our on every pass
            //      you can empty the MessageLabel control under each event
            //  OR  DO it ONCE here for ALL events
            MessageLabel.Text = "";

            //this is a great place to do first time initialization of controls.
            // (simlilar to the else side of the "IsPost" from Razor)
            //-----
            if (!Page.IsPostBack) //or if(Page.IsPostBack == false)or if(Page.IsPostBack != true)
            {
                
                //load the DDL on the 1st pass
                //create an instane of a collection (List<T>); T = class DDLClass)
                //create 4 record instances for the collection
                //place the collection into the DDL
                //normaly, the collection is the result of a qury to your database
            }
            DataCollection = new List<DDLClass>();
            DataCollection.Add(new DDLClass(1, "COMP1008"));
            DataCollection.Add(new DDLClass(2, "CPSC1517"));
            DataCollection.Add(new DDLClass(3, "DMIT1508"));
            DataCollection.Add(new DDLClass(4, "DMIT2018"));

            //steps in loading your DDL:
            //assume the DataCollection is actually database data
            //a) assign the data source to the controll.
            CollectionChoiceList.DataSource = DataCollection
               


        }
    }
}