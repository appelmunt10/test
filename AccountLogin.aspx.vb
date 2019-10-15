Imports System.Data.OleDb
Partial Class Account
    Inherits System.Web.UI.Page
    Dim cmd As New OleDbCommand
    Dim cnn As New OleDbConnection
    Dim constr As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source= C:\Users\ozcan\Desktop\USB Stick\SFC Documenten backup\Website GIP\V3\Database\dbGip1.mdb"

    Protected Sub Login1_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        Dim cmd As New OleDbCommand
        Dim cnn As New OleDbConnection
        Dim niveau As Integer
        Dim wwHash As String
        cnn.ConnectionString = constr
        cmd.Connection = cnn
        cnn.Open()

        wwHash = FormsAuthentication.HashPasswordForStoringInConfigFile(Login1.Password, "md5").ToLower

        cmd.CommandText = "Select niveau from tblusers where gebruikersnaam='" & Login1.UserName & "' and wachtwoord='" & wwHash & "'"




        If cmd.ExecuteScalar Is Nothing Then
            Session("Niveau") = 3
        Else
            niveau = cmd.ExecuteScalar
            Session("niveau") = niveau

            cmd.CommandText = "Select id from tblusers where gebruikersnaam='" & Login1.UserName & "' and wachtwoord='" & wwHash & "'"
            Session("GebruikerID") = cmd.ExecuteScalar

            Server.Transfer("AccountInfo.aspx")
        End If

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblError.Visible = False
        cnn.ConnectionString = constr
        cmd.Connection = cnn

        cnn.Open()

        If Not Session("Taal") = String.Empty Then

            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar

            cmd.CommandText = "Select value from tbltranslations where key='login.usernametext' and TaalID=" & TaalID
            Login1.UserNameLabelText = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='login.passwordtext' and TaalID=" & TaalID
            Login1.PasswordLabelText = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='login.buttontext' and TaalID=" & TaalID
            Login1.LoginButtonText = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='login.failuretext' and TaalID=" & TaalID
            Login1.FailureText = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Login.lblErrorAddCart' and TaalID=" & TaalID
            lblError.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Login.lblLoginInfo' and TaalID=" & TaalID
            lblLoginInfo.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Login.btnRegistreren' and TaalID=" & TaalID
            btnRegistreren.Text = cmd.ExecuteScalar

        Else
            cmd.CommandText = "Select value from tbltranslations where key='login.usernametext' and TaalID=2"
            Login1.UserNameLabelText = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='login.passwordtext' and TaalID=2"
            Login1.PasswordLabelText = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='login.buttontext' and TaalID=2"
            Login1.LoginButtonText = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='login.failuretext' and TaalID=2"
            Login1.FailureText = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Login.lblErrorAddCart' and TaalID=2"
            lblError.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Login.lblLoginInfo' and TaalID=2"
            lblLoginInfo.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Login.btnRegistreren' and TaalID=2"
            btnRegistreren.Text = cmd.ExecuteScalar

        End If

        If Session("AddCartLoggedFalse") = 1 Then
            lblError.Visible = True
        End If
        Session("AddCartLoggedFalse") = 0
    End Sub

    Protected Sub btnRegistreren_Click(sender As Object, e As EventArgs) Handles btnRegistreren.Click
        Server.Transfer("NewAccount.aspx")
    End Sub
End Class
