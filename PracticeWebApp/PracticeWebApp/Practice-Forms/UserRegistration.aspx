<%@ Page Title="User Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="PracticeWebApp.Practice_Forms.Practice_1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">\
    <div class="header">
        <h1>User Registration</h1>
    </div>
    <!--create a blockquote-->
    <div class="row row col-md-12">
        <div class ="alert alert-info">
            <blockquote>
                Please fill in the form below and click submit. After submitting
                the form, you will recive an email with link to confirm your
                registration. By clicking on theat link you will complete the 
                registration process
            </blockquote>
        </div>
        <p>Please ENTER your information:</p>
    </div>
    <!--Validation-->
    <asp:ValidationSummary ID="RegistrationValidation" runat="server" HeaderText="Please enter your information" />
    <!--First Name-->
    <div class="alert alert-danger">
    <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server" 
        ErrorMessage="First Name is required" 
        ControlToValidate="FirstName" 
        SetFocusOnError="True" Display="None">
    </asp:RequiredFieldValidator>

    <!--Last Name-->

    <asp:RequiredFieldValidator ID="RequiredLastName" runat="server" 
        ErrorMessage="Last Name is required"
        ControlToValidate="LastName" 
        SetFocusOnError="True" Display="None">
    </asp:RequiredFieldValidator>

    <!--UseName-->

    <asp:RequiredFieldValidator ID="RequiredUserName" runat="server" 
        ErrorMessage="UserName is required"     
        ControlToValidate="UserName" 
        SetFocusOnError="True" Display="None">
    </asp:RequiredFieldValidator>

    <!--Email Address-->
    <!--Email Must Be present-->
    <asp:RequiredFieldValidator ID="RequiredEmailAddress" runat="server" 
        ErrorMessage="Email is required"          
        ControlToValidate="Email" 
        SetFocusOnError="True" Display="None">
    </asp:RequiredFieldValidator>

    <!--Email Must have the appropriate format-->

    <asp:RegularExpressionValidator ID="EmailValidation" runat="server" 
        ErrorMessage="Wrong Email Format"
        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
        SetFocusOnError="True"
         ControlToValidate ="Email">
    </asp:RegularExpressionValidator>

   <!--confirm Email-->
    <!--Email confirmation Must Be present-->

     <asp:RequiredFieldValidator ID="RequiredConfirmedEmail" runat="server" 
        ErrorMessage="Please Confirm your email"          
        ControlToValidate="Email"
        SetFocusOnError="True" Display="None">
    </asp:RequiredFieldValidator>

    
    <!--Email Must have the appropriate format-->

    <asp:RegularExpressionValidator ID="RegularConfirmEmail" runat="server" 
        ErrorMessage="Wrong Email Format"
        ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
        SetFocusOnError="True"
         ControlToValidate ="Email">
    </asp:RegularExpressionValidator>

        <asp:Label ID="EmailCheck" runat="server" Text=""></asp:Label>
    <!--Compair Initial email input to confirm email input-->



    <!--Password-->
    <!--Password Must be present-->

    <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" 
        ErrorMessage="Password is required"         
        ControlToValidate="Password" 
        SetFocusOnError="True" Display="None">
    </asp:RequiredFieldValidator>

    
    <!--ConfirmPassword-->
    <!--Password must be present-->
    
     <asp:RequiredFieldValidator ID="RequiredConfrimPassword" runat="server" 
        ErrorMessage="Please Confirm your Password"          
        ControlToValidate="Password"
        SetFocusOnError="True" Display="None">
    </asp:RequiredFieldValidator>

    <!--confirm password must match the initial password-->
        <asp:Label ID="PasswordMatch" runat="server" Text="" ></asp:Label>

    <!--Required Field validators for not null field inputs:
        name.
        email - regular validator
        password
        terms and conditions
    -->
    
    <!--Compaire validations for confirming password and email.-->
    <!--Validation Summary-->
    
    
    </div>
    <!--Implement the user form entry textbox and checkboxes-->
    <!--Contain the form inside a fieldset-->
    <div class="row">
        <div class="col col-sm-6">
            <fieldset class="form-horizontal">
            
                <!--First Name, not null-->
                <asp:Label ID="FirstNamelbl" runat="server" Text="First Name" AssociatedControlID="FirstName"></asp:Label>
                <asp:TextBox ID="FirstName" runat="server" MaxLength="50"></asp:TextBox>

                <!--Last Name, not null-->
                <asp:Label ID="LastNamelbl" runat="server" Text="Last Name" AssociatedControlID="LastName"></asp:Label>
                <asp:TextBox ID="LastName" runat="server" MaxLength="50"></asp:TextBox>

                <!--User Name, not null-->
                <asp:Label ID="UserNamelbl" runat="server" Text="UserName" AssociatedControlID="UserName"></asp:Label>
                <asp:TextBox ID="UserName" runat="server" MaxLength="50"></asp:TextBox>

                <!--Email Address, not null-->
                <asp:Label ID="Emaillbl" runat="server" Text="Email Address" AssociatedControlID="Email"></asp:Label>
                <asp:TextBox ID="Email" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>

                <!--Confirm Email, not null. Must equal email address-->
                <asp:Label ID="ConfirmEmaillbl" runat="server" Text="Confirm Email" AssociatedControlID="ConfirmEmail"></asp:Label>
                <asp:TextBox ID="ConfirmEmail" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>

                <!--Password, not null.-->
                <asp:Label ID="Passwordlbl" runat="server" Text="Password" AssociatedControlID="Password"></asp:Label>
                <asp:TextBox ID="Password" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>


                <!--Confirm Password, not null. Must equal Password-->
                <asp:Label ID="ConfPasswordlbl" runat="server" Text="Confirm Password" AssociatedControlID="ConfPassword"></asp:Label>
                <asp:TextBox ID="ConfPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>

               
              
            </fieldset>
            <div class="col-md-6">
                <div class="col col-md-offset-2">
                 <!--Terms and description, not null. Must all information validated and confirmed-->            
                    <asp:CheckBox ID="TandC" runat="server" Text="accept the terms of this site"/>
                    <br /><br />
                <!--Submit Registration Button, bonus: send email-->
                    <div class="col col-md-offset-2">
                        <asp:Button ID="SubmitBtn" runat="server" Text="Submit Registration" OnClick="SubmitBtn_Click" />
                        <br /><br />
                        <asp:Button ID="ClearBtn" runat="server" Text="Clear Registration" 
                            OnClick="ClearBtn_Click"  ForeColor="#FF3300" BackColor="White" 
                            BorderColor="#CCCCCC" BorderStyle="Double" CssClass="btn-danger" CausesValidation="false"/>
                        <asp:Label ID="Message" runat="server"></asp:Label>
                        <asp:GridView ID="InformationList" runat="server"></asp:GridView>
                   </div>
                </div>
            </div>         
        </div>     
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
   
</asp:Content>
