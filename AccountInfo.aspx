<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AccountInfo.aspx.vb" Inherits="AccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
        <asp:Label ID="lblAccountTitel" runat="server" Text="Label" CssClass="AccountTussenTitels"></asp:Label></h3>
    <p>
        <asp:Table ID="Table1" runat="server" CssClass="InfoTabel">
            <asp:TableRow runat="server">
                <asp:TableCell>

                </asp:TableCell>
                <asp:TableCell runat="server">
              
                     <asp:Label ID="lblnaam" runat="server" Text="Label"  CssClass="AcountInfolbl"></asp:Label>:
                    <br />
                      <asp:Label ID="lblVoornaam" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>:
                    <br />
                     <asp:Label ID="lblemail" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>:
                    <br />
                      <asp:Label ID="lblgemeente" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>:
                    <br />
                    <asp:Label ID="lbladres" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>:
                    <br />
                     <asp:Label ID="lblpostcode" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>:
                    <br />
                    <asp:Label ID="lbltelefoon" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>:
                </asp:TableCell>
                <asp:TableCell runat="server">
                     <asp:Label ID="lblNaamtext" runat="server" Text="Label"  CssClass="AcountInfolbltxt"></asp:Label>
                     <asp:TextBox ID="txtNaam" runat="server" CssClass="AccountEditTXT" Visible="false"></asp:TextBox>
                         <br />
      
                     <asp:Label ID="lblvoornaamtext" runat="server" Text="Label" CssClass="AcountInfolbltxt"></asp:Label>
                     <asp:TextBox ID="txtvoornaam" runat="server" CssClass="AccountEditTXT" Visible="false"></asp:TextBox>
                         <br />
       
                     <asp:Label ID="lblemailtext" runat="server" Text="Label" CssClass="AcountInfolbltxt"></asp:Label>
                     <asp:TextBox ID="txtemail" runat="server" CssClass="AccountEditTXT" Visible="false"></asp:TextBox>
                         <br />
      
                     <asp:Label ID="lblgemeentetext" runat="server" Text="Label" CssClass="AcountInfolbltxt"></asp:Label>
                     <asp:TextBox ID="txtgemeente" runat="server" CssClass="AccountEditTXT" Visible="false"></asp:TextBox>
                         <br />
        
                     <asp:Label ID="lbladrestext" runat="server" Text="Label" CssClass="AcountInfolbltxt"></asp:Label>
                     <asp:TextBox ID="txtadres" runat="server" CssClass="AccountEditTXT" Visible="false"></asp:TextBox>
                         <br />
       
                     <asp:Label ID="lblpostcodetext" runat="server" Text="Label" CssClass="AcountInfolbltxt"></asp:Label>
                     <asp:TextBox ID="txtpostcode" runat="server" CssClass="AccountEditTXT" Visible="false"></asp:TextBox>
                         <br />
        
                     <asp:Label ID="lbltelefoontext" runat="server" Text="Label" CssClass="AcountInfolbltxt"></asp:Label>
                     <asp:TextBox ID="txttelefoon" runat="server" CssClass="AccountEditTXT" Visible="false"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
       
         
             <br />
        <br />
    </p>
    <hr />
    <h3>
        <asp:Label ID="lblAccountNieuwWWTitel" runat="server" Text="Label" CssClass="AccountTussenTitels"></asp:Label></h3>
    <p>
        <asp:Table ID="Table2" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    
                </asp:TableCell>
                <asp:TableCell>
                 <asp:Label ID="lbloldpassword" runat="server" Text="Label"  CssClass="AcountInfolbl"></asp:Label>:
                    <br />
                    <asp:Label ID="lblnewpassword" runat="server" Text="Label"  CssClass="AcountInfolbl"></asp:Label>:
                   
                </asp:TableCell>
                <asp:TableCell>
                     <asp:TextBox ID="txtoldpassword" runat="server" CssClass="AccountEditTXT" TextMode="Password"></asp:TextBox>
             <br />
         <asp:TextBox ID="txtnewpassword" runat="server" CssClass="AccountEditTXT" TextMode="Password"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
               <br />
                   <asp:Button ID="btnNewPasswoord" runat="server" Text="Button" />
        
                </asp:TableCell>
                </asp:TableRow>
        </asp:Table>
        
        <asp:Label ID="lblOldpassWrong" runat="server" ForeColor="Red" Text="Label" 
            Visible="False"></asp:Label>
        
    </p>
    <hr />
    <h3>
        <asp:Label ID="lblOverzichtOrders" runat="server" Text="Label" CssClass="AccountTussenTitels"></asp:Label></h3>
    <hr />
    <p><asp:Label ID="lblOverzichtInfo" runat="server" Text="Label"></asp:Label></p>    
    <asp:DropDownList ID="ddlOrders" runat="server" CssClass="ddlOrders"></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnDownloaden" runat="server" Text="Download" CssClass="btnDownload"/>
    </asp:Content>

