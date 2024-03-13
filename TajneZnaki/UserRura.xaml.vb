' The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

Public NotInheritable Class UserRura
    Inherits UserControl

    Public Property Tlo As Brush
        Set(value As Brush)
            uiTablBack.Background = value
        End Set
        Get
            Return uiTablBack.Background
        End Get
    End Property

    Public Property Symbol As String
        Set(value As String)
            uiSymbol.Text = value
        End Set
        Get
            Return uiSymbol.Text
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        uiSymbol.Foreground = New SolidColorBrush(Windows.UI.Colors.Black)

    End Sub
End Class
