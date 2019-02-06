Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Web
Imports System.Configuration.ConfigurationManager
Imports System.Collections
Imports System.Collections.Generic

Public Class AddDataTier
    Dim connString As New SqlClient.SqlConnection(ConnectionStrings("DBConnectionString").ConnectionString)
    Dim cmdString As New SqlClient.SqlCommand

    Public Function ADDPAT(ByVal Pat_ID As String, ByVal fname As String, ByVal mindint As String, ByVal lname As String, ByVal Gender As String, ByVal street As String, ByVal city As String, ByVal pat_state As String, ByVal zip As Decimal, ByVal DOB As Date, ByVal home_phone As String, ByVal Cell As String, ByVal email_1 As String, ByVal email_2 As String, ByVal email_3 As String) As DataSet
        Try
            connString.Open()

            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 1500
                .CommandText = "ADDPATIENT"

                .Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 5).Value = Pat_ID
                .Parameters.Add("@FNAME", SqlDbType.VarChar, 25).Value = fname
                .Parameters.Add("@MIDINIT", SqlDbType.Char, 1).Value = mindint
                .Parameters.Add("@LNAME", SqlDbType.VarChar, 25).Value = lname
                .Parameters.Add("@GENDER", SqlDbType.VarChar, 25).Value = Gender
                .Parameters.Add("@STREET", SqlDbType.VarChar, 60).Value = street
                .Parameters.Add("@CITY", SqlDbType.VarChar, 60).Value = city
                .Parameters.Add("@PATIENT_STATE", SqlDbType.VarChar, 60).Value = pat_state
                .Parameters.Add("@ZIP", SqlDbType.Decimal, 5, 0).Value = zip
                .Parameters.Add("@DOB", SqlDbType.Date).Value = DOB
                .Parameters.Add("@HOME_PHONE", SqlDbType.VarChar, 14).Value = home_phone
                .Parameters.Add("@CELL_PHONE", SqlDbType.VarChar, 14).Value = Cell
                .Parameters.Add("@EMAIL_I", SqlDbType.VarChar, 60).Value = email_1
                .Parameters.Add("@EMAIL_II", SqlDbType.VarChar, 60).Value = email_2
                .Parameters.Add("@EMAIL_III", SqlDbType.VarChar, 60).Value = email_3

                .ExecuteNonQuery()
            End With

            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet

        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()

        End Try
    End Function

    Public Function ADDDOCTOR(ByVal Phys_ID As String, ByVal fname As String, ByVal mindint As String, ByVal lname As String, ByVal Gender As String, ByVal street As String, ByVal city As String, ByVal phys_state As String, ByVal zip As Decimal, ByVal DOB As Date, ByVal Office_phone As String, ByVal personal As String, ByVal EMAIL_I As String, ByVal EMAIL_II As String, ByVal Work As String, ByVal postition As String, ByVal specialty As String, ByVal salary As Decimal) As DataSet

        Try
            connString.Open()

            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 1500
                .CommandText = "ADDPHYSICIAN"

                .Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = Phys_ID
                .Parameters.Add("@FNAME", SqlDbType.VarChar, 25).Value = fname
                .Parameters.Add("@MIDINIT", SqlDbType.Char, 1).Value = mindint
                .Parameters.Add("@LNAME", SqlDbType.VarChar, 25).Value = lname
                .Parameters.Add("@GENDER", SqlDbType.VarChar, 25).Value = Gender
                .Parameters.Add("@STREET", SqlDbType.VarChar, 60).Value = street
                .Parameters.Add("@CITY", SqlDbType.VarChar, 60).Value = city
                .Parameters.Add("@PHYSICIAN_STATE", SqlDbType.VarChar, 60).Value = phys_state
                .Parameters.Add("@ZIP", SqlDbType.Decimal, 5, 0).Value = zip
                .Parameters.Add("@DOB", SqlDbType.Date).Value = DOB
                .Parameters.Add("@OFFICE_PHONE", SqlDbType.VarChar, 14).Value = Office_phone
                .Parameters.Add("@PERSONAL_PHONE", SqlDbType.VarChar, 14).Value = personal
                .Parameters.Add("@EMAIL_I", SqlDbType.VarChar, 60).Value = EMAIL_I
                .Parameters.Add("@EMAIL_II", SqlDbType.VarChar, 60).Value = EMAIL_II
                .Parameters.Add("@WORK_EMAIL", SqlDbType.VarChar, 60).Value = Work
                .Parameters.Add("@POSITION", SqlDbType.VarChar, 50).Value = postition
                .Parameters.Add("@SPECIALTY", SqlDbType.VarChar, 50).Value = specialty
                .Parameters.Add("@SALARY", SqlDbType.Decimal, 8, 2).Value = salary

                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()

        End Try
    End Function

    Public Function ADDPRESC(ByVal Presc_ID As String, ByVal MED_NAME As String, ByVal refill_amt As Decimal, ByVal dosage As String, ByVal intake As String, ByVal frequency As String, ByVal phys_id As String, ByVal pat_ID As String) As DataSet

        Try
            connString.Open()

            With cmdString
                .Connection = connString
                .CommandType = CommandType.StoredProcedure
                .CommandTimeout = 1500
                .CommandText = "ADDPRESCRIPTION"

                .Parameters.Add("@PRESCRIPTION_ID", SqlDbType.VarChar, 5).Value = Presc_ID
                .Parameters.Add("@MEDICATION_NAME", SqlDbType.VarChar, 50).Value = MED_NAME
                .Parameters.Add("@REFILL_AMT", SqlDbType.Decimal, 3, 0).Value = refill_amt
                .Parameters.Add("@DOSAGE", SqlDbType.VarChar, 50).Value = dosage
                .Parameters.Add("@INTAKE_METHOD", SqlDbType.VarChar, 50).Value = intake
                .Parameters.Add("@FREQUENCY", SqlDbType.VarChar, 50).Value = frequency
                .Parameters.Add("@PHYSICIAN_ID", SqlDbType.VarChar, 5).Value = phys_id
                .Parameters.Add("@PATIENT_ID", SqlDbType.VarChar, 5).Value = pat_ID

                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw New ArgumentException(ex.Message)
        Finally
            connString.Close()

        End Try
    End Function

    Public Function getpats() As DataSet

        Try

            ''using text
            'Dim cmdText As String
            'cmdText = "select * from Student"
            ''open connection
            cmdString.Parameters.Clear()
            connString.Open()
            ''cmdString.Connection = connString
            ''cmdString.CommandType = CommandType.Text
            'cmdString.CommandTimeout = 1500
            'cmdString.CommandText = cmdText
            cmdString.Connection = connString
            cmdString.CommandType = CommandType.StoredProcedure
            cmdString.CommandTimeout = 1500
            cmdString.CommandText = "GETPATIENTS"

            Dim aAdapter As New SqlClient.SqlDataAdapter
            aAdapter.SelectCommand = cmdString
            Dim aDataSet As New DataSet
            aAdapter.Fill(aDataSet)
            Return aDataSet
        Catch ex As Exception
        Finally
            connString.Close()

        End Try
    End Function
End Class
