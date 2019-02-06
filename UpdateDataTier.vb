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
Public Class UpdateDataTier
    'Create connection
    Dim connString As New SqlClient.SqlConnection(ConnectionStrings("DBConnectionString").ConnectionString)
    Dim cmdString As New SqlClient.SqlCommand
    Public Sub UpdatePatient(ByVal PATIENT_ID As String, ByVal FNAME As String, ByVal MIDINIT As String, ByVal LNAME As String, ByVal GENDER As String, ByVal STREET As String, ByVal CITY As String, ByVal PATIENT_STATE As String, ByVal ZIP As Decimal, ByVal DOB As Date, ByVal HOME_PHONE As String, ByVal CELL_PHONE As String, ByVal EMAIL1 As String, ByVal EMAIL2 As String, ByVal EMAIL3 As String)
        Try
            'open connection
            connString.Open()
            'command
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "UPDATEPATIENT"

            With cmdString
                ' .Parameters.Add()
                .Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 6).Value = PATIENT_ID
                .Parameters.Add("@FNAME", SqlDbType.VarChar, 25).Value = FNAME
                .Parameters.Add("@MIDINIT", SqlDbType.VarChar, 25).Value = MIDINIT
                .Parameters.Add("@LNAME", SqlDbType.VarChar, 25).Value = LNAME
                .Parameters.Add("@GENDER", SqlDbType.VarChar, 25).Value = GENDER
                .Parameters.Add("@STREET", SqlDbType.VarChar, 25).Value = STREET
                .Parameters.Add("@CITY", SqlDbType.VarChar, 25).Value = CITY
                .Parameters.Add("@PATIENT_STATE", SqlDbType.Char, 2).Value = PATIENT_STATE
                .Parameters.Add("@ZIP", SqlDbType.VarChar, 25).Value = ZIP
                .Parameters.Add("@DOB", SqlDbType.VarChar, 25).Value = DOB
                .Parameters.Add("@HOME_PHONE", SqlDbType.VarChar, 25).Value = HOME_PHONE
                .Parameters.Add("@CELL_PHONE", SqlDbType.VarChar, 25).Value = CELL_PHONE
                .Parameters.Add("@EMAIL_I", SqlDbType.VarChar, 25).Value = EMAIL1
                .Parameters.Add("@EMAIL_II", SqlDbType.VarChar, 25).Value = EMAIL2
                .Parameters.Add("@EMAIL_III", SqlDbType.VarChar, 25).Value = EMAIL3
                .ExecuteNonQuery()

            End With

        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Sub

    Public Sub UpdatePhysician(ByVal PATIENT_ID As String, ByVal FNAME As String, ByVal MIDINIT As String, ByVal LNAME As String, ByVal GENDER As String, ByVal STREET As String, ByVal CITY As String, ByVal PHYSICIAN_STATE As String, ByVal ZIP As Decimal, ByVal DOB As Date, ByVal PERSONAL_PHONE As String, ByVal OFFICE_PHONE As String, ByVal EMAIL1 As String, ByVal EMAIL2 As String, ByVal WORK_EMAIL As String, ByVal POSITION As String, ByVal SPECIALITY As String, ByVal SALARY As Decimal)
        Try
            'open connection
            connString.Open()
            'command
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "UPDATEPHYSICIAN"

            With cmdString
                ' .Parameters.Add()
                .Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 6).Value = PATIENT_ID
                .Parameters.Add("@FNAME", SqlDbType.VarChar, 25).Value = FNAME
                .Parameters.Add("@MIDINIT", SqlDbType.VarChar, 25).Value = MIDINIT
                .Parameters.Add("@LNAME", SqlDbType.VarChar, 25).Value = LNAME
                .Parameters.Add("@GENDER", SqlDbType.VarChar, 25).Value = GENDER
                .Parameters.Add("@STREET", SqlDbType.VarChar, 25).Value = STREET
                .Parameters.Add("@CITY", SqlDbType.VarChar, 25).Value = CITY
                .Parameters.Add("@PHYSICIAN_STATE", SqlDbType.Char, 2).Value = PHYSICIAN_STATE
                .Parameters.Add("@ZIP", SqlDbType.VarChar, 25).Value = ZIP
                .Parameters.Add("@DOB", SqlDbType.VarChar, 25).Value = DOB
                .Parameters.Add("@PERSONAL_PHONE", SqlDbType.VarChar, 14).Value = PERSONAL_PHONE
                .Parameters.Add("@OFFICE_PHONE", SqlDbType.VarChar, 14).Value = OFFICE_PHONE
                .Parameters.Add("@EMAIL_I", SqlDbType.VarChar, 25).Value = EMAIL1
                .Parameters.Add("@EMAIL_II", SqlDbType.VarChar, 25).Value = EMAIL2
                .Parameters.Add("@WORK_EMAIL", SqlDbType.VarChar, 25).Value = WORK_EMAIL
                .Parameters.Add("@POSITION", SqlDbType.VarChar, 50).Value = POSITION
                .Parameters.Add("@SPECIALTY", SqlDbType.VarChar, 50).Value = SPECIALITY
                .Parameters.Add("@SALARY", SqlDbType.Decimal, 8, 2).Value = SALARY
                .ExecuteNonQuery()

            End With

        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try
    End Sub

    Public Sub UpdatePrescription(ByVal PRESCRIPTION_ID As String, ByVal MEDICATION_NAME As String, ByVal REFILL_AMT As Decimal, ByVal DOSAGE As String, ByVal INTAKE_METHOD As String, ByVal FREQUENCY As String, ByVal PHYSICIAN_ID As String, ByVal PATIENT_ID As String)
        Try
            'open connection
            connString.Open()
            'command
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "UPDATEPRESCRIPTION"

            With cmdString
                .Parameters.Add("@PRESCRIPTION_ID", SqlDbType.VarChar, 5).Value = PRESCRIPTION_ID
                .Parameters.Add("@MEDICATION_NAME", SqlDbType.VarChar, 50).Value = MEDICATION_NAME
                .Parameters.Add("@REFILL_AMT", SqlDbType.Decimal, 3, 0).Value = REFILL_AMT
                .Parameters.Add("@DOSAGE", SqlDbType.VarChar, 50).Value = DOSAGE
                .Parameters.Add("@INTAKE_METHOD", SqlDbType.VarChar, 50).Value = INTAKE_METHOD
                .Parameters.Add("@FREQUENCY", SqlDbType.VarChar, 50).Value = FREQUENCY
                .Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = PHYSICIAN_ID
                .Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 5).Value = PATIENT_ID
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()
        End Try



    End Sub

End Class
