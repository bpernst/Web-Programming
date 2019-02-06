Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Text

Public Class DeleteDataTier

    Dim connString As New SqlClient.SqlConnection(ConnectionStrings("DBConnectionString").ConnectionString)
    Dim cmdString As New SqlClient.SqlCommand

    Public Sub DeletePhysician(ByVal physID As String)

        Try
            'open connection
            connString.Open()
            cmdString.Parameters.Clear()
            'command
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "DELETEPHYSICIAN"
                'Define input parameter
                .Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = physID
                'execute command
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Sub

    Public Sub DeletePatient(ByVal patID As String)

        Try
            'open connection
            connString.Open()
            cmdString.Parameters.Clear()
            'command
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "DELETEPATIENT"
                'Define input parameter
                .Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 5).Value = patID
                'execute command
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Sub

    Public Sub DeletePrescription(ByVal presID As String)

        Try
            'open connection
            connString.Open()
            cmdString.Parameters.Clear()
            'command
            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 900
                .CommandText = "DELETEPRESCRIPTION"
                'Define input parameter
                .Parameters.Add("@PRESCRIPTION_ID", SqlDbType.VarChar, 5).Value = presID
                'execute command
                .ExecuteNonQuery()
            End With
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Sub


End Class
