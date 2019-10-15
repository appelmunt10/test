<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Cart.aspx.vb" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
        <asp:Label ID="lblTitleCart" runat="server" Text="Winkelwagen" CssClass="AccountTussenTitels"></asp:Label></h3>
    <p>
<asp:Label ID="lblOpmerking" runat="server" Text="Label" ></asp:Label>
    </p>
    
    <asp:Label ID="lblInfo" runat="server" Text="gfdfgf" CssClass="lblInfo"></asp:Label>
    <br />
    <asp:Label ID="lblError" runat="server" Text="Ladsfdsfdsdfsdbel" CssClass="lblInfo" Visible="false"></asp:Label>
    <hr />
    <asp:Panel ID="Mainpanel" runat="server">
        <asp:Panel ID="ControlPanel" runat="server">
        </asp:Panel>
    </asp:Panel>
    <br />
    <asp:Label ID="lbltxtTotaal" runat="server" Text="Totaal" CssClass="TxtTotaal"></asp:Label>
    <asp:Label ID="lblTotaleHoeveelheid" runat="server" Text="0" CssClass="TotaleHoeveelheid"></asp:Label>
    <asp:Label ID="lblTotaalPrijs" runat="server" Text="0" CssClass="TotaalPrijs" Height="18px"></asp:Label>
    <br />
        
     <div style="clear:both"></div>
    <asp:Button ID="btnBestellen" runat="server" Text="Button" CssClass="btnBestellen" />
    <br />
    <br />
    <br />
    
</asp:Content>

