Imports sycsa.Information
Imports sycsa.DataAccessLayer

Public Class BLGcRecoveryPass
    Inherits Information.InfoGcRecoveryPass
    Public objDA As New DataAccessLayer.DAGcRecoveryPass
    Public DataSet As New DataSet
    'Usuario al que se valido Su Email
    Public _UserValidMail As InfoUsers

#Region "Validation"
    ''' <summary>
    ''' Comprueba si el email al que se enviara el restablecimiento de la contraseña es valido
    ''' </summary>
    ''' <param name="eMail"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidMail(ByVal eMail As String) As Boolean
        Dim valResult As Boolean = False
        Try
            Dim tUsers As New BLUsers
            Dim listUsers As List(Of InfoUsers) = objDA.GetUserByMail(eMail)
            If listUsers.Count > 0 Then
                valResult = True
                _UserValidMail = listUsers(0)
            Else
                valResult = False
            End If
            Return valResult
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Comprueba si no existe alguna solicitud anterior del correo electronica o si se encuentre abierta (dentro del plazo de las 24 horas)
    ''' </summary>
    ''' <param name="UservalidMail"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCurrentRecoveryPass(ByVal UservalidMail As InfoUsers) As Boolean
        Dim valResult As Boolean = False
        Try
            Dim tUsers As New BLUsers
            Dim listUsers As List(Of InfoGcRecoveryPass) = objDA.GetCurrentRecoveryPass(UservalidMail)
            If listUsers.Count > 0 Then
                valResult = True
                Me.Id_R = listUsers(0).Id_R
                Me.IdUser = listUsers(0).IdUser
                Me.Fecha = listUsers(0).Fecha
                Me.IP = listUsers(0).IP
                Me.HASH = listUsers(0).HASH
                Me.Status = listUsers(0).Status
                Me.Expira = listUsers(0).Expira
            Else
                valResult = False
            End If
            Return valResult
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function


    ''' <summary>
    ''' CValida el Hash del Usuario y carga los datos del usuario y La solicitud de cambio de contraseña
    ''' </summary>
    ''' <param name="strHash"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidaHash(ByVal strHash As String) As Boolean
        Dim valResult As Boolean = False
        Try
            Dim tUsers As New BLUsers
            Dim listUsers As List(Of InfoGcRecoveryPass) = objDA.ValidaHash(strHash)
            If listUsers.Count > 0 Then
                Me.Id_R = listUsers(0).Id_R
                Me.IdUser = listUsers(0).IdUser
                Me.Fecha = listUsers(0).Fecha
                Me.IP = listUsers(0).IP
                Me.HASH = listUsers(0).HASH
                Me.Status = listUsers(0).Status
                Me.Expira = listUsers(0).Expira
                Dim oBlUser As New BLUsers
                oBlUser.Id = Me.IdUser
                If oBlUser.LoadById.Count > 0 Then
                    Me._UserValidMail = oBlUser.LoadById(0)
                End If
                valResult = True
            Else
                valResult = False
            End If
            Return valResult
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function Accountactive() As Boolean
        Try
            With objDA
                Dim Active As Boolean
                Active = .Accountactive(CType(Me, Information.InfoGcRecoveryPass))
                Return Active
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region



#Region "Save"
    Public Sub Save()
        Try
            objDA.Save(CType(Me, Information.InfoGcRecoveryPass))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SetNewPassWord()
        Try
            objDA.SetNewPassWord(Me._UserValidMail)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


#End Region

#Region "Update"
    Public Sub UpdDisablesRequestEmail()
        Try
            objDA.UpdDisablesRequestEmail(CType(Me, Information.InfoGcRecoveryPass))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Delete"
    Public Sub Delete()
        Try
            objDA.Delete(CType(Me, Information.InfoGcRecoveryPass))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region




#Region "Load"

    Public Function LoadById() As List(Of InfoGcRecoveryPass)
        Try
            Dim ObjInfoUser As New List(Of InfoGcRecoveryPass)
              ObjInfoUser = objDA.LoadById(CType(Me, InfoGcRecoveryPass))
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function LoadUser() As List(Of InfoGcRecoveryPass)
        Try
            Dim ObjInfoUser As New List(Of InfoGcRecoveryPass)
            '   ObjInfoUser = objDA.LoadUser(CType(Me, InfoGcRecoveryPass))
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function StartSesion() As List(Of InfoGcRecoveryPass)
        Try
            Dim ObjInfoUser As New List(Of InfoGcRecoveryPass)
            ' ObjInfoUser = objDA.StartSesion(CType(Me, InfoGcRecoveryPass))
            Return ObjInfoUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region


End Class
