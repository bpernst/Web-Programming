Imports System.Data
Partial Class AddDoctor
    Inherits System.Web.UI.Page

    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtdocid.Text = " "
        txtfname.Text = " "
        txtlname.Text = " "
        txtmidinit.Text = " "
        txtdob.Text = " "
        txofficephone.Text = " "
        txtpersonalphone.Text = " "
        txtworkemail.Text = " "
        txtemail1.Text = " "
        txtemail2.Text = " "
        txtposition.Text = " "
        txtspecialty1.Text = " "
        txtstreetaddress.Text = " "
        txtcity.Text = " "
        txtstate.Text = " "
        txtzip.Text = " "
        txtsalary.Text = " "


    End Sub
    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click




        Dim doc, fname, lname, midint, gener, workemail, email1, email2, position, specialty, address, city, state, office, perosonal As String
            Dim dob As Date
            Dim salary, zip As Decimal

            doc = txtdocid.Text.Trim
            fname = txtfname.Text.Trim
            midint = txtmidinit.Text.Trim
            lname = txtlname.Text.Trim
            gener = cbogender.SelectedValue
            address = txtstreetaddress.Text.Trim
            city = txtcity.Text.Trim
            state = txtstate.Text.Trim
            zip = Decimal.Parse(txtzip.Text.Trim)
            dob = txtdob.Text.Trim
            office = txofficephone.Text.Trim
            perosonal = txtpersonalphone.Text.Trim
            email1 = txtemail1.Text.Trim
            email2 = txtemail2.Text.Trim
            workemail = txtworkemail.Text.Trim
            position = txtposition.Text.Trim
            specialty = txtspecialty1.Text.Trim
            salary = Decimal.Parse(txtsalary.Text.Trim)

            Dim AddDataTier As New AddDataTier
            Dim ds As New DataSet()
            With Me
                ds = AddDataTier.ADDDOCTOR(doc, fname, midint, lname, gener, address, city, state, zip, dob, office, perosonal, email1, email2, workemail, position, specialty, salary)

            End With
            Label1.Text = "Record Added successfully"



    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load



    End Sub
End Class
