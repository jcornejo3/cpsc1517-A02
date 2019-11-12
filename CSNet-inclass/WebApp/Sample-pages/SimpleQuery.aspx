<%@ Page Title="Simple Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimpleQuery.aspx.cs" Inherits="WebApp.Sample_pages.SimpleQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Simple Query ny Primary Key</h1>


    <div class="row">
        <div class="col-md-6">
            <div class="offset-1">

                <asp:Label runat="server" Text="Enter a Region ID:" AssociatedControlID="RegionIDArg" ></asp:Label>&nbsp;&nbsp;
                <asp:TextBox runat="server" id="RegionIDArg" ></asp:TextBox>&nbsp;&nbsp;
                <asp:Button runat="server" Text="Fetch" id="Fetch" OnClick="Fetch_Click"/>&nbsp;&nbsp;
                <br /><br />
                <asp:Label id="MessageLabel" runat="server" ></asp:Label>

            </div>
        </div>


        <div class="col-md-6">

            <asp:Label runat="server" Text="Region ID:"></asp:Label>
            <asp:Label runat="server" id="RegionID"></asp:Label>
            <br /><br />
            <asp:Label runat="server" Text="Description"></asp:Label>&nbsp;&nbsp;
            <asp:Label runat="server" id="RegionDescription"></asp:Label>

        </div>

    </div>
</asp:Content>
