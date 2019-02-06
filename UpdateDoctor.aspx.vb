
Imports System.Data

Partial Class UpdateDoctor
    Inherits System.Web.UI.Page

    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click

        Try


            Dim aPhysicianUpdate As New UpdateDataTier
            Dim lname As String
            Dim fname As String
            Dim patID As String
            Dim Gender As String
            Dim State As String
            Dim mid As String
            Dim PersonalPhone As String
            Dim City As String
            Dim PrimaryEmail As String
            Dim DOB As Date
            Dim Office As String
            Dim SecondEmail As String
            Dim Street As String
            Dim Zip As Decimal
            Dim WorkEmail As String
            Dim Position As String
            Dim Speciality As String
            Dim Salary As Decimal

            lname = txtlname.Text.Trim
            fname = txtfname.Text.Trim
            patID = txtdocid.Text.Trim
            Gender = cbogender.SelectedValue
            State = txtstate.Text.Trim
            mid = txtmidinit.Text.Trim
            PersonalPhone = txtpersonalphone.Text.Trim
            City = txtcity.Text.Trim
            PrimaryEmail = txtemail1.Text.Trim
            DOB = txtdob.Text.Trim
            Office = txofficephone.Text.Trim
            SecondEmail = txtemail2.Text.Trim
            Street = txtstreetaddress.Text.Trim
            Zip = Decimal.Parse(txtzip.Text.Trim)
            WorkEmail = txtworkemail.Text.Trim
            Position = txtposition.Text.Trim
            Speciality = txtspecialty1.Text.Trim
            Salary = Decimal.Parse(txtsalary.Text.Trim)


            'add business class
            ''now use business class for datatier update
            'astudentdatatier.UpdateStudent(Me.lblStudentID.Text.Trim, Me.txtFname.Text.Trim, Me.txtLname.Text.Trim, Me.cboGender.SelectedValue, Me.ddlState.SelectedValue)
            aPhysicianUpdate.UpdatePhysician(patID, fname, mid, lname, Gender, Street, City, State, Zip, DOB, PersonalPhone, Office, PrimaryEmail, SecondEmail, WorkEmail, Position, Speciality, Salary)
            btnsubmit.Enabled = False

            Label1.Text = "Record Updated successfully"

        Catch ex As Exception

        End Try

    End Sub

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
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim MyID, MyEdit As String
        Dim Gender As String
        Dim DoctorDataTier As New UpdateDataTier
        Dim SecurityDataTier As New SecurityDataTier
        Dim DocIDDataTier As New GridViewDataTier
        MyEdit = ""

        Page.ClientScript.RegisterClientScriptInclude("Test", "MyScript.js")


        MyEdit = ""
        If Not IsPostBack Then
            'retrieve querystring
            Dim strCrypt As String = Request.QueryString("ID").Trim



            MyID = SecurityDataTier.Decrypt(strCrypt.Replace(" ", "+"), "12345678")
            'make sure there is a querystirng
            If Not IsNothing(Request.QueryString("type")) And (Request.QueryString("type") <> String.Empty) Then
                MyEdit = Request.QueryString("type").Trim


            End If
            'retrieve data from table
            Dim DoctorData As New UpdateDataTier
            Dim ds As New DataSet()


            'is edit
            If MyEdit.ToUpper = "EDIT" Then

                btnsubmit.Text = "UPDATE"
                btnsubmit.ForeColor = Drawing.Color.Red
                litTitle.Text = "Edit a physician"
                ds = DocIDDataTier.GetPhysicianByID(MyID)
                'populate the controls
                With Me
                    .txtdocid.Enabled = False
                    .txtdocid.Text = ds.Tables(0).Rows(0)("PHYSICIAN_ID").ToString
                    .txtfname.Text = ds.Tables(0).Rows(0)("FNAME").ToString
                    .txtlname.Text = ds.Tables(0).Rows(0)("LNAME").ToString
                    .txtmidinit.Text = ds.Tables(0).Rows(0)("MIDINIT").ToString
                    .txtcity.Text = ds.Tables(0).Rows(0)("CITY").ToString
                    .txtdob.Text = ds.Tables(0).Rows(0)("DOB").ToString
                    .txofficephone.Text = ds.Tables(0).Rows(0)("OFFICE_PHONE").ToString
                    .txtpersonalphone.Text = ds.Tables(0).Rows(0)("PERSONAL_PHONE").ToString
                    .txtstreetaddress.Text = ds.Tables(0).Rows(0)("STREET").ToString
                    .txtzip.Text = ds.Tables(0).Rows(0)("ZIP").ToString
                    .cbogender.SelectedValue = ds.Tables(0).Rows(0)("GENDER").ToString
                    .txtstate.Text = ds.Tables(0).Rows(0)("PHYSICIAN_STATE").ToString
                    .txtdob.Text = ds.Tables(0).Rows(0)("DOB").ToString
                    .txtemail1.Text = ds.Tables(0).Rows(0)("EMAIL_I").ToString
                    .txtemail2.Text = ds.Tables(0).Rows(0)("EMAIL_II").ToString
                    .txtworkemail.Text = ds.Tables(0).Rows(0)("WORK_EMAIL").ToString
                    .txtposition.Text = ds.Tables(0).Rows(0)("POSITION").ToString
                    .txtspecialty1.Text = ds.Tables(0).Rows(0)("SPECIALTY").ToString
                    .txtsalary.Text = ds.Tables(0).Rows(0)("SALARY").ToString



                End With
            End If
        End If



    End Sub

End Class
