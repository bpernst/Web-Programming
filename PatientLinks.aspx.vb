
Imports System.Data

Partial Class PatientLinks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        If Not IsPostBack Then
            LoadData()
        Else
            'Do nothing
            'LoadData()
        End If

    End Sub

    Protected Sub btnAddPat_OnClick(sender As Object, e As EventArgs) Handles btnAddPat.Click




    End Sub

    Private Sub LoadData()
        Dim aDatatier As New GridViewDataTier
        With Me
            Dim aDataset As New DataSet()
            aDataset = aDatatier.GetPatients()

            .grdPatients.DataSource = aDataset.Tables(0)
            .grdPatients.DataBind()
        End With
    End Sub

    Private Sub GrdPatients_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdPatients.RowDataBound

        If (e.Row.RowType = DataControlRowType.Header) Then

            CType(e.Row.FindControl("cbSelectAll"), CheckBox).Attributes.Add("onclick",
            "javascript:SelectAll('" + CType(e.Row.FindControl("cbSelectAll"),
            CheckBox).ClientID + "')")

        End If

    End Sub

    Protected Sub LbtnDelete_Click(sender As Object, e As EventArgs)

        Try
            Dim aDatatier As New DeleteDataTier
            Dim chk As CheckBox
            Dim lbl As Label
            Dim pat_ID As String

            Dim DS As New DataSet

            DS = grdPatients.DataSource

            If grdPatients.Rows.Count > 0 Then

                For Each row As GridViewRow In grdPatients.Rows
                    chk = CType(row.Controls(0).FindControl("chkPatId"), CheckBox)
                    If chk.Checked = True Then
                        lbl = CType(row.Controls(0).FindControl("hidPatID"), Label)
                        pat_ID = lbl.Text.Trim
                        'Delete record one at a time
                        aDatatier.DeletePatient(pat_ID)
                    End If
                Next
                'refresh datagrid
                With Me
                    Dim aDataset As New DataSet
                    Dim aDataTier2 As New GridViewDataTier

                    aDataset = aDataTier2.GetPatients()
                    grdPatients.DataSource = aDataset
                    grdPatients.DataBind()

                End With

                LoadData()

            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Protected Sub btnUpdPat_OnClick(ByVal sender As Object, ByVal e As CommandEventArgs)

        Dim PatientDataTier As New UpdateDataTier
        Dim SecurityDataTier As New SecurityDataTier
        Dim GridDataTier As New GridViewDataTier
        Dim rdo As RadioButton
        Dim lbl As Label
        Dim pat_ID As String

        Dim DS As New DataSet

        DS = grdPatients.DataSource

        If grdPatients.Rows.Count > 0 Then
            For Each row As GridViewRow In grdPatients.Rows
                rdo = CType(row.Controls(0).FindControl("rdoUpdatePat"), RadioButton)
                If rdo.Checked = True Then
                    lbl = CType(row.Controls(0).FindControl("hidPatID"), Label)
                    pat_ID = lbl.Text.Trim
                    Try

                        'Get the record
                        GridDataTier.GetPatientByID(pat_ID)


                        'this script will open a popup
                        Dim sb As New StringBuilder
                        sb.Append("<script language='javascript'>")
                        sb.Append("window.open('UpdatePatient.aspx?ID=" + SecurityDataTier.Encrypt(pat_ID, "12345678") + "&type=Edit" + "'  , 'patient',")
                        sb.Append("'width=525, height=525, menubar=no, resizable=yes, left=50, top=50, scrollbars=yes');<")
                        sb.Append("/script>")

                        'register with ClientScript
                        ClientScript.RegisterClientScriptBlock(GetType(Page), "PopupScript", sb.ToString())
                    Catch ex As Exception
                        Throw New Exception(ex.Message, ex.InnerException)
                    End Try
                End If
            Next
        End If

    End Sub


    Protected Sub OpenWindow(sender As Object, e As EventArgs)
        Dim url As String = "AddPatient.aspx"
        Dim s As String = "window.open('" & url + "', 'popup_window', 'width=600,height=600,left=100,top=100,resizable=yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub
End Class
