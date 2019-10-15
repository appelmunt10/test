<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NewAccount.aspx.vb" Inherits="NewAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>
        <asp:Label ID="lblNewAccount" runat="server" Text="NieuweAccount" CssClass="AccountTussenTitels"></asp:Label></h3>
    <hr />
    <br />
    <asp:Label ID="lblError" runat="server" Text="Label" CssClass="lblInfo" Visible="false" ></asp:Label>
    <br />
      <asp:Table ID="Table1" runat="server" CssClass="InfoTabel">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell>

                </asp:TableCell>
                <asp:TableCell ID="TableCell1" runat="server">
                  
                    <br />
                    <asp:Label ID="lblUsername" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>
                    <br />
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
                    <br />
                    <br />  
                    <asp:Label ID="lblWachtwoord" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>
                    <br />
                    <asp:Label ID="lblWachtwoordAgain" runat="server" Text="Label" CssClass="AcountInfolbl"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server">
                    <br />
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="AccountEditTXT" Visible="true"></asp:TextBox>
                    <br />
                     <asp:TextBox ID="txtNaam" runat="server" CssClass="AccountEditTXT" Visible="true"></asp:TextBox>
                         <br />
      
                 
                     <asp:TextBox ID="txtvoornaam" runat="server" CssClass="AccountEditTXT" Visible="true"></asp:TextBox>
                         <br />
       
                 
                     <asp:TextBox ID="txtemail" runat="server" CssClass="AccountEditTXT" Visible="true"></asp:TextBox>
                         <br />
      
                   
                     <asp:TextBox ID="txtgemeente" runat="server" CssClass="AccountEditTXT" Visible="true"></asp:TextBox>
                         <br />
        
                  
                     <asp:TextBox ID="txtadres" runat="server" CssClass="AccountEditTXT" Visible="true"></asp:TextBox>
                         <br />
       
                    
                     <asp:TextBox ID="txtpostcode" runat="server" CssClass="AccountEditTXT" Visible="true" MaxLength="4"></asp:TextBox>
                         <br />
        
                 
                     <asp:TextBox ID="txttelefoon" runat="server" CssClass="AccountEditTXT" Visible="true" MaxLength="10" ></asp:TextBox>
                    <br />
                    <br />
                    <asp:TextBox ID="txtWachtwoord" runat="server" CssClass="AccountEditTXT" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtWachtwoordAgain" runat="server" CssClass="AccountEditTXT" TextMode="Password"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
          <asp:TableRow>
              <asp:TableCell>

              </asp:TableCell>
              <asp:TableCell>

              </asp:TableCell>
              <asp:TableCell>
                  <br />
                  <asp:Button ID="btnMaakAccount" runat="server" Text="Button" CssClass="btnMaakAccount" />
              </asp:TableCell>
          </asp:TableRow>
                    </asp:Table>
</asp:Content>

