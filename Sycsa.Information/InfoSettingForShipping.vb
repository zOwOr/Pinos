Public Class InfoSettingForShipping


    Private _SettingNotes As String
    Private _SettingOrdenCompra As String
    Private _SettingMethodSend As Integer
    Private _SettingMethodPayment As Integer
    Private _SettingAddress As Integer


    Sub New()
        MyBase.New()
    End Sub


    Public Property SettingAddress As Integer
        Get
            Return _SettingAddress
        End Get
        Set(value As Integer)
            _SettingAddress = value
        End Set
    End Property

    Public Property SettingMethodPayment As Integer
        Get
            Return _SettingMethodPayment
        End Get
        Set(value As Integer)
            _SettingMethodPayment = value
        End Set
    End Property


    Public Property SettingMethodSend As Integer
        Get
            Return _SettingMethodSend
        End Get
        Set(value As Integer)
            _SettingMethodSend = value
        End Set
    End Property


    Public Property SettingNotes As String
        Get
            Return _SettingNotes
        End Get
        Set(value As String)
            _SettingNotes = value
        End Set
    End Property
    Public Property SettingOrdenCompra As String
        Get
            Return _SettingOrdenCompra
        End Get
        Set(value As String)
            _SettingOrdenCompra = value
        End Set
    End Property
End Class
