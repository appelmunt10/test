Imports System.Data.OleDb
Imports System.Web.Security
Partial Class Producten
    Inherits System.Web.UI.Page

    Dim cmd As New OleDbCommand
    Dim cnn As New OleDbConnection
    Dim Reader As OleDbDataReader
    Dim ProdNaam, ProdImage As String
    Dim constr As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source= C:\Users\ozcan\Desktop\USB Stick\SFC Documenten backup\Website GIP\V3\Database\dbGip1.mdb"
    Dim ProdPrijs As Double
    Dim AantalProd, ProductID As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblError.Visible = False
        cnn.ConnectionString = constr
        cmd.Connection = cnn
        cnn.Open()
        If Not Session("Taal") = String.Empty Then


            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar

            cmd.CommandText = "Select value from tbltranslations where key='sorteren.title' and taalID=" & TaalID
            ckbSorteren.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='sorteren.prijs' and taalID=" & TaalID
            lblSortPrijs.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='sorteren.fabrikant' and taalID=" & TaalID
            lblFabrikant.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='sorteren.categorie' and taalID=" & TaalID
            lblCategorie.Text = cmd.ExecuteScalar
        Else
            cmd.CommandText = "Select value from tbltranslations where key='sorteren.title' and taalID=2"
            ckbSorteren.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='sorteren.prijs' and taalID=2"
            lblSortPrijs.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='sorteren.fabrikant' and taalID=2"
            lblFabrikant.Text = cmd.ExecuteScalar
            cmd.CommandText = "Select value from tbltranslations where key='sorteren.categorie' and taalID=2"
            lblCategorie.Text = cmd.ExecuteScalar
        End If





        cmd.CommandText = "Select count(*) from tblProducten"
        AantalProd = cmd.ExecuteScalar


        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten"
        Reader = cmd.ExecuteReader



        While Reader.Read
            ProdNaam = Reader.Item(0)
            ProdPrijs = Reader.Item(1)
            ProdImage = Reader.Item(2)
            ProductID = Reader.Item(3)

            PanelsMaken()

        End While
        Reader.Close()

        cnn.Close()




    End Sub

  
    Private Sub SortPrijsDesc()
        MainPanel.Controls.Clear()

        Dim GroepID, MerkID As Integer





        cnn.ConnectionString = ConStr
        cmd.Connection = cnn

        '// Producten tonen
        cnn.Open()

        If Not ddlCategorie.SelectedValue = ("--") And Not ddlFabrikant.SelectedValue = ("--") Then

            cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
            GroepID = cmd.ExecuteScalar

            cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
            MerkID = cmd.ExecuteScalar

            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where groepID=" & GroepID & " and merkID=" & MerkID & " order by prijs desc"
            Reader = cmd.ExecuteReader

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        End If

        If Not ddlCategorie.SelectedValue = ("--") And ddlFabrikant.SelectedValue = ("--") Then
            MainPanel.Controls.Clear()

            cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
            GroepID = cmd.ExecuteScalar

            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where groepID=" & GroepID & " order by prijs desc"
            Reader = cmd.ExecuteReader

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        ElseIf Not ddlFabrikant.SelectedValue = ("--") And ddlCategorie.SelectedValue = ("--") Then
            MainPanel.Controls.Clear()
            cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
            MerkID = cmd.ExecuteScalar

            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & MerkID & " order by prijs desc"
            Reader = cmd.ExecuteReader

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        End If

        If ddlFabrikant.SelectedValue = ("--") And ddlCategorie.SelectedValue = ("--") Then

            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten order by prijs desc"
            Reader = cmd.ExecuteReader



            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        End If


        Reader.Close()
        cnn.Close()
    End Sub

    Private Sub SortPrijsAsc()
        MainPanel.Controls.Clear()

        Dim GroepID, MerkID As Integer

       

        cnn.ConnectionString = ConStr
        cmd.Connection = cnn

        '// Producten tonen
        cnn.Open()


        If Not ddlCategorie.SelectedValue = ("--") And Not ddlFabrikant.SelectedValue = ("--") Then

            cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
            GroepID = cmd.ExecuteScalar

            cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
            MerkID = cmd.ExecuteScalar

            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where groepID=" & GroepID & " and merkID=" & MerkID & " order by prijs asc  "
            Reader = cmd.ExecuteReader

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        End If

        If Not ddlCategorie.SelectedValue = ("--") And ddlFabrikant.SelectedValue = ("--") Then
            MainPanel.Controls.Clear()

            cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
            GroepID = cmd.ExecuteScalar

            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where groepID=" & GroepID & " order by prijs asc"
            Reader = cmd.ExecuteReader

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        ElseIf Not ddlFabrikant.SelectedValue = ("--") And ddlCategorie.SelectedValue = ("--") Then
            MainPanel.Controls.Clear()
            cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
            MerkID = cmd.ExecuteScalar

            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & MerkID & " order by prijs asc"
            Reader = cmd.ExecuteReader

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        End If

        If ddlFabrikant.SelectedValue = ("--") And ddlCategorie.SelectedValue = ("--") Then
            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten order by prijs asc"
            Reader = cmd.ExecuteReader



            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While
        End If
        Reader.Close()
        cnn.Close()

    End Sub

    Private Sub PanelsMaken()
        Dim NewPanel As New Panel
        Dim lblName As New Label
        Dim lblPrice As New Label
        Dim ImageButton As New ImageButton
        Dim Empty As New Label
        Empty.Text = "<br />"



        ImageButton.ImageUrl = "~/Images/" & ProdImage
        ImageButton.CssClass = "ProductImage"
        ImageButton.PostBackUrl = "~/Product.aspx?id=" & ProductID

        lblName.Text = ProdNaam
        lblName.CssClass = "ProductName"

        lblPrice.Text = " " & FormatCurrency(ProdPrijs, 2)
        lblPrice.CssClass = "ProductPrice"



        NewPanel.Controls.Add(lblName)
        NewPanel.Controls.Add(Empty)
        NewPanel.Controls.Add(lblPrice)
        NewPanel.Controls.Add(Empty)
        NewPanel.Controls.Add(ImageButton)


        NewPanel.CssClass = "Panel"
        MainPanel.Controls.Add(NewPanel)
    End Sub

    Protected Sub ddlPrijs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPrijs.SelectedIndexChanged
        If ddlPrijs.SelectedIndex = 2 Then
            SortPrijsDesc()
        End If
        If ddlPrijs.SelectedIndex = 1 Then
            SortPrijsAsc()
        End If


        If ddlPrijs.SelectedValue = ("--") Then
            Dim merkID, GroepID As Integer



            cnn.ConnectionString = ConStr
            cmd.Connection = cnn
            cnn.Open()

            If Not ddlFabrikant.SelectedValue = ("--") And Not ddlCategorie.SelectedValue = ("--") Then
                MainPanel.Controls.Clear()
                cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                GroepID = cmd.ExecuteScalar

                cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                merkID = cmd.ExecuteScalar

                cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " and groepID=" & GroepID
                Reader = cmd.ExecuteReader


                While Reader.Read
                    ProdNaam = Reader.Item(0)
                    ProdPrijs = Reader.Item(1)
                    ProdImage = Reader.Item(2)
                    ProductID = Reader.Item(3)

                    PanelsMaken()

                End While
            End If

            If Not ddlFabrikant.SelectedValue = ("--") And ddlCategorie.SelectedValue = ("--") Then
                MainPanel.Controls.Clear()
                cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                merkID = cmd.ExecuteScalar

                cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID
                Reader = cmd.ExecuteReader

                While Reader.Read
                    ProdNaam = Reader.Item(0)
                    ProdPrijs = Reader.Item(1)
                    ProdImage = Reader.Item(2)
                    ProductID = Reader.Item(3)

                    PanelsMaken()

                End While

            End If

            If ddlFabrikant.SelectedValue = ("--") And Not ddlCategorie.SelectedValue = ("--") Then
                MainPanel.Controls.Clear()
                cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                GroepID = cmd.ExecuteScalar

                cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where groepID=" & GroepID
                Reader = cmd.ExecuteReader

                While Reader.Read
                    ProdNaam = Reader.Item(0)
                    ProdPrijs = Reader.Item(1)
                    ProdImage = Reader.Item(2)
                    ProductID = Reader.Item(3)

                    PanelsMaken()

                End While
            End If
            Reader.Close()
            cnn.Close()

        End If

        If MainPanel.Controls.Count = 0 Then
            lblError.Visible = True
            lblError.Text = "Geen items gevonden"
        End If
    End Sub

    Protected Sub ckbSorteren_CheckedChanged(sender As Object, e As EventArgs) Handles ckbSorteren.CheckedChanged
        If ckbSorteren.Checked = True Then
            lblCategorie.Visible = True
            lblFabrikant.Visible = True
            lblSortPrijs.Visible = True
            ddlPrijs.Visible = True
            ddlCategorie.Visible = True
            ddlFabrikant.Visible = True

            ddlPrijs.Items.Clear()
            ddlFabrikant.Items.Clear()
            ddlCategorie.Items.Clear()

        
            


            cnn.ConnectionString = constr
            cmd.Connection = cnn
            cnn.Open()

            If Not Session("Taal") = String.Empty Then

                Dim Opl, Afl As String
                Dim TaalID As Integer

                cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
                TaalID = cmd.ExecuteScalar

                cmd.CommandText = "Select value from tbltranslations where key='sorteren.oplopend' and taalid=" & TaalID
                Opl = cmd.ExecuteScalar
                cmd.CommandText = "Select value from tbltranslations where key='sorteren.aflopend' and taalid=" & TaalID
                afl = cmd.ExecuteScalar

                ddlPrijs.Items.Add("--")
                ddlPrijs.Items.Add(Opl)
                ddlPrijs.Items.Add(afl)

            End If

            cmd.CommandText = "Select merknaam from tblmerken"
            Reader = cmd.ExecuteReader
            ddlFabrikant.Items.Add("--")
            While Reader.Read
                ddlFabrikant.Items.Add(Reader.Item(0))
            End While
            Reader.Close()

            cmd.CommandText = "Select groepnaam from tblGroepcode"
            Reader = cmd.ExecuteReader
            ddlCategorie.Items.Add("--")
            While Reader.Read
                ddlCategorie.Items.Add(Reader.Item(0))
            End While
            Reader.Close()
        End If

        If ckbSorteren.Checked = False Then
            ddlPrijs.Visible = False
            ddlCategorie.Visible = False
            ddlFabrikant.Visible = False
            lblCategorie.Visible = False
            lblFabrikant.Visible = False
            lblSortPrijs.Visible = False
        End If

    End Sub

    Protected Sub ddlFabrikant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFabrikant.SelectedIndexChanged


        Dim merkID, groepID As Integer




        cnn.ConnectionString = ConStr
        cmd.Connection = cnn

        '// Producten tonen
        cnn.Open()

        If ddlFabrikant.SelectedValue = ("--") And Not ddlCategorie.SelectedValue = ("--") Then
            MainPanel.Controls.Clear()

            cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
            groepID = cmd.ExecuteScalar


            cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where groepID=" & groepID
            Reader = cmd.ExecuteReader

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        End If


        If Not ddlFabrikant.SelectedValue = "--" Then
            MainPanel.Controls.Clear()







            If Not ddlCategorie.SelectedValue = ("--") Then

                If Not ddlPrijs.SelectedValue = ("--") Then

                    cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                    groepID = cmd.ExecuteScalar

                    cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                    merkID = cmd.ExecuteScalar

                    If ddlPrijs.SelectedIndex = 1 Then
                        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " and groepID=" & groepID & " order by prijs asc"
                        Reader = cmd.ExecuteReader
                    End If

                    If ddlPrijs.SelectedIndex = 2 Then
                        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " and groepID=" & groepID & " order by prijs desc"
                        Reader = cmd.ExecuteReader
                    End If

                Else

                    cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                    groepID = cmd.ExecuteScalar

                    cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                    merkID = cmd.ExecuteScalar

                    cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " and groepID=" & groepID
                    Reader = cmd.ExecuteReader

                End If

             

            Else
                If Not ddlPrijs.SelectedValue = ("--") Then

                    If ddlPrijs.SelectedIndex = 1 Then
                        cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                        merkID = cmd.ExecuteScalar

                        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " order by prijs asc"
                        Reader = cmd.ExecuteReader
                    End If

                    If ddlPrijs.SelectedIndex = 2 Then

                        cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                        merkID = cmd.ExecuteScalar

                        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " order by prijs desc"
                        Reader = cmd.ExecuteReader

                    End If

                Else

                    cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                    merkID = cmd.ExecuteScalar

                    cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID
                    Reader = cmd.ExecuteReader

                End If


            End If






            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While


        End If



        If ddlFabrikant.SelectedValue = ("--") And ddlCategorie.SelectedValue = ("--") Then
            MainPanel.Controls.Clear()

            If ddlPrijs.SelectedIndex = 1 Then
                cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten order by prijs asc"
                Reader = cmd.ExecuteReader
            End If

            If ddlPrijs.SelectedIndex = 2 Then
                cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten order by prijs desc"
                Reader = cmd.ExecuteReader
            End If

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While
        End If

        If MainPanel.Controls.Count = 0 Then
            lblError.Visible = True

            If Not Session("Taal") = String.Empty Then

                Dim TaalID As Integer

                cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
                TaalID = cmd.ExecuteScalar

                cmd.CommandText = "Select value from tbltranslations where key='Producten.NoItem' and TaalID=" & TaalID

                lblError.Text = cmd.ExecuteScalar
            Else

                cmd.CommandText = "Select value from tblTranslations where key='producten.noItem' and TaalID=2"
                lblError.Text = cmd.ExecuteScalar

            End If


        End If

        Reader.Close()
        cnn.Close()
    End Sub

    Protected Sub ddlCategorie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCategorie.SelectedIndexChanged

        Dim groepID, merkID As Integer




        cnn.ConnectionString = ConStr
        cmd.Connection = cnn

        '// Producten tonen
        cnn.Open()

        If ddlCategorie.SelectedValue = ("--") And Not ddlFabrikant.SelectedValue = ("--") Then
            MainPanel.Controls.Clear()

            cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
            merkID = cmd.ExecuteScalar

            cmd.CommandText = "select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID
            Reader = cmd.ExecuteReader

            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While

        End If

        If Not ddlCategorie.SelectedValue = "--" Then
            MainPanel.Controls.Clear()





            If Not ddlFabrikant.SelectedValue = ("--") Then


                If Not ddlPrijs.SelectedValue = ("--") Then

                    cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                    groepID = cmd.ExecuteScalar

                    cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                    merkID = cmd.ExecuteScalar

                    If ddlPrijs.SelectedIndex = 1 Then
                        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " and groepID=" & groepID & " order by prijs asc"
                        Reader = cmd.ExecuteReader
                    End If

                    If ddlPrijs.SelectedIndex = 2 Then
                        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " and groepID=" & groepID & " order by prijs desc"
                        Reader = cmd.ExecuteReader
                    End If

                Else

                    cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                    groepID = cmd.ExecuteScalar

                    cmd.CommandText = "Select id from tblmerken where merknaam='" & ddlFabrikant.SelectedValue & "'"
                    merkID = cmd.ExecuteScalar

                    cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where merkID=" & merkID & " and groepID=" & groepID
                    Reader = cmd.ExecuteReader

                End If

            Else

                If Not ddlPrijs.SelectedValue = ("--") Then
                    If ddlPrijs.SelectedIndex = 1 Then
                        cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                        groepID = cmd.ExecuteScalar

                        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where GroepID=" & groepID & " order by prijs asc"
                        Reader = cmd.ExecuteReader
                    End If

                    If ddlPrijs.SelectedIndex = 2 Then

                        cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                        groepID = cmd.ExecuteScalar

                        cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten where groepID=" & groepID & " order by prijs desc"
                        Reader = cmd.ExecuteReader

                    End If

                Else

                    cmd.CommandText = "select id from tblGroepcode where groepnaam='" & ddlCategorie.SelectedValue & "'"
                    groepID = cmd.ExecuteScalar

                    cmd.CommandText = "select naam, prijs, afbeelding, id from tblproducten where groepID=" & groepID
                    Reader = cmd.ExecuteReader

                End If

            End If



            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()
            End While





        End If

        If ddlFabrikant.SelectedValue = ("--") And ddlCategorie.SelectedValue = ("--") Then
            MainPanel.Controls.Clear()

            If ddlPrijs.SelectedIndex = 1 Then
                cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten order by prijs asc"
                Reader = cmd.ExecuteReader
            End If

            If ddlPrijs.SelectedIndex = 2 Then
                cmd.CommandText = "Select naam, prijs, afbeelding, id from tblproducten order by prijs desc"
                Reader = cmd.ExecuteReader
            End If




            While Reader.Read
                ProdNaam = Reader.Item(0)
                ProdPrijs = Reader.Item(1)
                ProdImage = Reader.Item(2)
                ProductID = Reader.Item(3)

                PanelsMaken()

            End While
        End If

        If MainPanel.Controls.Count = 0 Then
            lblError.Visible = True
            lblError.Text = "Geen items gevonden"
        End If

        Reader.Close()
        cnn.Close()


    End Sub
End Class
