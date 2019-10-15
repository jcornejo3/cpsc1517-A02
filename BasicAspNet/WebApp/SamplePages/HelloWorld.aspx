<%@ Page Title="Hello World" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="WebApp.SamplePages.HelloWorld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Hello Boys</h1>
    <asp:Label ID="Label1" runat="server" Text="Hi there! Welcome to the world of easy"></asp:Label>
    <asp:Button ID="Submit" runat="server" Text="Accept" ForeColor="#CC3300" OnClick="Submit_Click1" />
</asp:Content>
