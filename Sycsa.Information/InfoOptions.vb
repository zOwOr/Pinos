Public Class InfoOptions
#Region "Variable"

    Private _IdOptions As Long
    Private _OptionName As String
    Private _OptionValue As String
    Private _AutoLoad As String

    'MethodSend

    Private _idSend As Integer
    Private _OptionSend As String
    Private _PriceSend As Decimal
    Private _CommSend As String

#End Region
#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region
#Region "Property"

    Public Property CommSend As String
        Get
            Return _CommSend
        End Get
        Set(value As String)
            _CommSend = value
        End Set
    End Property

    Public Property PriceSend As Decimal
        Get
            Return _PriceSend
        End Get
        Set(value As Decimal)
            _PriceSend = value
        End Set
    End Property


    Public Property OptionSend As String
        Get
            Return _OptionSend
        End Get
        Set(value As String)
            _OptionSend = value
        End Set
    End Property

    Public Property idSend As Integer
        Get
            Return _idSend
        End Get
        Set(value As Integer)
            _idSend = value
        End Set
    End Property

    Public Property IdOption As Long
        Get
            Return _IdOptions
        End Get
        Set(value As Long)
            _IdOptions = value
        End Set
    End Property
    Public Property OptionName As String
        Get
            Return _OptionName
        End Get
        Set(value As String)
            _OptionName = value
        End Set
    End Property
    Public Property OptionValue As String
        Get
            Return _OptionValue
        End Get
        Set(value As String)
            _OptionValue = value
        End Set
    End Property
    Public Property AutoLoad As String
        Get
            Return _AutoLoad
        End Get
        Set(value As String)
            _AutoLoad = value
        End Set
    End Property

#End Region
End Class
