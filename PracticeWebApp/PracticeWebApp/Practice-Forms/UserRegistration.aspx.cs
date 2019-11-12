using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeWebApp.Practice_Forms
{
    public partial class Practice_1 : System.Web.UI.Page
    {
        public static List<UserRegistry> Information;
        protected void Page_Load(object sender, EventArgs e)
        {

            Message.Text = "";
            if(!Page.IsPostBack)
            {
                Information = new List<UserRegistry>();
            }
        }


        //Set the clear button:
        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            
            //when pressed
            //clear entries:
            FirstName.Text = "";
            LastName.Text = "";
            UserName.Text = "";
            Email.Text = "";
            ConfirmEmail.Text = "";
            Password.Text = "";
            ConfPassword.Text = "";
            TandC.Checked = false;

            Information.Clear();
            
        }

        //what happends when we press the submit button?
        //I want:
        // To Make sure that all inputs are present and valid.
        //  if valid:
        //      Store values and display them in a temporary Database list grid:

        

        //  if not valid:
        //Display the error messages on the side
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            
           //Task 1: check if inputs Valid and present.
           //this is possible from the validators that was implemented on the html web form.
           if(Page.IsValid)
            {
                //Task 2: terms check box must be checked
                if (TandC.Checked)
                {
                    //add information that is currently inputted in the form into the grid view.
                    Information.Add(new UserRegistry(
                                        FirstName.Text,
                                        LastName.Text,
                                        UserName.Text,
                                        Email.Text,
                                        "private information"));
                    //compair email

                    if (!string.IsNullOrEmpty(ConfirmEmail.Text) || !string.IsNullOrEmpty(ConfPassword.Text))
                    {
                        if (ConfirmEmail.Text != Email.Text)
                        {
                            EmailCheck.Text = "Email does not match.";
                        }

                        if (ConfPassword.Text != Password.Text)
                        {
                            PasswordMatch.Text = "Password does not match";
                        }
                    }

                    else if(ConfPassword.Text == Password.Text && ConfirmEmail.Text == Email.Text)
                    {
                        PasswordMatch.Text = "";
                        EmailCheck.Text = "";
                        //if theres is anything in the information list, and a username entered matched one of them,
                        //then don't allow the user to enter.
                        if (Information.Count() != 0)
                        {
                            foreach (UserRegistry item in Information)
                            {
                                if (UserName.Text == item.UserName)
                                {
                                    RequiredUserName.Text = "Username is already taken. please try another";
                                }
                            }
                        }
                        InformationList.DataSource = Information;
                        InformationList.DataBind();
                    }
                } 

            }



        }
    }
}