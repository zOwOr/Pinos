Public Class InfoProductPicture
#Region "Variables"
    Private _IdProductsPicture As Long
    Private _IdProduct As Long
    Private _ProductImage As String
    Private _ProductThumb As String
#End Region

#Region "Buider"
    Sub New()
        MyBase.New()
    End Sub
#End Region
#Region "Property"

    Public Property IdProductsPicture As Long
        Get
            Return _IdProductsPicture
        End Get
        Set(value As Long)
            _IdProductsPicture = value
        End Set
    End Property
    Public Property IdProduct As Long
        Get
            Return _IdProduct
        End Get
        Set(value As Long)
            _IdProduct = value
        End Set
    End Property
    Public Property ProductImage As String
        Get
            Return _ProductImage
        End Get
        Set(value As String)
            _ProductImage = value
        End Set
    End Property
    Public Property ProductThumb As String
        Get
            Return _ProductThumb
        End Get
        Set(value As String)
            _ProductThumb = value
        End Set
    End Property
#End Region
End Class
