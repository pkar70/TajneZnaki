' The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

Public NotInheritable Class UserSemafor
    Inherits UserControl


    Public Property Swiatla As String
        Set(value As String)
            uiSwiatelka.Swiatla = value
        End Set
        Get
            Return uiSwiatelka.Swiatla
        End Get
    End Property

    Public Property Opis As String
        Set(value As String)
            uiOpis.Text = value
        End Set
        Get
            Return uiOpis.Text
        End Get
    End Property



End Class
