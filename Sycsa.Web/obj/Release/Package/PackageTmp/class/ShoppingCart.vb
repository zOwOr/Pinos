Public Class ShoppingCart
    Public DataSet As New DataSet
    Public common As New CONECTASQL.ConectaSQL
    'Lista para los productos
    Public Property ListProducts() As List(Of addShoppingCart)
        Get
            Return m_ListProducts
        End Get
        Private Set(value As List(Of addShoppingCart))
            m_ListProducts = value
        End Set
    End Property
    Private m_ListProducts As List(Of addShoppingCart)



    Public Shared Function CapturarProducto() As ShoppingCart
        Dim _carrito As ShoppingCart = DirectCast(HttpContext.Current.Session("ss_ShoppingCart"), ShoppingCart)
        If _carrito Is Nothing Then
            HttpContext.Current.Session("ss_ShoppingCart") = InlineAssignHelper(_carrito, New ShoppingCart())
        End If
        Return _carrito
    End Function


    Protected Sub New()
        ListProducts = New List(Of addShoppingCart)()
    End Sub

    Public Sub Agregar(pIdProducto As Integer, Optional ByVal cantidad As Double = 1, Optional ByVal unidad As String = "")
        Dim NuevoProducto As New addShoppingCart(pIdProducto, unidad)
        If ListProducts.Contains(NuevoProducto) Then
            For Each item As addShoppingCart In ListProducts
                If item.Equals(NuevoProducto) Then
                    item.Cantidad += cantidad
                    If HttpContext.Current.Session("MM_CLIENTE") IsNot Nothing Then
                        UpdateCarritoBD(pIdProducto, item.Cantidad, unidad)
                    End If
                    Return
                End If
            Next
        Else
            NuevoProducto.Cantidad = cantidad
            ListProducts.Add(NuevoProducto)
        End If
        If HttpContext.Current.Session("MM_CLIENTE") IsNot Nothing Then
            InsertOneCarritoBD(pIdProducto, cantidad, unidad)
        End If
    End Sub


    Public Sub EliminarProductos(pIdProducto As Integer, Optional ByVal unidad As String = "")
        Dim eliminaritems As New addShoppingCart(pIdProducto, unidad)
        ListProducts.Remove(eliminaritems)
        If HttpContext.Current.Session("MM_CLIENTE") IsNot Nothing Then
            DeleteCarritoBD(pIdProducto, unidad)
        End If
    End Sub



    Public Sub CantidadDeProductos(pIdProducto As Integer, pCantidad As Integer, Optional ByVal unidad As String = "")
        If pCantidad = 0 Then
            EliminarProductos(pIdProducto, unidad)
            If HttpContext.Current.Session("MM_CLIENTE") IsNot Nothing Then
                DeleteCarritoBD(pIdProducto, unidad)
            End If
            Return
        End If
        Dim updateProductos As New addShoppingCart(pIdProducto, unidad)
        For Each item As addShoppingCart In ListProducts
            If item.Equals(updateProductos) Then
                item.Cantidad = pCantidad
                If HttpContext.Current.Session("MM_CLIENTE") IsNot Nothing Then
                    UpdateCarritoBD(pIdProducto, pCantidad, unidad)
                End If
                Return
            End If
        Next
    End Sub


    Public Function SubTotal() As Decimal
        Dim subtotal__1 As Decimal = 0
        For Each item As addShoppingCart In ListProducts
            subtotal__1 += item.Total
        Next
        Return subtotal__1
    End Function


    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

    Public Sub UpdateTarifas()
        Dim _ListProducts As New GridView()
        _ListProducts.DataSource = ShoppingCart.CapturarProducto().ListProducts.AsEnumerable
        _ListProducts.DataBind()

        For Each _orows As GridViewRow In _ListProducts.Rows
            Dim idProduct As Integer = _orows.Cells(0).Text.ToString
            Dim Unidad As String = _orows.Cells(3).Text.ToString
            Dim Cantidad As Decimal = _orows.Cells(5).Text.ToString
            Dim NuevoProducto As New addShoppingCart(idProduct, Unidad)

            If ListProducts.Contains(NuevoProducto) Then
                Dim eliminaritems As New addShoppingCart(idProduct, Unidad)
                ListProducts.Remove(eliminaritems)

                NuevoProducto.Cantidad = Cantidad
                ListProducts.Add(NuevoProducto)
            End If
        Next
        If HttpContext.Current.Session("MM_CLIENTE") IsNot Nothing Then
            InsertCarritoBD()
        End If

    End Sub
    Public Sub InsertCarritoBD()
        Dim _ListProducts As New GridView()
        Dim partida As Integer = 0 ' Inicializar la variable
        Dim idProduct As Integer
        Dim Unidad As String
        Dim idProductbd As Integer
        Dim Unidadbd As String = String.Empty ' Inicializar la variable
        Dim Cantidad As Decimal
        Dim Cantidadbd As Decimal
        Dim clientebd As String = String.Empty ' Inicializar la variable
        Dim sql As String

        _ListProducts.DataSource = ShoppingCart.CapturarProducto().ListProducts.AsEnumerable
        _ListProducts.DataBind()

        Dim cliente As String = HttpContext.Current.Session("MM_CLIENTE")
        For Each _orows As GridViewRow In _ListProducts.Rows
            partida += 1
            idProduct = Integer.Parse(_orows.Cells(0).Text.ToString)
            Unidad = _orows.Cells(3).Text.ToString
            Cantidad = Decimal.Parse(_orows.Cells(5).Text.ToString)

            Dim NuevoProducto As New addShoppingCart(idProduct, Unidad)

            DataSet = common.sqlconsulta("select * from carrito where cliente=" & cliente & " and codigo_pro=" & idProduct & " and unidad='" & Unidad & "'", "dsCarrito")
            If DataSet IsNot Nothing AndAlso DataSet.Tables(0).Rows.Count > 0 Then
                clientebd = DataSet.Tables(0).Rows(0).Item("cliente").ToString
                idProductbd = Integer.Parse(DataSet.Tables(0).Rows(0).Item("codigo_pro").ToString)
                Unidadbd = DataSet.Tables(0).Rows(0).Item("unidad").ToString
                Cantidadbd = Decimal.Parse(DataSet.Tables(0).Rows(0).Item("cantidad").ToString)
            End If

            If DataSet Is Nothing OrElse DataSet.Tables(0).Rows.Count = 0 Then
                sql = "insert into carrito (cliente, codigo_pro , partida, cantidad, unidad) values(" & cliente & "," & idProduct & "," & partida & "," & Cantidad & ",'" & Unidad & "')"
                common.sqlcomando(sql)
            ElseIf clientebd = cliente AndAlso Unidadbd = Unidad AndAlso Cantidadbd <> Cantidad Then
                sql = "update carrito set cantidad =" & Cantidad & " where cliente=" & cliente & " and codigo_pro=" & idProduct & " and unidad='" & Unidad & "'"
                common.sqlcomando(sql)
            End If
        Next
        SelectCarritoBD()
    End Sub


    Public Sub UpdateCarritoBD(pIdProducto As Integer, pCantidad As Integer, Optional ByVal unidad As String = "")
        Dim idProduct As Integer = pIdProducto
        Dim idProductbd As Integer
        Dim Unidadbd As String = String.Empty
        Dim Cantidadbd As Decimal = 0
        Dim clientebd As String = String.Empty
        Dim sql As String
        Dim cliente As String = HttpContext.Current.Session("MM_CLIENTE")

        DataSet = common.sqlconsulta("select * from carrito where cliente=" & cliente & " and codigo_pro=" & idProduct & " and unidad='" & unidad & "'", "dsCarrito")

        If DataSet IsNot Nothing AndAlso DataSet.Tables(0).Rows.Count > 0 Then
            clientebd = DataSet.Tables(0).Rows(0).Item("cliente").ToString
            idProductbd = Integer.Parse(DataSet.Tables(0).Rows(0).Item("codigo_pro").ToString)
            Unidadbd = DataSet.Tables(0).Rows(0).Item("unidad").ToString
            Cantidadbd = Decimal.Parse(DataSet.Tables(0).Rows(0).Item("cantidad").ToString)
        End If

        If DataSet Is Nothing OrElse DataSet.Tables(0).Rows.Count = 0 Then
            sql = "insert into carrito (cliente, codigo_pro , cantidad, unidad) values(" & cliente & "," & idProduct & "," & pCantidad & ",'" & unidad & "')"
            common.sqlcomando(sql)
        ElseIf clientebd = cliente AndAlso Unidadbd = unidad AndAlso Cantidadbd <> pCantidad Then
            common.sqlcomando("update carrito set cantidad =" & pCantidad & " where cliente=" & cliente & " and codigo_pro=" & idProduct & " and unidad='" & unidad & "'")
        End If
    End Sub

    Public Sub DeleteCarritoBD(pIdProducto As Integer, Optional ByVal unidad As String = "")
        Dim cliente As String = HttpContext.Current.Session("MM_CLIENTE")
        common.sqlcomando("Delete from carrito where cliente=" & cliente & " and codigo_pro=" & pIdProducto & " and unidad='" & unidad & "'")
    End Sub
    Public Sub SelectCarritoBD()
        Dim cliente As String = HttpContext.Current.Session("MM_CLIENTE")
        DataSet = common.sqlconsulta("Select * from carrito where cliente=" & cliente, "dsCarrito")
        Dim idProductbd As Integer
        Dim Unidadbd As String
        Dim clientebd As String
        Dim Cantidadbd As Decimal
        Dim _ListProducts As New GridView()
        _ListProducts.DataSource = ShoppingCart.CapturarProducto().ListProducts.AsEnumerable
        _ListProducts.DataBind()

        For Each _orows As GridViewRow In _ListProducts.Rows
            Dim idProduct As Integer = _orows.Cells(0).Text.ToString
            Dim Unidad As String = _orows.Cells(3).Text.ToString
            Dim Cantidad As Decimal = _orows.Cells(5).Text.ToString
            Dim NuevoProducto As New addShoppingCart(idProduct, Unidad)
            If ListProducts.Contains(NuevoProducto) Then
                Dim eliminaritems As New addShoppingCart(idProduct, Unidad)
                ListProducts.Remove(eliminaritems)
            End If
        Next
        If DataSet IsNot Nothing Then
            For x = 0 To DataSet.Tables(0).Rows.Count - 1
                clientebd = DataSet.Tables(0).Rows(x).Item("cliente").ToString
                idProductbd = DataSet.Tables(0).Rows(x).Item("codigo_pro").ToString
                Unidadbd = DataSet.Tables(0).Rows(x).Item("unidad").ToString
                Cantidadbd = DataSet.Tables(0).Rows(x).Item("Cantidad")
                Dim NuevoProducto As New addShoppingCart(idProductbd, Unidadbd)
                NuevoProducto.Cantidad = Cantidadbd
                ListProducts.Add(NuevoProducto)
            Next
        End If

    End Sub
    Public Sub InsertOneCarritoBD(pIdProducto As Integer, pCantidad As Integer, Optional ByVal unidad As String = "")
        Dim sql As String
        Dim cliente As String = HttpContext.Current.Session("MM_CLIENTE")
        sql = "insert into carrito (cliente, codigo_pro , cantidad, unidad) values(" & cliente & "," & pIdProducto & "," & pCantidad & ",'" & unidad & "')"
        common.sqlcomando(sql)
    End Sub


End Class