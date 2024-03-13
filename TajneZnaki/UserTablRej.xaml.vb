' The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

Public NotInheritable Class UserTablRej
    Inherits UserControl

    Public Property Tlo As Brush
        Set(value As Brush)
            uiTablBack.Background = value
        End Set
        Get
            Return uiTablBack.Background
        End Get
    End Property

    Public Property Kolor As Brush
        Set(value As Brush)
            uiTablRej.Foreground = value
        End Set
        Get
            Return uiTablRej.Foreground
        End Get
    End Property

    Public Property Wzor As String
        Set(value As String)
            uiTablRej.Text = value
        End Set
        Get
            Return uiTablRej.Text
        End Get
    End Property

    Public Property Opis As String
        Set(value As String)
            uiTablOpis.Text = value
        End Set
        Get
            Return uiTablOpis.Text
        End Get
    End Property

    Public Property Row As Integer
        Set(value As Integer)
            Grid.SetRow(Me, value)
        End Set
        Get
            Return 0
        End Get
    End Property

    Public Property Col As Integer
        Set(value As Integer)
            Grid.SetColumn(Me, value)
        End Set
        Get
            Return 0
        End Get
    End Property
End Class
