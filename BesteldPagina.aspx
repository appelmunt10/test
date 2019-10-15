<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="BesteldPagina.aspx.vb" Inherits="BesteldPagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
        <asp:Label ID="lblOrderTitel" runat="server" Text="Label" CssClass="AccountTussenTitels"></asp:Label></h3>
    <hr />
    <p>
        <asp:Label ID="lblOrderInfoTitel" runat="server" Text="Label" CssClass="lblOrderInfoTitel"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblOrderInfo" runat="server" Text="Lasdfdsfddfsdsfdfsdfgdfgfdsgdbel" CssClass="lblOrderInfo"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnDownloaden" runat="server" Text="Button" />
    </p>
</asp:Content>

