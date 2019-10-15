Imports System.Web.Security
Imports System.Data.OleDb
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.IO
Partial Class BesteldPagina
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


            cmd.CommandText = "Select value from tblTranslations where key='Order.lblOrderTItle' and TaalID=" & TaalID
            lblOrderTitel.Text = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.lblOrderInfoTitle' and TaalID=" & TaalID
            lblOrderInfoTitel.Text = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.lblOrderInfo' and TaalID=" & TaalID
            lblOrderInfo.Text = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.btnDownloaden' and TaalID=" & TaalID
            btnDownloaden.Text = cmd.ExecuteScalar()

        Else

            cmd.CommandText = "Select value from tblTranslations where key='Order.lblOrderTItle' and TaalID=2"
            lblOrderTitel.Text = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.lblOrderInfoTitle' and TaalID=2"
            lblOrderInfoTitel.Text = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.lblOrderInfo' and TaalID=2"
            lblOrderInfo.Text = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.btnDownloaden' and TaalID=2"
            btnDownloaden.Text = cmd.ExecuteScalar()
        

        End If
        cnn.Close
    End Sub

    Protected Sub btnDownloaden_Click(sender As Object, e As EventArgs) Handles btnDownloaden.Click
        'Session("GebruikerID") = "1"
        'Session("OrderID") = "1"
        cnn.ConnectionString = constr
        cmd.Connection = cnn

        cnn.Open()


        Dim pdfname, docname, ordernr As String
        ordernr = "U" & Session("GebruikerID") & "O" & Session("OrderID")
        docname = "Order " & ordernr & ".pdf"
        pdfname = Server.MapPath("PDFs\" & docname)

        Dim PdfTitle, pdfAanspreking, pdfDetails, pdfDate, pdfOrdernr, pdfEmail, pdfTelephone, pdfFooter, PdfInfo, pdfThanks As String
        Dim DetailsNaam, DetailsHoeveelheid, DetailsPrijs, DetailsTotalPrijs, DetailsTotaleHoeveeldheid As String
        pdfDetails = "Details"
        pdfEmail = "E-mail"

        If Not Session("Taal") = String.Empty Then
            Dim TaalID As Integer
            cmd.CommandText = "Select id from tbltaal where taal='" & Session("Taal") & "'"
            TaalID = cmd.ExecuteScalar


            cmd.CommandText = "Select value from tblTranslations where key='Order.btndownloaden' and TaalID=" & TaalID
            PdfTitle = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.nr' and TaalID=" & TaalID
            pdfOrdernr = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.lbldate' and TaalID=" & TaalID
            pdfDate = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='account.telefoon' and TaalID=" & TaalID
            pdfTelephone = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.footer' and TaalID=" & TaalID
            pdfFooter = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.lblAanspreking' and TaalID=" & TaalID
            pdfAanspreking = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.info' and TaalID=" & TaalID
            PdfInfo = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.Footer2' and TaalID=" & TaalID
            pdfThanks = cmd.ExecuteScalar


            cmd.CommandText = "Select value from tblTranslations where key='cart.lblnaam' and TaalID=" & TaalID
            DetailsNaam = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='cart.lblhoeveelheid' and TaalID=" & TaalID
            DetailsHoeveelheid = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='cart.lblPrijs' and TaalID=" & TaalID
            DetailsPrijs = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='order.DetailsTotHoeveelheid' and TaalID=" & TaalID
            DetailsTotaleHoeveeldheid = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='order.DetailsTotPrijs' and TaalID=" & TaalID
            DetailsTotalPrijs = cmd.ExecuteScalar()


        Else

            cmd.CommandText = "Select value from tblTranslations where key='Order.btndownloaden' and TaalID=2"
            PdfTitle = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.lblAanspreking' and TaalID=2"
            pdfAanspreking = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.nr' and TaalID=2"
            pdfOrdernr = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.lbldate' and TaalID=2"
            pdfDate = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='account.telefoon' and TaalID=2"
            pdfTelephone = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.footer' and TaalID=2"
            pdfFooter = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='order.info' and TaalID=2"
            PdfInfo = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='Order.Footer2' and TaalID=2"
            pdfThanks = cmd.ExecuteScalar


            cmd.CommandText = "Select value from tblTranslations where key='cart.lblnaam' and TaalID=2"
            DetailsNaam = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='cart.lblhoeveelheid' and TaalID=2"
            DetailsHoeveelheid = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='cart.lblPrijs' and TaalID=2"
            DetailsPrijs = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='order.DetailsTotHoeveelheid' and TaalID=2"
            DetailsTotaleHoeveeldheid = cmd.ExecuteScalar()
            cmd.CommandText = "Select value from tblTranslations where key='order.DetailsTotPrijs' and TaalID=2"
            DetailsTotalPrijs = cmd.ExecuteScalar()


           

        End If


        cmd.CommandText = "Select voornaam from tblUsers where Id=" & Session("GebruikerId")
        pdfAanspreking &= " " & cmd.ExecuteScalar
        cmd.CommandText = "Select naam from tblUsers where Id=" & Session("GebruikerId")
        pdfAanspreking &= " " & cmd.ExecuteScalar
        cmd.CommandText = "Select telefoon from tblUsers where id=" & Session("GebruikerID")
        pdfTelephone &= ": " & cmd.ExecuteScalar
        cmd.CommandText = "Select email from tblUsers where Id=" & Session("GebruikerID")
        pdfEmail &= ": " & cmd.ExecuteScalar

        cmd.CommandText = "Select orderdate from tblOrders where userID= " & Session("GebruikerID") & " and OrderId=" & Session("OrderID")
        pdfDate &= ": " & FormatDateTime(cmd.ExecuteScalar, DateFormat.ShortDate)

        pdfOrdernr &= ": " & ordernr



        Dim doc As New Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)
        Dim writer As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(pdfname, FileMode.Create))
        doc.Open()
        doc.NewPage()

        Dim fntTableFontHdr As iTextSharp.text.Font = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)
        Dim fntTableFont As iTextSharp.text.Font = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)
        Dim fntHeader As iTextSharp.text.Font = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)
        Dim fntHeader2 As iTextSharp.text.Font = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD)
        Dim fntHeader3 As iTextSharp.text.Font = FontFactory.GetFont("Arial", 30, iTextSharp.text.Font.BOLD)
        Dim fntTekst As iTextSharp.text.Font = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)

        Dim ParaLogo As New Paragraph("Gaming Gear", fntHeader3)
        Dim para0 As New Paragraph(" ")
        Dim para1 As New Paragraph(PdfTitle, fntHeader2)
        Dim para2 As New Paragraph(pdfAanspreking, fntTekst)
        Dim para3 As New Paragraph(pdfDetails, fntHeader)
        Dim para4 As New Paragraph(pdfDate, fntTekst)
        Dim para5 As New Paragraph(pdfEmail, fntTekst)
        Dim para6 As New Paragraph(pdfOrdernr, fntTekst)
        Dim para7 As New Paragraph(pdfTelephone, fntTekst)
        Dim para8 As New Paragraph("Items", fntHeader)
        Dim para9 As New Paragraph(PdfInfo, fntTekst)
        Dim para10 As New Paragraph(pdfFooter, fntTekst)
        Dim para11 As New Paragraph(pdfThanks, fntTekst)


        doc.Add(ParaLogo)
        doc.Add(para0)
        doc.Add(para1)
        doc.Add(para0)
        doc.Add(para2)
        doc.Add(para0)
        doc.Add(para9)
        doc.Add(para0)
        doc.Add(para3)
        doc.Add(para0)
        doc.Add(para4)
        doc.Add(para5)
        doc.Add(para6)
        doc.Add(para7)
        doc.Add(para0)





        Dim myTable As New PdfPTable(4)
        myTable.WidthPercentage = 100 ' Table size is set to 100% of the page
        myTable.HorizontalAlignment = 0 'Left aLign
        myTable.SpacingAfter = 10
        Dim sglTblHdWidths(2) As Single
        sglTblHdWidths(0) = 15
        sglTblHdWidths(1) = 200
        sglTblHdWidths(2) = 385

        Dim CellOneHdr As New PdfPCell(New Phrase("ID", fntTableFontHdr))
        myTable.AddCell(CellOneHdr)
        Dim CellTwohdr As New PdfPCell(New Phrase(DetailsNaam, fntTableFontHdr))
        myTable.AddCell(CellTwohdr)
        Dim CellThreeHdr As New PdfPCell(New Phrase(DetailsHoeveelheid, fntTableFontHdr))
        myTable.AddCell(CellThreeHdr)
        Dim CellFourHdr As New PdfPCell(New Phrase(DetailsPrijs, fntTableFontHdr))
        myTable.AddCell(CellFourHdr)

        Dim OrderPostcode, OrderPrice, OrderAmount, singleAmount, Singleprijs As Integer

        Dim OrderEmail, OrderAdres As String
        Dim strProdNaam As String


        cmd.CommandText = "Select OrderID, OrderAmount, OrderEmail, OrderPostcode, OrderPrice, OrderAdress from tblOrders where UserID=" & Session("GebruikerID") & " and OrderID=" & Session("OrderID")
        Reader = cmd.ExecuteReader

        Do While Reader.Read
            OrderEmail = Reader.Item(2)
            OrderPostcode = Reader.Item(3)
            OrderPrice = Reader.Item(4)
            OrderAmount = Reader.Item(1)
            OrderAdres = Reader.Item(5)
        Loop
        Reader.Close()

        cmd.CommandText = "Select productID from tblBesteldeartikelen where orderID=" & Session("OrderID") & " and gebruikerID=" & Session("gebruikerID")
        Reader = cmd.ExecuteReader
        Dim arrProductID(0) As Integer
        Dim teller As Integer = 0

        Do While Reader.Read

            arrProductID(teller) = Reader.Item(0)

            ReDim Preserve arrProductID(arrProductID.Length)

            teller += 1
        Loop
        Reader.Close()

        For i As Integer = 0 To UBound(arrProductID) - 1
            cmd.CommandText = "Select Prijs from tblProducten where id=" & arrProductID(i)
            Singleprijs = cmd.ExecuteScalar

            cmd.CommandText = "Select naam from tblProducten where id=" & arrProductID(i)
            strProdNaam = cmd.ExecuteScalar

            cmd.CommandText = "Select amount from tblBesteldeArtikelen where productID=" & arrProductID(i) & " and orderID=" & Session("OrderID") & " and gebruikerID=" & Session("gebruikerID")
            singleAmount = cmd.ExecuteScalar

            Dim CellOne As New PdfPCell(New Phrase(arrProductID(i), fntTableFont))
            myTable.AddCell(CellOne)
            Dim CellTwo As New PdfPCell(New Phrase(strProdNaam, fntTableFont))
            myTable.AddCell(CellTwo)
            Dim CellTree As New PdfPCell(New Phrase(singleAmount, fntTableFont))
            myTable.AddCell(CellTree)
            Dim CellFour As New PdfPCell(New Phrase(FormatCurrency(Singleprijs, 2), fntTableFont))
            myTable.AddCell(CellFour)

        Next



        Dim CellOneR2 As New PdfPCell(New Phrase("", fntTableFont))
        myTable.AddCell(CellOneR2)
        Dim CellTwoR2 As New PdfPCell(New Phrase("", fntTableFont))
        myTable.AddCell(CellTwoR2)
        Dim CellTreeR2 As New PdfPCell(New Phrase(DetailsTotaleHoeveeldheid, fntTableFontHdr))
        myTable.AddCell(CellTreeR2)
        Dim CellFourR2 As New PdfPCell(New Phrase(DetailsTotalPrijs, fntTableFontHdr))
        myTable.AddCell(CellFourR2)


        Dim CellOneR21 As New PdfPCell(New Phrase("", fntTableFont))
        myTable.AddCell(CellOneR21)
        Dim CellTwoR21 As New PdfPCell(New Phrase("", fntTableFont))
        myTable.AddCell(CellTwoR21)
        Dim CellTreeR21 As New PdfPCell(New Phrase(OrderAmount, fntTableFont))
        myTable.AddCell(CellTreeR21)
        Dim CellFourR21 As New PdfPCell(New Phrase(FormatCurrency(OrderPrice, 2), fntTableFont))
        myTable.AddCell(CellFourR21)

        doc.Add(myTable)

        doc.Add(para0)
        doc.Add(para10)
        doc.Add(para0)
        doc.Add(para11)


        doc.Close()

        Response.ContentType = "pdf"
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & docname)
        Response.TransmitFile(pdfname)
        Response.End()

    End Sub
End Class
