<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AccountLogin.aspx.vb" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

       <asp:Label ID="lblError" runat="server" Text="sdfsdsfsdf" CssClass="lblInfo" Visible="false"></asp:Label>
    <br />
    <asp:Login ID="Login1" CssClass="LoginControl" runat="server" DisplayRememberMe="False" Orientation="Horizontal" TextLayout="TextOnTop" TitleText="">
</asp:Login>
    <asp:Label ID="lblLoginInfo" runat="server" Text="dsfsdgsfgs" CssClass="lblLoginInfo"></asp:Label>
    <br />
    <asp:Button ID="btnRegistreren" runat="server" Text="Button" CssClass="btnRegistreren"/>
    <br />
    <br />
</asp:Content>

