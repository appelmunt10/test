Imports System.Data.OleDb
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim constr As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source= C:\Users\ozcan\Desktop\USB Stick\SFC Documenten backup\Website GIP\V3\Database\dbGip1.mdb"
    Dim cmd As New OleDbCommand
    Dim cnn As New OleDbConnection
       



  

    Protected Sub imgEng_Click(sender As Object, e As ImageClickEventArgs) Handles imgEng.Click
        Session("Taal") = "Engels"
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strLogin, strLogin2 As String
        cnn.ConnectionString = constr
        cmd.Connection = cnn
        cnn.Open()
        If Not Session("Taal") = String.Empty Then
            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar

            cmd.CommandText = "Select value from tbltranslations where key='homepage.title' and taalID=" & TaalID
            HyperLink1.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='homepage.products' and taalID=" & TaalID
            HyperLink2.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='homepage.aboutus' and taalID=" & TaalID
            HyperLink3.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Copyright.text' and taalID=" & TaalID
            lblCopyrights.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='master.btnCart' and taalID=" & TaalID
            btnCart.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='master.btnlogin' and taalID=" & TaalID
            strLogin = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='master.btnlogin2' and taalID=" & TaalID
            strLogin2 = cmd.ExecuteScalar

        Else
            cmd.CommandText = "Select value from tbltranslations where key='homepage.title' and taalID=2"
            HyperLink1.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='homepage.products' and taalID=2"
            HyperLink2.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='homepage.aboutus' and taalID=2"
            HyperLink3.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Copyright.text' and taalID=2"
            lblCopyrights.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='master.btnCart' and taalID=2"
            btnCart.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='master.btnlogin' and taalID=2"
            strLogin = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='master.btnlogin2' and taalID=2"
            strLogin2 = cmd.ExecuteScalar

        End If

        If Session("GebruikerID") <> 0 Then
            btnLogin.Text = strLogin2
        Else
            btnLogin.Text = strLogin
        End If

        cnn.Close()

    End Sub

    Protected Sub imgNed_Click(sender As Object, e As ImageClickEventArgs) Handles imgNed.Click
        Session("Taal") = "nederlands"
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub btnCart_Click(sender As Object, e As EventArgs) Handles btnCart.Click
        Server.Transfer("Cart.aspx")
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Session("GebruikerID") = 0 Then
            Server.Transfer("AccountLogin.aspx")
        Else
            Session("gebruikerID") = 0
            Server.Transfer("Home.aspx")
        End If
    End Sub
End Class

