﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            //clear the form
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            FullOrPartTime.ClearSelection();
            Jobs.ClearSelection();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //when submit button is clicked
            //gather entered data and display the values.

            //task 1: collect the entered data
            string fullname = FullName.Text;
            string email = EmailAddress.Text;
            string phone = PhoneNumber.Text;
            string time = FullOrPartTime.SelectedValue;

            //list data inputed
            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(email))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Message.Text = "Please enter your name and email";
            }
            string msg = string.Format("Name: {0}\n Email: {1}\n Phone: {2}\n Time: {3}\n",
                 fullname, email, phone, time);
            

            //to handle the check box list, we nee to TRAVERSE the list,
            //  and obtain the data that was selected.
            //during the traverese, create a string of jobs selected.
            //after the traverese, add the string of jobs OR an error message to 
            //  the other message data string
            //display the message string in the output message control

            string jobs = "Jobs: ";
            bool found = false;

            //list selected jobs:
            foreach (ListItem item in Jobs.Items)
            {
                if(item.Selected)
                {
                    found = true;
                    jobs += item.Value + ", ";
                }
            }
            // if no jobs were selected:
            if(!found)
            {
                //tell the user
                jobs += "No job selected";
            }


            //task 2: message the user

            Message.Text = msg + jobs;

            
        }
    }
}