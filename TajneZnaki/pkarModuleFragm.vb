
' ograniczony!

Imports pkar.DotNetExtensions

#Region "Konwertery Bindings XAML"
' nie mogą być w VBlib, bo Implements Microsoft.UI.Xaml.Data.IValueConverter

#Region "to co dla innych UI może być w Nuget, a w UWP być nie może"
#If NETFX_CORE Then

' WinRT nie może mieć "mustoverride"

Public MustInherit Class ValueConverterOneWay
    Implements IValueConverter

    Public MustOverride Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

''' <summary>
''' this class should be used to define your own ValueConverters; but it frees you from writing ConvertBack method, and simplyfies Convert method
''' </summary>
Public MustInherit Class ValueConverterOneWaySimple
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return Convert(value)
    End Function

    Protected MustOverride Function Convert(value As Object) As Object


    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

Public MustInherit Class ValueConverterOneWayWithPar
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim param As String = ""

        If parameter IsNot Nothing Then param = CType(parameter, String)

        Return Convert(value, param)
    End Function

    Protected MustOverride Function Convert(value As Object, param As String) As Object

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class


#End If

#End Region


' parameter = NEG robi negację
Public Class KonwersjaVisibility
    Inherits ValueConverterOneWayWithPar

    Protected Overrides Function Convert(value As Object, param As String) As Object

        Dim bTemp As Boolean = CType(value, Boolean)
        If param.EqualsCI("NEG") Then bTemp = Not bTemp

        Return If(bTemp, Visibility.Visible, Visibility.Collapsed)
    End Function

End Class

' ULONG to String
Public Class KonwersjaMAC
    Inherits ValueConverterOneWaySimple

    ' Define the Convert method to change a DateTime object to
    ' a month string.
    Protected Overrides Function Convert(ByVal value As Object) As Object

        ' value is the data from the source object.

        Dim uMAC As ULong = CType(value, ULong)
        If uMAC = 0 Then Return ""

        Return uMAC.ToHexBytesString()

    End Function

End Class

''' <summary>
''' konwersja ToString, ale używając parametru wymuszającego FORMAT (np. %2d)
''' </summary>

Public Class KonwersjaVal2StringFormat
    Inherits ValueConverterOneWayWithPar

    Protected Overrides Function Convert(value As Object, sFormat As String) As Object

        If value.GetType Is GetType(Integer) Then
            Dim temp = CType(value, Integer)
            Return If(sFormat = "", temp.ToString, temp.ToString(sFormat))
        End If

        If value.GetType Is GetType(Long) Then
            Dim temp = CType(value, Long)
            Return If(sFormat = "", temp.ToString, temp.ToString(sFormat))
        End If

        If value.GetType Is GetType(Double) Then
            Dim temp = CType(value, Double)
            Return If(sFormat = "", temp.ToString, temp.ToString(sFormat))
        End If

        If value.GetType Is GetType(String) Then
            Dim temp = CType(value, String)
            Return If(sFormat = "", temp.ToString, String.Format(sFormat, temp))
        End If

        Return "???"

    End Function

End Class

Public Class KonwersjaDaty
    Inherits ValueConverterOneWaySimple

    Protected Overrides Function Convert(value As Object) As Object
        Dim temp As DateTime = CType(value, DateTime)

        If temp.Year < 1000 Then Return "--"
        If temp.Year > 2100 Then Return "--"

        Return temp.ToString("yyyy-MM-dd")
    End Function

End Class

#End Region
