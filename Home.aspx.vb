Imports System.Web.Security
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Imports System.Data.OleDb
Partial Class Home
    Inherits System.Web.UI.Page

    Dim cmd As New OleDbCommand
    Dim cnn As New OleDbConnection
    Dim constr As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source= C:\Users\ozcan\Desktop\USB Stick\SFC Documenten backup\Website GIP\V3\Database\dbGip1.mdb"


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        cnn.ConnectionString = constr
        cmd.Connection = cnn
        cnn.Open()

        If Not Session("Taal") = String.Empty Then
                
            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar

            cmd.CommandText = "Select value from tbltranslations where key='home.lbltitle' and TaalID=" & TaalID
            lblHomeTitle.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='home.lblinfo' and TaalID=" & TaalID
            lblInfo.Text = cmd.ExecuteScalar


        Else


            cmd.CommandText = "Select value from tbltranslations where key='home.lbltitle' and TaalID=2"
            lblHomeTitle.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='home.lblinfo' and TaalID=2"
            lblInfo.Text = cmd.ExecuteScalar

        End If

        cnn.Close()

    End Sub
End Class
