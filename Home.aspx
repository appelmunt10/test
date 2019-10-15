<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <h3><asp:Label ID="lblHomeTitle" runat="server" Text="Label" CssClass="AccountTussenTitels"></asp:Label></h3>
    <hr />
    <p>
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label></p>
    </asp:Content>

