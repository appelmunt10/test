<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Producten.aspx.vb" Inherits="Producten" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="Sorting">
      <asp:CheckBox ID="ckbSorteren" runat="server" Text="Sorteren" AutoPostBack="true" />
        <asp:Label ID="lblSortPrijs" runat="server" Text="Price" CssClass="LabelsSorteren" Visible="False"></asp:Label>
        <asp:DropDownList ID="ddlPrijs" runat="server" CssClass="ddlSorteren" AutoPostBack="True" Visible="False"></asp:DropDownList>
        <asp:Label ID="lblFabrikant" runat="server" Text="Fabrikant" CssClass="LabelsSorteren" Visible="False"></asp:Label>
        <asp:DropDownList ID="ddlFabrikant" runat="server" CssClass="ddlSorteren" AutoPostBack="True" Visible="False"></asp:DropDownList>
        <asp:Label ID="lblCategorie" runat="server" Text="Categorie" CssClass="LabelsSorteren" Visible="False"></asp:Label>
        <asp:DropDownList ID="ddlCategorie" runat="server" CssClass="ddlSorteren" Visible="False" AutoPostBack="True"></asp:DropDownList>
    </div>
<hr />
    <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Panel ID="MainPanel" runat="server">
    </asp:Panel>
    <div style="clear:both"></div>
    </asp:Content>

