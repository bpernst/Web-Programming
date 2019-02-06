Imports System.Data
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic
Partial Class AddPatient
    Inherits System.Web.UI.Page

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtpatiid.Text = " "
        txtfname.Text = " "
        txtlname.Text = " "
        txtmidinit.Text = " "
        txtdob.Text = " "
        DropDownList1.SelectedValue = "Other"
        txthomephone.Text = " "
        txtcellphone.Text = " "
        txtemail1.Text = " "
        txtemail2.Text = " "
        txtemail3.Text = " "
        txtstreetaddress.Text = " "
        txtcity.Text = " "
        txtstate.Text = " "
        txtzip.Text = " "


    End Sub

    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Dim Pat_ID, fname, midnint, lname, gender, street, city, state, home, cell, emal1, email2, email3 As String
        Dim zip As Decimal
        Dim dob As Date

        Pat_ID = txtpatiid.Text.Trim
        fname = txtfname.Text.Trim
        midnint = txtmidinit.Text.Trim
        lname = txtlname.Text.Trim
        gender = DropDownList1.SelectedValue
        street = txtstreetaddress.Text.Trim
        city = txtcity.Text.Trim
        state = txtstate.Text.Trim
        zip = Decimal.Parse(txtzip.Text.Trim)
        dob = Date.Parse(txtdob.Text.Trim)
        home = txthomephone.Text.Trim
        cell = txtcellphone.Text.Trim
        emal1 = txtemail1.Text.Trim
        email2 = txtemail2.Text.Trim
        email3 = txtemail3.Text.Trim

        Dim ds As New DataSet()
        Dim adatateir As New AddDataTier

        ds = adatateir.ADDPAT(Pat_ID, fname, midnint, lname, gender, street, city, state, zip, dob, home, cell, emal1, email2, email3)

        Label1.Text = "Record Added successfully"
    End Sub
End Class
