Imports sycsa.BusinessLayer
Imports sycsa.Information
Public Class Login
    Inherits System.Web.UI.Page
    Public Html As New vpublic
    Public ObjBLCustomer As New BLCustomers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = "Login"

        Dim _page = "Login.aspx?Login=Err"
        If Session("MM_UserId") IsNot Nothing Then
            _page = "MyAccount.aspx?"
            Response.Redirect(_page, True)
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim _page = "Login.aspx?Login=Err"
        If Session("MM_UserId") IsNot Nothing Then
            _page = "MyAccount.aspx?"
        End If

        If StarLogin(txtUserName.Text, txtPass.Text) = True Then

            If Session("PageReferent") IsNot Nothing Then
                _page = CType(Session("PageReferent"), String)
                Session.Remove("PageReferent")
            Else
                _page = "MyAccount.aspx?"
            End If

        End If

        Response.Redirect(_page, True)

    End Sub


    'Session
    Public Function StarLogin(ByVal UserLogin As String, ByVal UserPass As String) As Boolean

        Dim _Login As Boolean = False
        Dim ObjCustomerInfo As New List(Of InfoCustomers)
        With ObjBLCustomer
            .UserName = UserLogin
            .Pass = UserPass
            ObjCustomerInfo = .LoadLogin()

            If ObjCustomerInfo.Count > 0 Then

                If ObjCustomerInfo(0).IdCustomer <> Nothing Then
                    Session("MM_UserId") = ObjCustomerInfo(0).IdCustomer
                    Session("MM_UserName") = ObjCustomerInfo(0).Name
                    Session("MM_Lista") = ObjCustomerInfo(0).Paid
                    Session("MM_CIA") = ObjCustomerInfo(0).CompanyFac
                    Session("MM_CLIENTE") = ObjCustomerInfo(0).StateFac
                    Html._Lista = ObjCustomerInfo(0).Paid
                    ShoppingCart.CapturarProducto.UpdateTarifas()
                    Html.updElemntsCart()
                    _Login = True
                End If

            End If


        End With

        Return _Login

    End Function



    Protected Sub btnNewAccount_Click(sender As Object, e As EventArgs) Handles btnNewAccount.Click

        Dim _page = "newAccount.aspx?"
        Response.Redirect(_page, True)

    End Sub


End Class