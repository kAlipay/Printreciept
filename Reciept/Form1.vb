Imports System.Drawing.Printing
Public Class Form1
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub changelongpaper()
        Dim rowcount As Integer
        longpaper = 0
        rowcount = DataGridView1.Rows.Count
        longpaper = rowcount * 15
        longpaper = longpaper + 500

    End Sub

    Private Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        changelongpaper()
        PPD.Document = PD
        PPD.ShowDialog()

    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, longpaper)
        PD.DefaultPageSettings = pagesetup

    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim right As New StringFormat
        Dim center As New StringFormat

        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = " ________________________________________________________ "

        e.Graphics.DrawString("Store", f14, Brushes.Black, centermargin, 5, center)
        e.Graphics.DrawString("REDGE ESPIRITU STORE", f10, Brushes.Black, centermargin, 25, center)
        e.Graphics.DrawString("Tel + 0900000000", f10, Brushes.Black, centermargin, 40, center)

        e.Graphics.DrawString("Invoice #", f8, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 60)
        e.Graphics.DrawString("Tel + 0900000000", f8, Brushes.Black, 70, 60)

        e.Graphics.DrawString("Casher #", f8, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 75)
        e.Graphics.DrawString("Clyde Richard L. Abelanio", f8, Brushes.Black, 70, 75)

        e.Graphics.DrawString("Date" & Date.Now(), f8, Brushes.Black, 0, 90)
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 100)


        e.Graphics.DrawString("QTY", f10b, Brushes.Black, 0, 110)
        e.Graphics.DrawString("Item", f10b, Brushes.Black, 30, 110)
        e.Graphics.DrawString("Price", f10b, Brushes.Black, rightmargin, 110, right)
        Dim height As Integer
        Dim i As Long

        DataGridView1.AllowUserToAddRows = False

        For row As Integer = 0 To DataGridView1.RowCount - 1
            height += 15
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(1).Value.ToString, f10, Brushes.Black, 0, 120 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(0).Value.ToString, f10, Brushes.Black, 25, 120 + height)

            i = DataGridView1.Rows(row).Cells(2).Value
            DataGridView1.Rows(row).Cells(2).Value = Format(i, "##,##0")
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(2).Value.ToString, f10, Brushes.Black, rightmargin, 120 + height, right)
        Next

        Dim height2 As Integer

        height2 = 130 + height

        sumprice()
        e.Graphics.DrawString("Total: " & Format(t_price, "##,##0"), f10b, Brushes.Black, rightmargin, 10 + height2, right)
        e.Graphics.DrawString(t_qty, f10b, Brushes.Black, 0, 10 + height2)

        e.Graphics.DrawString(line, f8, Brushes.Black, centermargin, 35 + height2, center)
        e.Graphics.DrawString("Thanks for shopping", f10b, Brushes.Black, centermargin, 50 + height2, center)
        e.Graphics.DrawString("Redge Espiritu Store", f10b, Brushes.Black, centermargin, 65 + height2, center)
    End Sub
    Dim t_price As Long
    Dim t_qty As Long
    Sub sumprice()
        Dim countprice As Long = 0

        For rowitem As Long = 0 To DataGridView1.RowCount - 1
            countprice = countprice + Val(DataGridView1.Rows(rowitem).Cells(2).Value * DataGridView1.Rows(rowitem).Cells(1).Value)
        Next
        t_price = countprice

        Dim countqty As Long = 0
        For rowitem As Long = 0 To DataGridView1.RowCount - 1
            countqty = countqty + DataGridView1.Rows(rowitem).Cells(1).Value
        Next
        t_qty = countqty

    End Sub
End Class
