Imports System.Data


Partial Class DoctorLinks
    Inherits System.Web.UI.Page

    Protected Sub OpenWindow(sender As Object, e As EventArgs)
        Dim url As String = "AddDoctor.aspx"
        Dim s As String = "window.open('" & url + "', 'popup_window', 'width=800,height=800,left=100,top=100,resizable=yes');"
        ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)



    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            LoadData()
        Else
            'Do nothing
            'LoadData()
        End If

    End Sub
    
     Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim strlname As String

        strlname = txtSearch.Text.Trim

        Dim aDT As New GridViewDataTier
        With Me
            Dim ds As New DataSet
            ds = aDT.GetStudentByName(strlname)
            .grdPhysician.DataSource = ds.Tables(0)
            grdPhysician.DataBind()
        End With
    End Sub

    Private Sub LoadData()
        Dim aDatatier As New GridViewDataTier
        With Me
            Dim aDataset As New DataSet()
            aDataset = aDatatier.GetPhysician()

            .grdPhysician.DataSource = aDataset.Tables(0)
            .grdPhysician.DataBind()
        End With
    End Sub



    Protected Sub LbtnDelete_Click(sender As Object, e As EventArgs)

        Try
            Dim aDatatier As New DeleteDataTier
            Dim chk As CheckBox
            Dim lbl As Label
            Dim phys_ID As String

            Dim DS As New DataSet

            DS = grdPhysician.DataSource

            If grdPhysician.Rows.Count > 0 Then

                For Each row As GridViewRow In grdPhysician.Rows
                    chk = CType(row.Controls(0).FindControl("chkPhysId"), CheckBox)
                    If chk.Checked = True Then
                        lbl = CType(row.Controls(0).FindControl("hidPhysID"), Label)
                        phys_ID = lbl.Text.Trim
                        'Delete record one at a time
                        aDatatier.DeletePhysician(phys_ID)
                    End If
                Next
                'refresh datagrid
                With Me
                    Dim aDataset As New DataSet
                    Dim aDataTier2 As New GridViewDataTier

                    aDataset = aDataTier2.GetPhysician()
                    grdPhysician.DataSource = aDataset
                    grdPhysician.DataBind()

                End With

                LoadData()

            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Protected Sub btnUpdDoc_OnClick(ByVal sender As Object, ByVal e As CommandEventArgs)

        Dim PatientDataTier As New UpdateDataTier
        Dim SecurityDataTier As New SecurityDataTier
        Dim GridDataTier As New GridViewDataTier
        Dim rdo As RadioButton
        Dim lbl As Label
        Dim doc_ID As String

        Dim DS As New DataSet

        DS = grdPhysician.DataSource

        If grdPhysician.Rows.Count > 0 Then
            For Each row As GridViewRow In grdPhysician.Rows
                rdo = CType(row.Controls(0).FindControl("rdoUpdatePhys"), RadioButton)
                If rdo.Checked = True Then
                    lbl = CType(row.Controls(0).FindControl("hidPhysID"), Label)
                    doc_ID = lbl.Text.Trim
                    Try

                        'Get the record
                        GridDataTier.GetPhysicianByID(doc_ID)


                        'this script will open a popup
                        Dim sb As New StringBuilder
                        sb.Append("<script language='javascript'>")
                        sb.Append("window.open('UpdateDoctor.aspx?ID=" + SecurityDataTier.Encrypt(doc_ID, "12345678") + "&type=Edit" + "'  , 'patient',")
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
    Private Sub grdPhysician_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdPhysician.RowDataBound

        If (e.Row.RowType = DataControlRowType.Header) Then

            CType(e.Row.FindControl("cbSelectAll"), CheckBox).Attributes.Add("onclick",
            "javascript:SelectAll('" + CType(e.Row.FindControl("cbSelectAll"),
            CheckBox).ClientID + "')")

        End If

    End Sub
End Class
