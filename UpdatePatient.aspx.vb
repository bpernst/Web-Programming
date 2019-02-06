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
        txthomephone.Text = " "
        txtcellphone.Text = " "
        txtemail1.Text = " "
        txtemail2.Text = " "
        txtemail3.Text = " "
        txtstreetaddress.Text = " "
        txtcity.Text = " "
        txtzip.Text = " "

    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyID, MyEdit As String
        Dim Gender As String
        Dim PatientDataTier As New UpdateDataTier
        Dim SecurityDataTier As New SecurityDataTier
        Dim PatIDDataTier As New GridViewDataTier
        MyEdit = ""

        Page.ClientScript.RegisterClientScriptInclude("Test", "MyScript.js")


        MyEdit = ""
        If Not IsPostBack Then
            'retrieve querystring
            Dim strCrypt As String
            strCrypt = Request.QueryString("ID").Trim
            MyID = SecurityDataTier.Decrypt(strCrypt.Replace(" ", "+"), "12345678")
            'make sure there is a querystirng
            If Not IsNothing(Request.QueryString("type")) And (Request.QueryString("type") <> String.Empty) Then
                MyEdit = Request.QueryString("type").Trim
            End If
            'retrieve data from table
            Dim PatientData As New UpdateDataTier
            Dim ds As New DataSet()

            ds = PatIDDataTier.GetPatientByID(MyID)
            'is edit
            If MyEdit.ToUpper = "EDIT" Then
                btnsubmit.Text = "UPDATE"
                btnsubmit.ForeColor = Drawing.Color.Red
                litTitle.Text = "Edit a patient"

                'populate the controls
                With Me
                    .txtpatiid.Enabled = False
                    .txtpatiid.Text = ds.Tables(0).Rows(0)("PATIENT_ID").ToString
                    .txtfname.Text = ds.Tables(0).Rows(0)("FNAME").ToString
                    .txtlname.Text = ds.Tables(0).Rows(0)("LNAME").ToString
                    .txtmidinit.Text = ds.Tables(0).Rows(0)("MIDINIT").ToString
                    .txtcity.Text = ds.Tables(0).Rows(0)("CITY").ToString
                    .txtdob.Text = ds.Tables(0).Rows(0)("DOB").ToString
                    .txtcellphone.Text = ds.Tables(0).Rows(0)("CELL_PHONE").ToString
                    .txthomephone.Text = ds.Tables(0).Rows(0)("HOME_PHONE").ToString
                    .txtstreetaddress.Text = ds.Tables(0).Rows(0)("STREET").ToString
                    .txtzip.Text = ds.Tables(0).Rows(0)("ZIP").ToString
                    .ddlGender.SelectedValue = ds.Tables(0).Rows(0)("GENDER").ToString
                    .TextBox1.Text = ds.Tables(0).Rows(0)("PATIENT_STATE").ToString
                    .txtdob.Text = ds.Tables(0).Rows(0)("DOB").ToString
                    .txtemail1.Text = ds.Tables(0).Rows(0)("EMAIL_I").ToString
                    .txtemail2.Text = ds.Tables(0).Rows(0)("EMAIL_II").ToString
                    .txtemail3.Text = ds.Tables(0).Rows(0)("EMAIL_III").ToString

                End With




            End If
        End If
    End Sub
    Protected Sub btnstubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try

            If btnsubmit.Text.ToUpper = "UPDATE" Then
                Dim aPatientUpdate As New UpdateDataTier
                Dim lname As String
                Dim fname As String
                Dim patID As String
                Dim Gender As String
                Dim State As String
                Dim mid As String
                Dim Homephone As String
                Dim City As String
                Dim PrimaryEmail As String
                Dim DOB As Date
                Dim Cell As String
                Dim SecondEmail As String
                Dim Street As String
                Dim Zip As Decimal
                Dim ThirdEmail As String

                lname = txtlname.Text.Trim
                fname = txtfname.Text.Trim
                patID = txtpatiid.Text.Trim
                Gender = ddlGender.SelectedValue
                State = TextBox1.Text.Trim
                mid = txtmidinit.Text.Trim
                Homephone = txthomephone.Text.Trim
                City = txtcity.Text.Trim
                PrimaryEmail = txtemail1.Text.Trim
                DOB = txtdob.Text.Trim
                Cell = txtcellphone.Text.Trim
                SecondEmail = txtemail2.Text.Trim
                Street = txtstreetaddress.Text.Trim
                Zip = Decimal.Parse(txtzip.Text.Trim)
                ThirdEmail = txtemail3.Text.Trim

                'add business class
                ''now use business class for datatier update
                'astudentdatatier.UpdateStudent(Me.lblStudentID.Text.Trim, Me.txtFname.Text.Trim, Me.txtLname.Text.Trim, Me.cboGender.SelectedValue, Me.ddlState.SelectedValue)
                aPatientUpdate.UpdatePatient(patID, fname, mid, lname, Gender, Street, City, State, Zip, DOB, Homephone, Cell, PrimaryEmail, SecondEmail, ThirdEmail)
                btnsubmit.Enabled = False
                btnclose.Text = "Refresh"
                btnclose.ForeColor = Drawing.Color.Maroon
            End If
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Try

            If btnclose.Text.ToUpper = "REFRESH" Then
                'close the page refresh the datagrid
                Dim cb As New StringBuilder
                With cb
                    .Append(" opener.location.href = 'viewpage.aspx';")
                    .Append("var ie7 = (document.all && !windows.opera && window.XMLHttpRequest) ? true : false;")
                    .Append(" if (ie7)")
                    .Append(" { ")
                    .Append("window.open('','_parent','');")
                    .Append("window.close();")
                    .Append(" } ")
                    .Append(" else ")
                    .Append(" { ")
                    .Append(" this.focus();")
                    .Append(" self.opener = this;")
                    .Append(" self.close();")
                    .Append(" } ")
                End With
                ClientScript.RegisterClientScriptBlock(GetType(Page), "CloseReloadScript", cb.ToString(), True)

            ElseIf btnclose.Text.ToUpper = "CLOSE" Then
                'Close this form
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "close form", "CloseMe()", True)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
