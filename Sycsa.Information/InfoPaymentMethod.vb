Public Class InfoPaymentMethod
#Region "Variable"
    Private _IdPaymentMethod As Integer
    Private _Description As String
    Private _PaymentImagen As String
#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Property"
    Public Property IdPaymentMethod As Integer
        Get
            Return _IdPaymentMethod
        End Get
        Set(value As Integer)
            _PaymentImagen = value
        End Set
    End Property
    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
        End Set
    End Property
    Public Property PaymentImagen As String
        Get
            Return _PaymentImagen
        End Get
        Set(value As String)
            _PaymentImagen = value
        End Set
    End Property
#End Region
End Class
