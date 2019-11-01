<%@ Page Title="Contest Entries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestEntry.aspx.cs" Inherits="WebApp.SamplePages.ContestEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Contest Entry</h1>
    </div>

    <div class="row col-md-12">
        <div class="alert alert-info">
            <blockquote style="font-style: italic">
                This illustrates some simple controls to fill out an entry form for a contest. 
                This form will use basic bootstrap formatting and illustrate Validation.
            </blockquote>
            <p>
                Please fill out the following form to enter the contest. This contest is only available to residents in Western Canada.
            </p>

        </div>
    </div>
    <%-- Validation controls:
        They could be placed beside the appropriate input field
        HOWEVER this ould cause bootwrap to fail
        THEREFORE the controls will be grouped before the form--%>
    <asp:CompareValidator ID="CompareCheckAnswer" runat="server" ErrorMessage="Check Answer: DataType Compare" Display="None" ForeColor="#CC3300" ControlToValidate="CheckAnswer" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>


    <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server" ErrorMessage="Please enter your First Name" Display="None" ForeColor="#FF3300" Font-Bold="True" SetFocusOnError="True" ToolTip="eg. Joe " ControlToValidate="FirstName">*</asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredLastName" runat="server" ErrorMessage="Please enter your Last Name" Display="None" ForeColor="#CC3300" Font-Bold="True" ControlToValidate="LastName" SetFocusOnError="True" ToolTip="eg. Momma">*</asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredStreet1" runat="server" ErrorMessage="Enter a Street Address" Display="None" Text="*" ControlToValidate="StreetAddress1" SetFocusOnError="True" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    
    <asp:RequiredFieldValidator ID="RequiredCity" runat="server" ErrorMessage="Enter a City" SetFocusOnError="True" ControlToValidate="City" Text="*" Display="None" ForeColor="#CC3300"></asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredPostalCode" runat="server" ErrorMessage="Enter a PostalCode" Display="None" ControlToValidate="PostalCode" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegExPostalCode1" runat="server" ErrorMessage="Invalid PostalCode Format (T6Y7U0)" Display="None" ForeColor="#CC3300" ControlToValidate="PostalCode" Text="*" ValidationExpression="[a-zA-Z][0-9][a-zA-Z]-[0-9][a-zA-Z][0-9]" SetFocusOnError="True"></asp:RegularExpressionValidator>

    
    <asp:RequiredFieldValidator ID="RequiredEmai" runat="server" ErrorMessage="Enter an Email Address" BorderStyle="None" Display="None" Text="*" ControlToValidate="EmailAddress" ForeColor="#CC3300"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegExEmailAddress" runat="server" ErrorMessage="Invalid email @email.com" Display="None" ForeColor="#CC3300" ControlToValidate="EmailAddress" Text="*" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" SetFocusOnError="True"></asp:RegularExpressionValidator>
    
    <%--Sample of a range validation using the nullable field StreetAddress 2--%>
    <asp:RangeValidator ID="RangeStreetAddress2" ErrorMessage="Street Address 2 is limited to a number between 0 and 100" Display="None", ForeColor="#990000" SetFocusOnError="true" ControlToValidate="StreetAddress2" MinimumValue="0" MaximumValue="100" Type="Integer" runat="server" />
    <%--Validation summary control to display the validation--%>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <div class="row">
        <div class ="col-md-6">
            <fieldset class="form-horizontal">
                <legend>Application Form</legend>

                <asp:Label ID="Label1" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
                <asp:TextBox ID="FirstName" runat="server" 
                    ToolTip="Enter your first name." MaxLength="25"></asp:TextBox> 
                  
                 <asp:Label ID="Label6" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
                <asp:TextBox ID="LastName" runat="server" 
                    ToolTip="Enter your last name." MaxLength="25"></asp:TextBox> 
                        
                <asp:Label ID="Label3" runat="server" Text="Street Address 1"
                     AssociatedControlID="StreetAddress1"></asp:Label>
                <asp:TextBox ID="StreetAddress1" runat="server" 
                    ToolTip="Enter your street address." MaxLength="75"></asp:TextBox> 
                  
                  <asp:Label ID="Label7" runat="server" Text="Street Address 2"
                     AssociatedControlID="StreetAddress2"></asp:Label>
                <asp:TextBox ID="StreetAddress2" runat="server" 
                    ToolTip="Enter your additional street address." MaxLength="75"></asp:TextBox> 
                  <br />
                 <asp:Label ID="Label8" runat="server" Text="City"
                     AssociatedControlID="City"></asp:Label>
                <asp:TextBox ID="City" runat="server" 
                    ToolTip="Enter your City name" MaxLength="50"></asp:TextBox> 
                  
                 <asp:Label ID="Label9" runat="server" Text="Province"
                     AssociatedControlID="Province"></asp:Label>
                <asp:DropDownList ID="Province" runat="server" Width="75px">
                    <asp:ListItem Value="AB" Text="AB"></asp:ListItem>
                     <asp:ListItem Value="BC" Text="BC"></asp:ListItem>
                     <asp:ListItem Value="MN" Text="MN"></asp:ListItem>
                     <asp:ListItem Value="SK" Text="SK"></asp:ListItem>
                </asp:DropDownList>
                  
                 <asp:Label ID="Label10" runat="server" Text="Postal Code"
                     AssociatedControlID="PostalCode"></asp:Label>
                <asp:TextBox ID="PostalCode" runat="server" 
                    ToolTip="Enter your postal code"  MaxLength="6"></asp:TextBox> 
                 
                <asp:Label ID="Label2" runat="server" Text="Email"
                     AssociatedControlID="EmailAddress"></asp:Label>
                <asp:TextBox ID="EmailAddress" runat="server" 
                    ToolTip="Enter your email address"
                     TextMode="Email"></asp:TextBox> 
                  
              </fieldset>   
           <p>Note: You must agree to the contest terms in order to be entered.
               <br />
               <asp:CheckBox ID="Terms" runat="server" Text="I agree to the terms of the contest" />
               <asp:HyperLink ID="TermsAndCondition" runat="server">Terms and conditions</asp:HyperLink>
               
           </p>

            <p>
                Enter your answer to the following calculation instructions:<br />
                Multiply 15 times 6<br />
                Add 240<br />
                Divide by 11<br />
                Subtract 15<br />
                <asp:TextBox ID="CheckAnswer" runat="server" ></asp:TextBox>
            </p>
        </div>
        <div class="col-md-6">   
            <div class="col-md-offset-2">
                <p>
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />&nbsp;&nbsp;
                    <asp:Button ID="Clear" runat="server" Text="Clear" CausesValidation="true" OnClick="Clear_Click"  />
                </p>
                <asp:Label ID="Message" runat="server" ></asp:Label>
                <br /> <br />
               
                <asp:GridView ID="EntrieList" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
