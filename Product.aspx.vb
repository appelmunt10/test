Imports System.Data.OleDb
Partial Class Product
    Inherits System.Web.UI.Page
    Dim cmd As New OleDbCommand
    Dim cnn As New OleDbConnection
    Dim constr As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source= C:\Users\ozcan\Desktop\USB Stick\SFC Documenten backup\Website GIP\V3\Database\dbGip1.mdb"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("ProductID2") = 0
        Dim ProductID, ProdImage, ProdDescription, ProdName As String
        Dim ProdPrice As Double
        Dim intCount As Integer = 0


        ProductID = Request.QueryString("id")


        cnn.ConnectionString = constr
        cmd.Connection = cnn

        cnn.Open()

        If Session("GebruikerID") <> 0 Then
            cmd.CommandText = "Select count(*) from tblCart where productID=" & ProductID & " and gebruikerID=" & Session("GebruikerID")
            intCount = cmd.ExecuteScalar

            If intCount <> 0 Then

                btnAdd.Visible = False
                btnAanpassen.Visible = True
                btnVerwijderen.Visible = True
            Else

                btnAdd.Visible = True
                btnAanpassen.Visible = False
                btnVerwijderen.Visible = False
            End If
        End If

        If Not Session("Taal") = String.Empty Then
            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar

            cmd.CommandText = "Select value from tblproductTranslations where key='Product.Description' and TaalID=" & TaalID & " and ProductID=" & ProductID
            ProdDescription = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Product.hoeveelheid' and TaalID=" & TaalID
            lblHoeveelheid.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Product.voegtoe' and TaalID=" & TaalID
            btnAdd.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Product.btnaanpassen' and TaalID=" & TaalID
            btnAanpassen.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Product.btnVerwijderen' and TaalID=" & TaalID
            btnVerwijderen.Text = cmd.ExecuteScalar
        Else
            cmd.CommandText = "Select value from tblproductTranslations where key='Product.Description' and TaalID=2 and ProductID=" & ProductID
            ProdDescription = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Product.hoeveelheid' and TaalID=2"
            lblHoeveelheid.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Product.voegtoe' and TaalID=2"
            btnAdd.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Product.btnaanpassen' and TaalID=2"
            btnAanpassen.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='Product.btnVerwijderen' and TaalID=2"
            btnVerwijderen.Text = cmd.ExecuteScalar

        End If



        cmd.CommandText = "Select prijs from tblProducten where id=" & ProductID
        ProdPrice = cmd.ExecuteScalar
        cmd.CommandText = "Select afbeelding from tblProducten where id=" & ProductID
        ProdImage = cmd.ExecuteScalar
        cmd.CommandText = "Select naam from tblProducten where id=" & ProductID
        ProdName = cmd.ExecuteScalar

        cnn.Close()

        lblDescription.Text = ProdDescription
        lblItemNr.Text = ProductID
        lblPrice.Text = FormatCurrency(ProdPrice, 2)
        lblTitle.Text = ProdName
        imgProduct.ImageUrl = "~/Images/" & ProdImage

        For i As Integer = 0 To 19
            ddlAmount.Items.Add(i + 1)
        Next


    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If Session("GebruikerID") = 0 Then
            Session("AddCartLoggedFalse") = 1
            Server.Transfer("AccountLogin.aspx")
        End If
        Dim productID, GebruikerID, Amount As Integer
        cnn.ConnectionString = constr
        cmd.Connection = cnn

        cnn.Open()

        productID = Request.QueryString(0)
        GebruikerID = Session("GebruikerID")
        Amount = ddlAmount.SelectedValue


        cmd.CommandText = "INSERT INTO tblCart (GebruikerID, ProductID, Amount) VALUES ('" & GebruikerID & "','" & productID & "','" & Amount & "')"
        cmd.ExecuteNonQuery()


        If Not Session("Taal") = String.Empty Then
            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar

            cmd.CommandText = "Select value from tblTranslations where key='Product.lblresult' and TaalID=" & TaalID
            lblResult.Text = cmd.ExecuteScalar

        Else
            cmd.CommandText = "Select value from tblTranslations where key='Product.lblresult' and TaalID=2"
            lblResult.Text = cmd.ExecuteScalar
        End If

        btnAdd.Visible = False
        btnVerwijderen.Visible = True
        btnAanpassen.Visible = True
        lblResult.Visible = True

    End Sub

    Protected Sub btnAanpassen_Click(sender As Object, e As EventArgs) Handles btnAanpassen.Click
        cnn.ConnectionString = constr
        cmd.Connection = cnn

        cnn.Open()

        Dim ProductID As Integer

        ProductID = Request.QueryString(0)

        cmd.CommandText = "Update tblcart Set amount=" & ddlAmount.SelectedValue & " where GebruikerID=" & Session("GebruikerID") & " and productID=" & ProductID
        cmd.ExecuteNonQuery()

        Session("Amount") = ddlAmount.SelectedValue
        Session("ProductID") = ProductID

        Response.Redirect("Cart.aspx")
    End Sub

    Protected Sub btnVerwijderen_Click(sender As Object, e As EventArgs) Handles btnVerwijderen.Click
        cnn.ConnectionString = constr
        cmd.Connection = cnn

        cnn.Open()

        Dim ProductID As Integer

        ProductID = Request.QueryString(0)

        cmd.CommandText = "Delete from tblcart where GebruikerID=" & Session("GebruikerID") & " and productID=" & ProductID
        cmd.ExecuteNonQuery()

        Session("ProductID2") = ProductID

        Server.Transfer("Cart.aspx?ID=" & ProductID)
    End Sub
End Class
