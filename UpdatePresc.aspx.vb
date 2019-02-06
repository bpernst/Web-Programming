
Imports System.Data

Partial Class UpdatePresc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim MyID, MyEdit As String
        Dim PrescriptionDataTier As New UpdateDataTier
        Dim SecurityDataTier As New SecurityDataTier
        Dim PresIDDataTier As New GridViewDataTier
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
            Dim DoctorData As New UpdateDataTier
            Dim ds As New DataSet()

            ds = PresIDDataTier.GetPrescriptionByID(MyID)
            'is edit
            If MyEdit.ToUpper = "EDIT" Then
                btnsubmit.Text = "UPDATE"
                btnsubmit.ForeColor = Drawing.Color.Red
                litTitle.Text = "Edit a prescription"

                'populate the controls
                With Me
                    .txtdocid.Enabled = False
                    .txtdocid.Text = ds.Tables(0).Rows(0)("PHYSICIAN_ID").ToString
                    .txtpatiid.Enabled = False
                    .txtpatiid.Text = ds.Tables(0).Rows(0)("PATIENT_ID").ToString
                    .txtpresid.Enabled = False
                    .txtpresid.Text = ds.Tables(0).Rows(0)("PRESCRIPTION_ID").ToString
                    .txtdosage.Text = ds.Tables(0).Rows(0)("DOSAGE").ToString
                    .txtintake.Text = ds.Tables(0).Rows(0)("INTAKE_METHOD").ToString
                    .txtfrequency.Text = ds.Tables(0).Rows(0)("FREQUENCY").ToString
                    .txtmedname.Text = ds.Tables(0).Rows(0)("MEDICATION_NAME").ToString
                    .txtrefillamnt.Text = ds.Tables(0).Rows(0)("REFILL_AMT").ToString




                End With





            End If
        End If
    End Sub



    Protected Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtpresid.Text = " "
        txtmedname.Text = " "
        txtrefillamnt.Text = " "
        txtdosage.Text = " "
        txtintake.Text = " "
        txtfrequency.Text = " "
        txtdocid.Text = " "
        txtpatiid.Text = " "

    End Sub

    Protected Sub btnstubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try

            If btnsubmit.Text.ToUpper = "UPDATE" Then
                Dim aPrescriptionUpdate As New UpdateDataTier
                Dim pres_id As String
                Dim med_name As String
                Dim refill As Decimal
                Dim dosage As String
                Dim intake As String
                Dim freqeuncy As String
                Dim doc_id As String
                Dim pat_id As String


                pres_id = txtpresid.Text.Trim
                med_name = txtmedname.Text.Trim
                refill = Decimal.Parse(txtrefillamnt.Text.Trim)
                dosage = txtdosage.Text.Trim
                intake = txtintake.Text.Trim
                freqeuncy = txtfrequency.Text.Trim
                doc_id = txtdocid.Text.Trim
                pat_id = txtpatiid.Text.Trim


                'add business class
                ''now use business class for datatier update
                'astudentdatatier.UpdateStudent(Me.lblStudentID.Text.Trim, Me.txtFname.Text.Trim, Me.txtLname.Text.Trim, Me.cboGender.SelectedValue, Me.ddlState.SelectedValue)
                aPrescriptionUpdate.UpdatePrescription(pres_id, med_name, refill, dosage, intake, freqeuncy, doc_id, pat_id)
                btnsubmit.Enabled = False
                btnclose.Text = "Refresh"
                btnclose.ForeColor = Drawing.Color.Maroon
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
