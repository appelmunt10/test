Imports System.Data.OleDb
Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Partial Class NewAccount
    Inherits System.Web.UI.Page

    Dim cmd As New OleDbCommand
    Dim cnn As New OleDbConnection
    Dim Reader As OleDbDataReader
    Dim constr As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source= C:\Users\ozcan\Desktop\USB Stick\SFC Documenten backup\Website GIP\V3\Database\dbGip1.mdb"
    Dim ValidateEmpty, ValidateSame, ValidateSameName As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        cnn.ConnectionString = constr
        cmd.Connection = cnn
        cnn.Open()

        If Not Session("Taal") = String.Empty Then
            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar

            cmd.CommandText = "Select value from tbltranslations where key='account.naam' and taalID=" & TaalID
            lblnaam.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.voornaam' and taalID=" & TaalID
            lblVoornaam.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.email' and taalID=" & TaalID
            lblemail.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.gemeente' and taalID=" & TaalID
            lblgemeente.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.adres' and taalID=" & TaalID
            lbladres.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.postcode' and taalID=" & TaalID
            lblpostcode.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.telefoon' and taalID=" & TaalID
            lbltelefoon.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.lblNewAccount' and taalID=" & TaalID
            lblNewAccount.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.newpass' and taalID=" & TaalID
            lblWachtwoord.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.NewPassAgain' and taalID=" & TaalID
            lblWachtwoordAgain.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='login.btnRegistreren' and taalID=" & TaalID
            btnMaakAccount.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.ValidateEmpty' and taalID=" & TaalID
            ValidateEmpty = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.ValidateWrongPass' and taalID=" & TaalID
            ValidateSame = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.lblUsername' and taalID=" & TaalID
            lblUsername.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.ValidateSameName' and taalID=" & TaalID
            ValidateSameName = cmd.ExecuteScalar
        Else
            cmd.CommandText = "Select value from tbltranslations where key='account.naam' and taalID=2"
            lblnaam.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.voornaam' and taalID=2"
            lblVoornaam.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.email' and taalID=2"
            lblemail.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.gemeente' and taalID=2"
            lblgemeente.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.adres' and taalID=2"
            lbladres.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.postcode' and taalID=2"
            lblpostcode.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.telefoon' and taalID=2"
            lbltelefoon.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.lblNewAccount' and taalID=2"
            lblNewAccount.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.newpass' and taalID=2"
            lblWachtwoord.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.NewPassAgain' and taalID=2"
            lblWachtwoordAgain.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='login.btnRegistreren' and taalID=2"
            btnMaakAccount.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.ValidateEmpty' and taalID=2"
            ValidateEmpty = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.ValidateWrongPass' and taalID=2"
            ValidateSame = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.lblUsername' and taalID=2"
            lblUsername.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='account.ValidateSameName' and taalID=2"
            ValidateSameName = cmd.ExecuteScalar
        End If
    End Sub
    Protected Sub btnMaakAccount_Click(sender As Object, e As EventArgs) Handles btnMaakAccount.Click
        Dim bln1, bln2, bln3 As Boolean

    
        If txtUsername.Text = String.Empty Or txtadres.Text = String.Empty Or txtemail.Text = String.Empty Or txtgemeente.Text = String.Empty Or txtNaam.Text = String.Empty Or txtpostcode.Text = String.Empty Or _
            txttelefoon.Text = String.Empty Or txtvoornaam.Text = String.Empty Or txtWachtwoord.Text = String.Empty Or txtWachtwoordAgain.Text = String.Empty Then

            lblError.Text = ValidateEmpty & " | "
            lblError.Visible = True
        Else
            lblError.Text = String.Empty
            bln1 = True
        End If

        If txtWachtwoord.Text <> txtWachtwoordAgain.Text Then

            lblError.Text &= vbCrLf & ValidateSame & " | "
            lblError.Visible = True
        Else
            bln2 = True
        End If

        Dim AantalGebruikSameName As Integer
        cmd.CommandText = "Select count(*) from tblUsers where gebruikersnaam='" & txtUsername.Text & "'"
        AantalGebruikSameName = cmd.ExecuteScalar

        If AantalGebruikSameName > 0 Then
            lblError.Text &= vbCrLf & ValidateSameName & " | "
            lblError.Visible = True
        Else
            bln3 = True
        End If

        If bln1 = True And bln2 = True And bln3 = True Then
            Dim hash As String

            hash = FormsAuthentication.HashPasswordForStoringInConfigFile(txtWachtwoord.Text, "md5").ToLower



            cmd.CommandText = "Insert into tblUsers (naam, voornaam, email, gemeente, adres, postcode, telefoon, Gebruikersnaam, wachtwoord, niveau) values" & _
                " ('" & txtNaam.Text & "','" & txtvoornaam.Text & "','" & txtemail.Text & "','" & txtgemeente.Text & "','" & txtadres.Text & "','" & txtpostcode.Text & "','" & txttelefoon.Text & "','" & txtUsername.Text & "','" & hash & "','1')"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "Select id from tblUsers where naam='" & txtNaam.Text & "' and wachtwoord='" & hash & "'"
            Session("GebruikerID") = cmd.ExecuteScalar
            Server.Transfer("AccountInfo.aspx")
        End If



    End Sub
End Class
