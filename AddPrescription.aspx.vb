Imports System.Data
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic
Partial Class AddPrescription
    Inherits System.Web.UI.Page
    Dim connString As New SqlClient.SqlConnection(ConnectionStrings("DBConnectionString").ConnectionString)
    Dim cmdString As New SqlClient.SqlCommand
    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtpresid.Text = " "
        txtmedname.Text = " "
        txtrefillamnt.Text = " "
        txtdosage.Text = " "
        txtintake.Text = " "
        txtfrequency.Text = " "
        txtdocid.Text = " "
        txtpatid.Text = ""
        txtdate.Text = ""

    End Sub
    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Dim Presc_ID, Med, dosage, intake, freq, phys_id, pat_id As String
        Dim Refill As Decimal

        Presc_ID = txtpresid.Text.Trim
        Med = txtmedname.Text.Trim
        Refill = Decimal.Parse(txtrefillamnt.Text.Trim)
        dosage = txtdosage.Text.Trim
        intake = txtintake.Text.Trim
        freq = txtfrequency.Text.Trim
        phys_id = txtdocid.Text.Trim
        pat_id = txtpatid.Text.Trim
        Pres_Date = Date.Parse(txtDate.Text.Trim)


        Dim adatatir As New AddDataTier
        Dim ds As New DataSet()

        ds = adatatir.ADDPRESC(Presc_ID, Med, Refill, dosage, intake, freq, phys_id, pat_id)

        Label1.Text = "Record Added Succesfully"
    End Sub

End Class
