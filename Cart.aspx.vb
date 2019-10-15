Imports System.Data.OleDb
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Partial Class Cart
    Inherits System.Web.UI.Page
    Dim cmd As New OleDbCommand
    Dim cnn As New OleDbConnection
    Dim Reader As OleDbDataReader
    Dim constr As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source= C:\Users\ozcan\Desktop\USB Stick\SFC Documenten backup\Website GIP\V3\Database\dbGip1.mdb"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        cnn.ConnectionString = constr
        cmd.Connection = cnn

        cnn.Open()
        lblInfo.Visible = False
        If Session("GebruikerID") = 0 Then
            lblOpmerking.Visible = False
            lblTotaalPrijs.Visible = False
            btnBestellen.Visible = False
            lbltxtTotaal.Visible = False
            lblTotaleHoeveelheid.Visible = False
            lblError.Visible = True
            If Not Session("Taal") = String.Empty Then
                Dim TaalID As Integer
                cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
                TaalID = cmd.ExecuteScalar

                cmd.CommandText = "Select value from tblTranslations where key='cart.loginReq' and TaalID=" & TaalID
                lblError.Text = cmd.ExecuteScalar
            Else
                cmd.CommandText = "Select value from tblTranslations where key='cart.loginReq' and TaalID=2"
                lblError.Text = cmd.ExecuteScalar
            End If



        Else



            ControlPanel.Controls.Clear()

            Dim UserID As Integer = Session("GebruikerID")
            Dim strNaamProduct, strImageProduct As String
            Dim ProductPrijs, ProductAmount As Integer
            Dim intProducten(0) As Integer
            Dim teller As Integer




            cmd.CommandText = "Select Productid from tblCart where gebruikerID=" & UserID
            Reader = cmd.ExecuteReader
            teller = 0

            While Reader.Read

                intProducten(teller) = Reader.Item(0)

                ReDim Preserve intProducten(intProducten.Length)

                teller += 1
            End While
            Reader.Close()

            Dim Panel2 As New Panel
            Dim txtNaam As New Label
            Dim txtAfbeelding As New Label
            Dim txtID As New Label
            Dim txtPrijs As New Label
            Dim txtHoeveelheid As New Label
            Dim strInfo As String




            txtAfbeelding.CssClass = "CartTitleAfbeelding"

            txtNaam.CssClass = "CartTitleNaam"

            txtID.Text = "ID"
            txtID.CssClass = "CartTitleID"

            txtPrijs.CssClass = "CartTitlePrice"

            txtHoeveelheid.CssClass = "CartTitleAmount"


            If Not Session("Taal") = String.Empty Then
                Dim TaalID As Integer
                cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
                TaalID = cmd.ExecuteScalar

                cmd.CommandText = "Select value from tblTranslations where key='cart.lblNaam' and TaalID=" & TaalID
                txtNaam.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblHoeveelheid' and TaalID=" & TaalID
                txtHoeveelheid.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblprijs' and TaalID=" & TaalID
                txtPrijs.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lbltotaal' and TaalID=" & TaalID
                lbltxtTotaal.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblafbeelding' and TaalID=" & TaalID
                txtAfbeelding.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblOpmerking' and TaalID=" & TaalID
                lblOpmerking.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblTitle' and TaalID=" & TaalID
                lblTitleCart.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.btnBestel' and TaalID=" & TaalID
                btnBestellen.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblinfo' and TaalID=" & TaalID
                strInfo = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.noitems' and TaalID=" & TaalID
                lblError.Text = cmd.ExecuteScalar



            Else

                cmd.CommandText = "Select value from tblTranslations where key='cart.lblNaam' and TaalID=2"
                txtNaam.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblHoeveelheid' and TaalID=2"
                txtHoeveelheid.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblprijs' and TaalID=2"
                txtPrijs.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lbltotaal' and TaalID=2"
                lbltxtTotaal.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblafbeelding' and TaalID=2"
                txtAfbeelding.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblOpmerking' and TaalID=2"
                lblOpmerking.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblTitle' and TaalID=2"
                lblTitleCart.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.btnBestel' and TaalID=2"
                btnBestellen.Text = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.lblinfo' and TaalID=2"
                strInfo = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tblTranslations where key='cart.noitems' and TaalID=2"
                lblError.Text = cmd.ExecuteScalar


            End If





            Panel2.Controls.Add(txtID)
            Panel2.Controls.Add(txtAfbeelding)
            Panel2.Controls.Add(txtNaam)
            Panel2.Controls.Add(txtPrijs)
            Panel2.Controls.Add(txtHoeveelheid)


            Panel2.CssClass = "ControlPanel2"
            ControlPanel.Controls.Add(Panel2)




            Dim TotaalPrijs As Integer = 0
            Dim TotaalHoeveelheid As Integer = 0
            For i As Integer = 0 To UBound(intProducten) - 1


                Dim lblID As New Label
                Dim NPanel As New Panel
                Dim lblName As New Label
                Dim lblPrice As New Label
                Dim ImageButton As New ImageButton
                Dim amount As New Label
                Dim Empty As New Label

                Empty.Text = "<br />"

                cmd.CommandText = "Select naam from tblProducten where id=" & intProducten(i)
                strNaamProduct = cmd.ExecuteScalar
                cmd.CommandText = "Select prijs from tblProducten where id=" & intProducten(i)
                ProductPrijs = cmd.ExecuteScalar
                cmd.CommandText = "Select afbeelding from tblProducten where id=" & intProducten(i)
                strImageProduct = cmd.ExecuteScalar

                If intProducten(i) = Session("ProductID2") Then
                    Dim strNaam As String
                    cmd.CommandText = "Select naam from tblproducten where id=" & Session("ProductID2")
                    strNaam = cmd.ExecuteScalar
                    lblInfo.Visible = True
                    lblInfo.Text = strNaam & " " & strInfo

                    Dim InfoID2 As Integer
                    cmd.CommandText = "Select count(*) from tblCart where gebruikeriD=" & Session("GebruikerID")
                    InfoID2 = cmd.ExecuteScalar

                    If InfoID2 = 0 Then
                        lblError.Visible = True
                        btnBestellen.Visible = False
                    End If

                Else

                    If intProducten(i) = Session("ProductID") Then

                        ProductAmount = Session("Amount")

                    Else

                        cmd.CommandText = "Select amount from tblCart where productId=" & intProducten(i)
                        ProductAmount = cmd.ExecuteScalar
                    End If


                    lblID.Text = intProducten(i)
                    lblID.CssClass = "CartProductID"

                    ImageButton.ImageUrl = "~/Images/" + strImageProduct
                    ImageButton.CssClass = "CartProductImage"
                    ImageButton.PostBackUrl = "~/Product.aspx?id=" & intProducten(i)

                    lblName.Text = strNaamProduct
                    lblName.CssClass = "CartProductName"

                    lblPrice.Text = FormatCurrency(ProductPrijs, 2)
                    lblPrice.CssClass = "CartProductPrice"

                    amount.Text = ProductAmount
                    amount.CssClass = "CartProductAmount"

                    NPanel.Controls.Add(lblID)
                    NPanel.Controls.Add(ImageButton)
                    NPanel.Controls.Add(lblName)

                    NPanel.Controls.Add(lblPrice)
                    NPanel.Controls.Add(amount)

                    NPanel.CssClass = "ControlPanel"
                    ControlPanel.Controls.Add(NPanel)

                    TotaalPrijs += ProductAmount * ProductPrijs
                    lblTotaalPrijs.Text = FormatCurrency(TotaalPrijs, 2)
                    TotaalHoeveelheid += ProductAmount
                    lblTotaleHoeveelheid.Text = TotaalHoeveelheid

                End If
            Next


            Dim InfoID As Integer
            cmd.CommandText = "Select count(*) from tblCart where gebruikeriD=" & Session("GebruikerID")
            InfoID = cmd.ExecuteScalar

            If InfoID = 0 Then
                lblError.Visible = True
                btnBestellen.Visible = False
            End If
        End If

        cnn.Close()

    End Sub


    

  

    Protected Sub btnBestellen_Click(sender As Object, e As EventArgs) Handles btnBestellen.Click
        Dim OrderID, OrderAmount, OrderPrice As Integer
        Dim orderEmail, OrderPostcode, OrderAdres As String

        OrderAmount = lblTotaleHoeveelheid.Text
        OrderPrice = lblTotaalPrijs.Text

        cnn.ConnectionString = constr
        cmd.Connection = cnn

        cnn.Open()


        cmd.CommandText = "select distinct OrderID from tblBesteldeArtikelen where gebruikerID=" & Session("GebruikerID")
        Reader = cmd.ExecuteReader()

        Dim HoogsteGetal As Integer
        HoogsteGetal = 0
        Do While Reader.Read

            If HoogsteGetal < Reader.Item(0) Then
                HoogsteGetal = Reader.Item(0)
            End If
        Loop
        Reader.Close()

        cmd.CommandText = "Insert into tblBesteldeArtikelen select ProductID, Amount, GebruikerID from tblcart where GebruikerID=" & Session("GebruikerID")
        cmd.ExecuteNonQuery()

        cmd.CommandText = "Delete from tblCart where gebruikerID=" & Session("GebruikerID")
        cmd.ExecuteNonQuery()

        cmd.CommandText = "Update tblBesteldeArtikelen set datum='" & Date.Now & "' where gebruikerID=" & Session("GebruikerID") & " and datum is NULL"
        cmd.ExecuteNonQuery()

        If HoogsteGetal = 0 Then
            cmd.CommandText = "Update tblBesteldeArtikelen set OrderID=1 where gebruikerID=" & Session("GebruikerID")
            cmd.ExecuteNonQuery()
            OrderID = 1
        Else
            cmd.CommandText = "Update tblBesteldeArtikelen set OrderID=" & HoogsteGetal + 1 & " where gebruikerID=" & Session("GebruikerID") & " and orderID is NUll"
            cmd.ExecuteNonQuery()
            OrderID = HoogsteGetal + 1
        End If

        cmd.CommandText = "Select email, postcode, adres from tblUsers where ID=" & Session("GebruikerID")
        Reader = cmd.ExecuteReader

        Do While Reader.Read
            orderEmail = Reader.Item(0)
            OrderPostcode = Reader.Item(1)
            OrderAdres = Reader.Item(2)
        Loop
        Reader.Close()

        cmd.CommandText = "insert into tblOrders (UserID, OrderID, OrderAdress, OrderPostcode, OrderEmail, orderAmount, OrderPrice, OrderDate) values ('" & Session("GebruikerID") & "','" & OrderID & "','" & OrderAdres & "', '" & OrderPostcode & "', '" & orderEmail & "','" & OrderAmount & "', '" & OrderPrice & "','" & Date.Now & "')"
        cmd.ExecuteNonQuery()

        Session("OrderID") = OrderID

        Server.Transfer("BesteldPagina.aspx")
    End Sub
End Class
