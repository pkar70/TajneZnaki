Imports System.Reflection

Public Class GlownyGuzik
    Inherits Button


    ' <Button Content="ADR" Click="uiADR_Click" HorizontalAlignment="Center" Margin="5,4,5,4"  Width="110"/>

    Private _strona As String
    Public Property GoPage As String
        Get
            Return _strona
        End Get
        Set(value As String)
            _strona = value
            If String.IsNullOrWhiteSpace(value) Then
                Try
                    RemoveHandler Me.Click, AddressOf KliknalemIdz
                Catch ex As Exception
                    ' jakby nie było handlera a on wtedy robił crash
                End Try
            Else
                AddHandler Me.Click, AddressOf KliknalemIdz
            End If
        End Set
    End Property

    Public Sub New()
        Me.HorizontalAlignment = HorizontalAlignment.Center
        Me.Margin = New Thickness(5, 4, 5, 4)
        Me.Width = 110
    End Sub

    Private Sub KliknalemIdz(sender As Object, e As RoutedEventArgs)
        If String.IsNullOrWhiteSpace(_strona) Then Return

        ' znajdź obiekt
        Dim appType = Application.Current.GetType
        Dim namepac = appType.AssemblyQualifiedName
        Dim iInd As Integer = namepac.IndexOf(".")
        namepac = namepac.Substring(0, iInd)
        Dim assname As New AssemblyName(namepac)
        Dim ass = Assembly.Load(assname)

        For Each typek As Type In ass.GetTypes
            If typek.Name.Equals(_strona) Then
                Dim navigationFrame As Frame = Window.Current.Content
                navigationFrame.Navigate(typek)
                Exit Sub
            End If
        Next

        Debug.WriteLine("ERROR: KliknalemIdz nie znajduje strony gdzie ma iść")

    End Sub
End Class
