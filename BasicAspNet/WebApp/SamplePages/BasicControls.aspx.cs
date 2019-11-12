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
            DataCollection.Add(new DDLClass(1, "COMP 1008"));
            DataCollection.Add(new DDLClass(2, "CPSC-1517"));
            DataCollection.Add(new DDLClass(3, "DMIT-1508"));
            DataCollection.Add(new DDLClass(4, "DMIT-2018"));



            //sort the data collection for the ddl by program course name
            //Syntax: collectionname.Sort((x,y) => x.fieldname.Compare(y.fieldname))
            //collectionname is where your data resides (List<T>).
            //(x,y) represents any two values (records0 in your collection in any point in time
            // = (lamda) can be though of as "do the following to x and y" (delegate)
            //our delegate for lamda is compairing x and y on the fieldname
            // x CompaireTo y is an ascending sort
            // y CompairTo x is an descending sort
            DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

            //steps in loading your DDL:
            //assume the DataCollection is actually database data
            //a) assign the data source to the controll.
            CollectionChoiceList.DataSource = DataCollection; //just the data


            //<option value ="somevalue"> some text </option>
            //defince what somevalue and sometext is in the data collection

            //b.) indicate the dicplay field to the control
            CollectionChoiceList.DataTextField = nameof(DDLClass.DisplayField); //non-object style

            //c.) indicate the value field to the control
            CollectionChoiceList.DataValueField = nameof(DDLClass.ValueField); //this is perferable since that the program is
                                                                              //ensured that the correct object is called

            //d.)physically bind the data to the control
            CollectionChoiceList.DataBind();

            //optional prompt line??
            CollectionChoiceList.Items.Insert(0, "select...");


        }

        protected void SubmitNumberChoice_Click(object sender, EventArgs e)
        {
            //this is the submit button
            //to grab the contents of a control will DEPEND on the control access type
            //for TextBox, label, Literal use. Text
            //for list(RadioButton, DropdownList) you may use one of
            //  .SelectedValue (best), SelectedIndev(physical location), SelectItem.Text
            //for Checkbox use Checked (boolean)

            //for the most part, all data from a control returns as a string

            //since the control (object) is on the "RIGHT" side of an assignment statement, 
            // the object property uses its GET 

            string submitchoice = NumberChoice.Text;

            if(string.IsNullOrEmpty(submitchoice))
            {
                //"LEFT" side uses the property's SET
                MessageLabel.Text = "You did not enter a value for your program choice";
                //clean up selection 
                ChoiceList.ClearSelection();
                //another way:
                //Choice.SelectedIndex = -1; //-1 is a non existent index
                CollectionChoiceList.SelectedIndex = 0; //has my prompt
                AlterLabel.ForeColor = System.Drawing.Color.Black;
                DisplayDataRO.Text = "";

            }
            else
            {
                //"RIGHT" side uses the property's GET
                // you can set/get the radiobuttonlist choice by either using
                //  .SelectedValue or .SelectedIndex or .SelctedItem.Text
                //it is BEST to use .SelectedValue for positioning
                ChoiceList.SelectedValue = submitchoice;

                //place a check mark in the check box, if the chosen course is a program
                if(submitchoice.Equals("2") || submitchoice.Equals("4"))
                {
                    ProgrammingCourseActive.Checked = true;
                    AlterLabel.ForeColor = System.Drawing.Color.BlueViolet;
                }
                else
                {
                    ProgrammingCourseActive.Checked = false;
                    AlterLabel.ForeColor = System.Drawing.Color.Black;
                }

                //DDL can be positioned using:
                //  .SelectedValue or .SelectedIndex or .SelctedItem.Text
                //it is BEST to use .SelectedValue for positioning
                CollectionChoiceList.SelectedValue = submitchoice;

                //demonstration of what is obtaine by the different .Selectedxxxxxx
                DisplayDataRO.Text = CollectionChoiceList.SelectedItem.Text
                    + " at index " + CollectionChoiceList.SelectedIndex
                    + " having a value of " + CollectionChoiceList.SelectedValue;

            }
        }

        protected void CollectionSubmit_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "You pressed the link button selection submit. Ligma Nuts";

            //call out selection ddl 
            //string dropdownselection = CollectionChoiceList.SelectedValue;
            //if(string.IsNullOrEmpty(dropdownselection))
            //{
            //    MessageLabel.Text = "Ligma Nuts";
            //}
        }

      
    }
}