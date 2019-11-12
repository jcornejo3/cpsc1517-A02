using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click1(object sender, EventArgs e)
        {
            Submit.Text = "Boo";
            Submit.Font.Size = 100;
            Submit.ForeColor = System.Drawing.Color.Crimson;
            Label1.Text = "Eat Homework";
            Label1.Font.Size = 200;
        }
    }
}