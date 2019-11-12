<%@ Page Title="Movie Library" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MovieLibraryForm.aspx.cs" Inherits="PracticeWebApp.Practice_Forms.MovieLibraryForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Movie Library</h1>
    </div>
    <div class="col col-md-12">
        <h3>Fill out the form below to add information on the movie for your movie</h3>
        <div class="col col-sm-6">
            <fieldset class="form-horizontal">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Check the invalid fields" CssClass="alert alert-danger" />

               
                <asp:Label ID="MovieTitlellbl" runat="server" Text="Title" AssociatedControlID="MovieTitle"></asp:Label>
                <asp:TextBox ID="MovieTitle" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredTitle" runat="server" 
                    ErrorMessage="*Enter title"
                    ControlToValidate="MovieTitle" SetFocusOnError="true"
                    ForeColor="DarkRed" Display="None">
                </asp:RequiredFieldValidator>

                <asp:Label ID="Yearlbl" runat="server" Text="Year" AssociatedControlID="YearInput"></asp:Label>
                <asp:TextBox ID="YearInput" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredYear" runat="server" 
                    ErrorMessage="*Enter the Year"
                    ControlToValidate="YearInput" SetFocusOnError="true"
                    ForeColor="DarkRed" Display="None">
                </asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeYear" runat="server" 
                    ErrorMessage="*Invalid year" ControlToValidate="YearInput"
                    MinimumValue="1000" MaximumValue="2019" Type="Integer">
                </asp:RangeValidator>


                
            </fieldset>
        </div>
    </div>
    <div class="col col-md-3">
        <asp:Button ID="Submitbtn" runat="server" Text="Add to Library" CausesValidation="true" OnClick="Submit_Clicked" />

        <asp:Button ID="Clearbtn" runat="server" Text="Clear" CausesValidation="false" OnClick="Clear_Clicked" />
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
    


</asp:Content>
