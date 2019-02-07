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

Public Class GridViewDataTier
    'Create connection
    Dim connString As New SqlClient.SqlConnection(ConnectionStrings("DBConnectionString").ConnectionString)
    Dim cmdString As New SqlClient.SqlCommand


    Public Function GetStudentByName(ByVal name As String) As DataSet

        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "FINDPHYSICIANSBYID"

            cmdString.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 25).Value = name

            Dim aadapter As New SqlClient.SqlDataAdapter
            aadapter.SelectCommand = cmdString
            Dim adataset As New DataSet

            aadapter.Fill(adataset)

            Return adataset

        Catch ex As Exception

        End Try
    End Function

    Public Function GetpatByName(ByVal name As String) As DataSet

        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "FINDPATIENTSBYID"

            cmdString.Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 25).Value = name

            Dim aadapter As New SqlClient.SqlDataAdapter
            aadapter.SelectCommand = cmdString
            Dim adataset As New DataSet

            aadapter.Fill(adataset)

            Return adataset

        Catch ex As Exception

        End Try
    End Function

    Public Function GetpresByid(ByVal name As String) As DataSet

        Try
            connString.Open()
            cmdString.Parameters.Clear()
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "GETPRESCRIPTIONBYID"

            cmdString.Parameters.Add("@PRESCRIPTION_ID", SqlDbType.VarChar, 25).Value = name

            Dim aadapter As New SqlClient.SqlDataAdapter
            aadapter.SelectCommand = cmdString
            Dim adataset As New DataSet

            aadapter.Fill(adataset)

            Return adataset

        Catch ex As Exception

        End Try
    End Function
    Public Function GetPatients() As DataSet

        Try
            'Open connection and call procedure
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "GETPATIENTS"


            'adapter and dataset
            Dim aAdapter As New SqlClient.SqlDataAdapter With {
                .SelectCommand = cmdString
            }
            Dim aDataSet As New DataSet

            'fill adapater
            aAdapter.Fill(aDataSet, "PATIENT")
            Return aDataSet

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function GetPhysician() As DataSet

        Try
            'Open connection and call procedure
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "GETPHYSICIAN"


            'adapter and dataset
            Dim aAdapter As New SqlClient.SqlDataAdapter With {
                .SelectCommand = cmdString
            }
            Dim aDataSet As New DataSet

            'fill adapater
            aAdapter.Fill(aDataSet, "PHYSICIAN")
            Return aDataSet

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function GetPrescription() As DataSet

        Try
            'Open connection and call procedure
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "GETPRESCRIPTION"


            'adapter and dataset
            Dim aAdapter As New SqlClient.SqlDataAdapter With {
                .SelectCommand = cmdString
            }
            Dim aDataSet As New DataSet

            'fill adapater
            aAdapter.Fill(aDataSet, "PRESCRIPTION")
            Return aDataSet

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            connString.Close()
        End Try
    End Function

    Public Function GetPatientByID(ByVal PatientID As String) As DataSet
        Try

            'open connection
            connString.Open()
            'command
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "FINDPATIENTSBYID"
            'parameter must be same name as procedure argument
            cmdString.Parameters.Add("@PATIENT_ID", SqlDbType.VarChar).Value = PatientID
            'adapter and dataset
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet

            'fill adapater
            aAdapter.Fill(aDataSet)

            'return dataSet
            Return aDataSet

        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try

    End Function

    Public Function GetPhysicianByID(ByVal PhysicianID As String) As DataSet
        Try

            'open connection
            connString.Open()
            'command
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "FINDPHYSICIANSBYID"
            'parameter must be same name as procedure argument
            cmdString.Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = PhysicianID
            'adapter and dataset
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet

            'fill adapater
            aAdapter.Fill(aDataSet)

            'return dataSet
            Return aDataSet

        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try

    End Function

    Public Function GetPrescriptionByID(ByVal Prescription_ID As String) As DataSet

        Try
            connString.Open()
            'command
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "GETPRESCRIPTIONBYID"
            cmdString.Parameters.Add("@PRESCRIPTION_ID", SqlDbType.VarChar, 5).Value = Prescription_ID
            'adapter and dataset
            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            'fill adapter
            aAdapter.Fill(aDataSet)
            'return dataset
            Return aDataSet
        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try

    End Function

End Class
