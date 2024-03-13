Imports pkar.UI.Extensions


''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private Sub uiRejSwiat_Click(sender As Object, e As RoutedEventArgs)
        Me.Navigate(GetType(RejSwiat))
    End Sub

    Private Sub uiRejPL_Click(sender As Object, e As RoutedEventArgs)
        Me.Navigate(GetType(RejPL))
    End Sub
    Private Sub uiADR_Click(sender As Object, e As RoutedEventArgs)
        Me.Navigate(GetType(ADR))
    End Sub
    Private Sub uiTablOrient_Click(sender As Object, e As RoutedEventArgs)
        Me.Navigate(GetType(Rurociagi))
    End Sub

End Class
