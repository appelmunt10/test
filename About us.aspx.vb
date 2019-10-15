Imports System.Data.OleDb
Partial Class About_us
    Inherits System.Web.UI.Page

    Dim cmd As New OleDbCommand
    Dim cnn As New OleDbConnection
    Dim Reader As OleDbDataReader
    Dim constr As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source= C:\Users\ozcan\Desktop\USB Stick\SFC Documenten backup\Website GIP\V3\Database\dbGip1.mdb"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        cnn.ConnectionString = constr
        cmd.Connection = cnn
        cnn.Open()

        If Not Session("Taal") = String.Empty Then
       

            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar

            cmd.CommandText = "Select value from tblTranslations where key='Aboutus.title' and Taalid=" & TaalID
            lblTitel.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tblTranslations where key='Aboutus.text' and Taalid=" & TaalID
            lblText.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tblTranslations where key='Aboutus.txt2' and Taalid=" & TaalID
            lbltext2.Text = cmd.ExecuteScalar


        Else

            cmd.CommandText = "Select value from tblTranslations where key='Aboutus.title' and Taalid=2"
            lblTitel.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tblTranslations where key='Aboutus.text' and Taalid=2"
            lblText.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tblTranslations where key='Aboutus.txt2' and Taalid=2"
            lbltext2.Text = cmd.ExecuteScalar


        End If

    End Sub
End Class
