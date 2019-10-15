<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Product.aspx.vb" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    <style type="text/css">
        .auto-style1 {
            width: 502px;
            margin-left: 40px;
        }
        .auto-style2 {
            width: 247px;
        }
    </style>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <br />
    <br />
    <table style="position: relative; top: -2px; left: 53px; width: 1197px">
        <tr>
            <td rowspan="3" class="auto-style2">
                <asp:Image ID="imgProduct" runat="server" CssClass="DetailsImage" />
            </td>
            <td class="auto-style1" >
                <h1>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblDescription" runat="server" CssClass="DetailsDescription"></asp:Label>
            </td>
          
        </tr>
        <tr>
            <td class="auto-style1" >Nr:<asp:Label ID="lblItemNr" runat="server" Style="font-style: italic"></asp:Label>
                <br />
                <br />  
                <asp:Label ID="lblPrice" runat="server" CssClass="DetailsPrice"></asp:Label><br />
                  <br /> 
                <asp:Label ID="lblHoeveelheid" runat="server" Text="Label"></asp:Label>:<asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList><br />
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Product" />
                <br />
                <asp:Button ID="btnAanpassen" runat="server" Text="Pas aan" CssClass="button" Visible="false"/>
                <br />
                <asp:Button ID="btnVerwijderen" runat="server" Text="Verwijder" CssClass="buttonD" Visible="False" Height="42px" Width="97px" />
                
            </td>
        </tr>
        <tr>
              <td>
            </td>
              <td>
                     <asp:Label ID="lblResult" runat="server" Text="" Visible="False"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>

