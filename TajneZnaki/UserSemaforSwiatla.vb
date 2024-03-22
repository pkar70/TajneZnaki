Imports Windows.UI.Xaml.Shapes
Imports pkar.DotNetExtensions

Public Class UserSemaforSwiatla
    Inherits StackPanel

    Public Sub New()

        Me.Orientation = Orientation.Vertical
        Me.HorizontalAlignment = HorizontalAlignment.Center

        Me.BorderThickness = New Thickness(1)
        If Application.Current.RequestedTheme = ApplicationTheme.Dark Then
            Me.BorderBrush = New SolidColorBrush(Windows.UI.Colors.White)
        Else
            Me.BorderBrush = New SolidColorBrush(Windows.UI.Colors.Black)
        End If
    End Sub

    Private _Swiatla As String

    Public Property Swiatla As String
        Set(value As String)
            _Swiatla = value
            UstawSwiatla(value)
        End Set
        Get
            Return _Swiatla
        End Get
    End Property


    Public Sub UstawSwiatla(swiatla As String)
        If String.IsNullOrWhiteSpace(swiatla) Then Return

        Dim aSygnaly As String() = swiatla.Split(",")

        Me.Children.Clear()

        Dim colors As Brush()

        Select Case aSygnaly.Count
            Case 5
                colors = {
                    New SolidColorBrush(Windows.UI.Colors.Green),
                    New SolidColorBrush(Windows.UI.Colors.Yellow),
                    New SolidColorBrush(Windows.UI.Colors.Red),
                    New SolidColorBrush(Windows.UI.Colors.Yellow),
                    New SolidColorBrush(Windows.UI.Colors.White)}
            Case 2
                colors = {
                    New SolidColorBrush(Windows.UI.Colors.Red),
                    New SolidColorBrush(Windows.UI.Colors.Green)
                    }
            Case 3
                colors = {
                    New SolidColorBrush(Windows.UI.Colors.Green),
                    New SolidColorBrush(Windows.UI.Colors.Red),
                    New SolidColorBrush(Windows.UI.Colors.Yellow)
                    }
            Case Else
                Return
        End Select

        Dim kolorOff As New SolidColorBrush(Windows.UI.Colors.Gray)
        Dim obwodFlash As SolidColorBrush
        If Application.Current.RequestedTheme = ApplicationTheme.Dark Then
            obwodFlash = New SolidColorBrush(Windows.UI.Colors.White)
        Else
            obwodFlash = New SolidColorBrush(Windows.UI.Colors.Black)
        End If


        For iLp = 0 To aSygnaly.Count - 1
            Dim oNew As New Ellipse With
                {
                 .Margin = New Thickness(3),
                 .Fill = If(aSygnaly(iLp) = "0", kolorOff, colors(iLp)),
                 .Stroke = If(aSygnaly(iLp).EqualsCI("f"), obwodFlash, colors(iLp)),
                 .StrokeThickness = If(aSygnaly(iLp).EqualsCI("f"), 2, 0),
                 .Width = 10,
                 .Height = 10
                }
            Me.Children.Add(oNew)
        Next

    End Sub


End Class

' https://stackoverflow.com/questions/1457892/how-do-i-make-an-ellipse-blink
'Dim easing As New EasingColorKeyFrame With
'    {
'    .KeyTime = TimeSpan.FromSeconds(1),
'    .Value = Windows.UI.Colors.Gray
'    }

'Dim anim As New ColorAnimationUsingKeyFrames With
'    {
'    .BeginTime = New TimeSpan(0)
'    }


'Dim migawka As New Storyboard With
'    {
'.AutoReverse = True,
'.RepeatBehavior = RepeatBehavior.Forever
'}
'migawka.Children.Add(anim)

''    <Storyboard x : Name = "Blink" AutoReverse="True" RepeatBehavior="Forever">
''<ColorAnimationUsingKeyFrames BeginTime = "00:00:00"
'Storyboard.TargetName = "ellipse"
'Storyboard.TargetProperty = "(Shape.Fill).(SolidColorBrush.Color)" >
'        <EasingColorKeyFrame KeyTime="00:00:01" Value="Gray"/>
'            </ColorAnimationUsingKeyFrames>
'</Storyboard>

